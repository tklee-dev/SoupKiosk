using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KGClient
{
    abstract class MioPortBase : DisposeBase
    {
        protected abstract string LogHeader { get; }
        protected abstract string PrimaryPortName { get; }

        public abstract Task<bool> TryOpenFunction();

        protected abstract void Log(string log);

        protected abstract void Log(DeviceID dest, string log);

        private string LogH;

        public string PortNo => Serial?.Port;

        protected SerialControl Serial;

        private MioPacket _PacketManager { get; }

        protected int MaxMessageLength
        {
            get => _PacketManager.MaxMessageLength;
            set => _PacketManager.MaxMessageLength = value;
        }


        public string LastError { get; protected set; }

        public MioPortBase()
        {
            LogH = $"[{LogHeader}]\t";
            _PacketManager = new MioPacket();
            _PacketManager.Log = Log;
            _PacketManager.LogId = Log;

            //_PacketManager.OnDataError += _PacketManager_OnDataError;
            Serial = new SerialControl();
            Serial.BaudRate = 38400;
            Serial.DataBits = 8;
            Serial.Parity = Parity.None;
            Serial.StopBits = StopBits.One;
            Serial.OnDataReceived += Serial_OnDataReceived;
        }

        protected override void DisposeManaged()
        {
            //_PacketManager.OnDataError -= packetManager_OnDataError;
            _PacketManager.MessageEvents.Clear();

            if (Serial != null)
            {
                Close();
                Serial.OnDataReceived -= Serial_OnDataReceived;
                Serial.Dispose();
                Serial = null;
            }

            base.DisposeManaged();
        }

        void Serial_OnDataReceived(object sender, OnDataReceivedEventArgs e) =>
            _PacketManager.AddData(e.Data);


        public async Task<bool> Open(string portName = "")
        {
            Log($"{LogH}");

            // 기존에 오픈되었을수 있어서 한번 Close시키고 오픈한다.
            Close();

            var portNames = SerialControl.GetSerialPortNames();

            if (portNames == null || portNames.Length == 0)
            {
                Log($"{LogH}PC에 시리얼 포트 없음");
                LastError = "이 컴퓨터에 시리얼 포트가 존재하지 않습니다.";
                return false;
            }

            //포트가 지정되어 있으면 지정된 포트로만 시도한다.
            if (String.IsNullOrWhiteSpace(portName) == false)
            {
                Log($"{LogH}지정된 포트로 연결 시도 ({portName})");
                if (portNames.Contains(portName) == false)
                {
                    Log($"{LogH}지정된 포트가 존재하지 않음");
                    LastError = $"지정한 포트 {portName}이 존재하지 않습니다.";
                    return false;
                }
                return await TryOpenPort(portName);
            }



            Log($"{LogH}장치를 연결할 수 없음");
            LastError = "장치를 연결할 수 없습니다.";
            return false;
        }

        private async Task<bool> TryOpenPort(string portName)
        {
            Log($"{LogH}포트 오픈 ({portName})");
            try
            {
                Serial.Open(portName);
                var rv = await TryOpenFunction();
                if (rv == false)
                {
                    Log($"{LogH}장치 연결 실패");
                    Serial.Close();
                }
                else
                    Log($"{LogH}장치 연결 성공");

                return rv;
            }
            catch (Exception ex)
            {
                Log($"{LogH}장치 연결 시도 오류 발생 - {ex.Message}");
                Serial.Close();
                return false;
            }
        }

        public void Close()
        {
            if (Serial != null)
                Serial.Close();
        }

        public void SendPacket(DeviceID src, DeviceID dest, params byte[] message) =>
            SendPacket(String.Empty, src, dest, message);

        public void SendPacket(string desc, DeviceID src, DeviceID dest, params byte[] message)
        {
            // 너무 빨리 전송시 MIO에서 데이터를 먹을 수 있어 50ms 딜레이를 준다.
            var interval = (DateTime.Now - sendedTime).TotalMilliseconds;
            if (interval < 50)
                Thread.Sleep((int)(50 - interval));

            var buf = MioPacket.CreatePadketData(src, dest, message);
            if (String.IsNullOrWhiteSpace(desc))
                Log(dest, $"[S] {Converter.HexDataToStr(buf)}");
            else
                Log(dest, $"[S] {Converter.HexDataToStr(buf)}\t{desc}");

            Serial.Send(buf);
            sendedTime = DateTime.Now;
        }

        private DateTime sendedTime;

        public void AddEventHandler(MioDeviceBase dev) => _PacketManager.AddEventHandler(dev.DeviceID, dev.OnPacketReceived);

        public void RemoveEventHandler(MioDeviceBase dev) => _PacketManager.RemoveEventHandler(dev.DeviceID, dev.OnPacketReceived);
    }
}
