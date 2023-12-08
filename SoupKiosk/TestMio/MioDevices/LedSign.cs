using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMio
{
    class LedSign : MioDeviceBase, ILedSignal
    {
        public bool IsSupportMultiColor => false;

        public LedSign(MioPort control)
            : base(DeviceID.LED, control)
        { }

        /// <summary>
        /// 용지 배출구 LED
        /// </summary>
        public bool OnPaperGate
        {
            get => _OnPaperGate;
            set => base.SetProperty(ref _OnPaperGate, value, () => Send(value ? "용지배출구 ON" : "용지배출구 OFF"));
        }
        private bool _OnPaperGate = false;


        /// <summary>
        /// K300 전용
        /// </summary>
        public bool OnStandby { get; set; }

        /// <summary>
        /// K300 전용
        /// </summary>
        public bool OnCardPayment { get; set; }


        public bool OnPaperGateComplete { get; set; }

        /// <summary>
        /// 전체 OFF
        /// </summary>
        public void SetAllOff()
        {

            OnStandby = false;
            OnCardPayment = false;
            Send("전체 OFF");
        }

        /// <summary>
        /// 전체 ON
        /// </summary>
        public void SetAllOn()
        {

            _OnPaperGate = true;

            OnStandby = true;
            OnCardPayment = true;
            Send("전체 ON");
        }

        private void Send(string desc)
        {
            try
            {
                BitArray cmd = new BitArray(32);
                cmd[0] = _OnPaperGate;

                //cmd[1] = _OnChangeOut;
                //cmd[10] = _OnChangeOut;

                //cmd[2] = _OnIDCard;
                //cmd[3] = _OnReceipt;
                //cmd[8] = _OnCashInput;
                //cmd[9] = _OnFingerPrint;

                byte[] data = new byte[4];
                cmd.CopyTo(data, 0);
                data[3] = 0x01;

                base.SendNoWait(desc, data);
                Thread.Sleep(50);  // Led날리고 다른신호를 바로 날리면 명령이 안들어간다.
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 전송 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
            }
        }
    }
}
