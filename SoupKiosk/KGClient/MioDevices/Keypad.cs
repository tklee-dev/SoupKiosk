using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class Keypad : MioDeviceBase, IKeypad
    {
        public Keypad(MioPort control)
            : base(DeviceID.KEYPAD, control)
        { }

        public event EventHandler<KeypadKeys> OnPressKeypadKey
        {
            add => _OnPressKeypadKey += value;
            remove => _OnPressKeypadKey -= value;
        }
        private EventHandler<KeypadKeys> _OnPressKeypadKey;

        public override void OnPacketReceived(object sender, MioPacketData packet)
        {
            try
            {
                var data = packet.Message[0];

                var key = ToKey(data);

                if (key.HasValue)
                    _OnPressKeypadKey?.Invoke(this, key.Value);
                else
                    MioLogger.Error(DeviceID, $"정의되지 않은 키패드 데이터 수신  - {JelLib.Converter.HexToStr(data)}");

                base.OnPacketReceived(sender, packet);
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 수신 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
            }
        }

        private KeypadKeys? ToKey(byte b)
        {
            switch (b)
            {
                case (byte)'1':
                    return KeypadKeys.No1;
                case (byte)'2':
                    return KeypadKeys.No2;
                case (byte)'3':
                    return KeypadKeys.No3;
                case (byte)'4':
                    return KeypadKeys.No4;
                case (byte)'5':
                    return KeypadKeys.No5;
                case (byte)'6':
                    return KeypadKeys.No6;
                case (byte)'7':
                    return KeypadKeys.No7;
                case (byte)'8':
                    return KeypadKeys.No8;
                case (byte)'9':
                    return KeypadKeys.No9;
                case (byte)'0':
                    return KeypadKeys.No0;
                case (byte)'*':
                    return KeypadKeys.Asterisk;
                case (byte)'#':
                    return KeypadKeys.Pound;

                case (byte)'S':
                    return KeypadKeys.L1_Left; // 시작;
                case (byte)'C':
                    return KeypadKeys.L1_Right; // 취소;

                case (byte)'U':
                    return KeypadKeys.L2_Left; // Up;
                case (byte)'M':
                    return KeypadKeys.L2_Center; // 모음;
                case (byte)'D':
                    return KeypadKeys.L2_Right; // Down;

                case (byte)'J':
                    return KeypadKeys.L3_Left; // 자음;
                case (byte)'I':
                    return KeypadKeys.L3_Center; // 입력;
                case (byte)'B':
                    return KeypadKeys.L3_Right; // 영문;

                case (byte)'E':
                    return KeypadKeys.L4_Left; // 확인;
                case (byte)'R':
                    return KeypadKeys.L4_Right; // 정정;
                default:
                    return null;
            }
        }
    }
}
