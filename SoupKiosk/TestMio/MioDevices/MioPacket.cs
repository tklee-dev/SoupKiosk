using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    class MioPacket
    {
        private const byte STX = 0x02;
        private const byte ETX = 0x03;
        public int MaxMessageLength { get; set; } = 25;

        public Action<string> Log { get; set; }

        public Action<DeviceID, string> LogId { get; set; }

        public static byte[] CreatePadketData(DeviceID src, DeviceID dest, params byte[] message)
        {
            List<byte> list = new List<byte>();
            list.Add(STX);
            list.Add((byte)src);
            list.Add((byte)dest);
            list.Add(GetCmdId(dest));
            list.Add(0x00);
            list.Add((byte)message.Length);
            list.AddRange(message);
            list.Add(ETX);

            byte chk = 0x00;
            foreach (byte b in list)
                chk ^= b;
            list.Add(chk);
            return list.ToArray();
        }

        private static Dictionary<DeviceID, byte> CmdIdList;
        private static byte GetCmdId(DeviceID dest)
        {
            if (CmdIdList == null)
            {
                CmdIdList = new Dictionary<DeviceID, byte>();
                foreach (var dev in (DeviceID[])Enum.GetValues(typeof(DeviceID)))
                    CmdIdList.Add(dev, 0x00);
            }
            return CmdIdList[dest]++; //0xFF이후 0x00으로 자동 초기화
        }

        public void AddEventHandler(DeviceID id, EventHandler<MioPacketData> handler)
        {
            if (MessageEvents.ContainsKey(id) == false)
                MessageEvents.Add(id, new List<EventHandler<MioPacketData>>());

            //중복 값은 넣지 않는다.
            if (MessageEvents[id].Contains(handler) == false)
                MessageEvents[id].Add(handler);
        }

        public void RemoveEventHandler(DeviceID id, EventHandler<MioPacketData> handler)
        {
            if (MessageEvents.ContainsKey(id) && MessageEvents[id].Contains(handler))
                MessageEvents[id].Remove(handler);
        }

        public Dictionary<DeviceID, List<EventHandler<MioPacketData>>> MessageEvents { get; private set; }
            = new Dictionary<DeviceID, List<EventHandler<MioPacketData>>>();

        public event EventHandler<DataErrorEventArgs> OnDataError
        {
            add { _OnDataError += value; }
            remove { _OnDataError -= value; }
        }
        private EventHandler<DataErrorEventArgs> _OnDataError;


        private enum PackekFlow { STX, SRC, DEST, CMDID, RVS, LENGTH, MESSAGE, ETX, CHECKSUM }
        private PackekFlow _Flow = PackekFlow.STX;
        private byte _Checksum = 0x00;
        private MioPacketData _LastPacket;
        private List<byte> _PacketContainer = new List<byte>();
        private List<byte> _MessageContainer = new List<byte>();

        public void AddData(byte data)
        {
            switch (_Flow)
            {
                case PackekFlow.STX:
                    if (data != STX)
                    {
                        RaiseFlowError(_Flow);
                        break;
                    }

                    _PacketContainer.Clear();
                    _PacketContainer.Add(data);

                    _MessageContainer.Clear();

                    _LastPacket = new MioPacketData();
                    _Checksum = 0x00;
                    _Checksum ^= data;
                    _Flow = PackekFlow.SRC;
                    break;

                case PackekFlow.SRC:
                    _PacketContainer.Add(data);
                    if (Enum.IsDefined(typeof(DeviceID), data) == false)
                    {
                        RaiseFlowError(_Flow);
                        _Flow = PackekFlow.STX;
                        break;
                    }

                    _LastPacket.SRC = (DeviceID)data;
                    _Checksum ^= data;
                    _Flow = PackekFlow.DEST;
                    break;

                case PackekFlow.DEST:
                    _PacketContainer.Add(data);
                    if (Enum.IsDefined(typeof(DeviceID), data) == false)
                    {
                        RaiseFlowError(_Flow);
                        _Flow = PackekFlow.STX;
                        break;
                    }

                    _LastPacket.DEST = (DeviceID)data;
                    _Checksum ^= data;
                    _Flow = PackekFlow.CMDID;
                    break;

                case PackekFlow.CMDID:
                    _PacketContainer.Add(data);
                    _LastPacket.CMD_ID = data;
                    _Checksum ^= data;
                    _Flow = PackekFlow.RVS;
                    break;

                case PackekFlow.RVS:
                    _PacketContainer.Add(data);
                    _LastPacket.RVS = data;
                    _Checksum ^= data;
                    _Flow = PackekFlow.LENGTH;
                    break;

                case PackekFlow.LENGTH:
                    _PacketContainer.Add(data);
                    if (data > MaxMessageLength)
                    {
                        RaiseFlowError(_Flow);
                        _Flow = PackekFlow.STX;
                        break;
                    }
                    _LastPacket.Length = data;
                    _Checksum ^= data;
                    _Flow = PackekFlow.MESSAGE;
                    break;

                case PackekFlow.MESSAGE:
                    _PacketContainer.Add(data);
                    _MessageContainer.Add(data);
                    _Checksum ^= data;

                    if (_MessageContainer.Count == _LastPacket.Length)
                    {
                        _LastPacket.Message = _MessageContainer.ToArray();
                        _Flow = PackekFlow.ETX;
                    }
                    break;

                case PackekFlow.ETX:
                    _PacketContainer.Add(data);
                    if (data != ETX)
                    {
                        RaiseFlowError(_Flow);
                        _Flow = PackekFlow.STX;
                        break;
                    }
                    _Flow = PackekFlow.CHECKSUM;
                    _Checksum ^= data;
                    break;

                case PackekFlow.CHECKSUM:
                    _PacketContainer.Add(data);
                    if (data != _Checksum)
                        RaiseFlowError(_Flow);
                    else
                    {
                        _LastPacket.BCC = data;
                        RaisePacket(_LastPacket);
                        _LastPacket = null;
                    }
                    _Flow = PackekFlow.STX;
                    break;
            }
        }



        private void RaiseFlowError(PackekFlow flow)
        {
            var msg = $"{flow} 에러";
            Log?.Invoke("[R] " + Converter.HexDataToStr(_PacketContainer.ToArray()) + " - " + msg);
            _OnDataError?.Invoke(this, new DataErrorEventArgs(msg, _PacketContainer.ToArray()));
        }

        private async void RaisePacket(MioPacketData packet)
        {
            if (MessageEvents.ContainsKey(packet.SRC) && MessageEvents[packet.SRC].Count > 0)
            {
                LogId?.Invoke(packet.SRC, "[R] " + Converter.HexDataToStr(_PacketContainer.ToArray()));
                var actions = MessageEvents[packet.SRC].ToArray();
                if (actions != null)
                {
                    foreach (var action in actions)
                        await Task.Run(() => action(this, packet));
                }
            }
            else
            {
                LogId?.Invoke(packet.SRC, $"[R] {Converter.HexDataToStr(_PacketContainer.ToArray())} - 메시지 수신자 없음");
                _OnDataError?.Invoke(this, new DataErrorEventArgs($"{packet.SRC} 메시지 수신자 없음", _PacketContainer.ToArray()));
            }
        }
    }



    class DataErrorEventArgs : EventArgs
    {
        public DataErrorEventArgs(string message, byte[] packetdata)
        {
            this.Message = message;
            this.PacketData = packetdata;
        }
        public byte[] PacketData { get; private set; }
        public string Message { get; private set; }
    }
}
