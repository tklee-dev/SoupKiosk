using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    public interface ILedSignal : IDisposable
    {
        /// <summary>
        /// 3색 LED 지원 여부
        /// OnFingerPrintComplete, OnPaperGateComplete, OnStandby에서 사용
        /// </summary>
        bool IsSupportMultiColor { get; }

        bool OnPaperGate { get; set; }

        bool OnPaperGateComplete { get; set; }

        bool OnStandby { get; set; }

        bool OnCardPayment { get; set; }

        void SetAllOff();
        void SetAllOn();
    }
}
