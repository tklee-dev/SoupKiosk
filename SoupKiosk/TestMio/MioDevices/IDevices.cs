using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    public interface IDevices : IDisposable
    {
        string InitialError { get; }
        //Task<bool> Initialize();
        //Task<bool> InitWebcam();
        //Task<bool> InitAmpUnit();
        //Task<bool> InitCashUnit();
        Task<bool> InitStapler();
        //Task<bool> InitUps();
        //Task<bool> InitRfid();

        //IWebcam Webcam { get; }
        //IAmpUnit AmpUnit { get; }
        //ICashUnit CashUnit { get; }
        //ILedSignal LedSignal { get; }
        //ISensorUnit SensorUnit { get; }
        IStapler Stapler { get; }
        //IUps Ups { get; }
        //IKeypad Keypad { get; }
        //IRfidDoorLock RfidDoorLock { get; }

        //bool CanDetectEarphone { get; }
    }
}
