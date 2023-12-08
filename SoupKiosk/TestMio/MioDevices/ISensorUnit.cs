using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    public interface ISensorUnit : IDisposable
    {
        //bool IsDoorOpen { get; }
        //bool IsBackDoorOpen { get; }
        //bool IsEmptyReceiptPaper { get; }
        //bool IsFanRunning { get; }
        //bool IsFullDehumidifiers { get; }
        //bool IsPushReturnButton { get; }
        bool IsUserDetected { get; }
        //bool IsPushAdminButton { get; }
        //bool IsOpenCashUnit { get; }
        //bool IsPaperDetectedOnGate { get; }

        event EventHandler OnDetectUserChanged;
        //event EventHandler OnDoorOpenChanged;
        //event EventHandler OnEmptyReceiptPaperChanged;
        //event EventHandler OnFanRunningChanged;
        //event EventHandler OnFullDehumidifiersChanged;
        //event EventHandler OnReturnButtonChanged;

        //event EventHandler OnAdminButtonChanged;
        //event EventHandler OnOpenCashUnitChanged;
        //event EventHandler OnPaperDetectedOnGateChanged;
    }
}
