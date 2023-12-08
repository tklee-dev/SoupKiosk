using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class SensorK300 : MioDeviceBase, ISensorUnit, INotifyPropertyChanged
    {

        

        ///// <summary>
        ///// 도어 오픈 센서 상태 변경됨
        ///// </summary>
        //public event EventHandler OnDoorOpenChanged
        //{
        //    add => _OnDoorOpenChanged += value;
        //    remove => _OnDoorOpenChanged -= value;
        //}
        //private EventHandler _OnDoorOpenChanged;

        /// <summary>
        /// 근접감지센서 감지 상태 변경됨
        /// </summary>
        public event EventHandler OnDetectUserChanged
        {
            add => _OnDetectUserChanged += value;
            remove => _OnDetectUserChanged -= value;
        }
        private EventHandler _OnDetectUserChanged;

        private bool _IsPushAdminButton = false;


   
        /// <summary>
        /// 사용자 감지 여부
        /// </summary>
        public bool IsUserDetected
        {
            get => _IsUserDetected;
            set
            {
                if (base.SetProperty(ref _IsUserDetected, value))
                {
                    MioLogger.Log(DeviceID, $"사용자 감지 상태(K300) - {(_IsUserDetected ? "감지" : "미감지")}");
                    if (_RaiseUserDetected)
                        _OnDetectUserChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private bool _IsUserDetected = false;



        private bool _RaiseUserDetected = false;

        public SensorK300(MioPort control, bool raiseUserDetected)
            : base(DeviceID.SENSOR_K300, control)
        {
            _RaiseUserDetected = raiseUserDetected;
        }

        private readonly byte[] STATUS_CMD = { (byte)'S', JelLib.Converter.ToFlipByte('S') };


        public Task<bool> GetStatus() =>
            Task.Run(() => SendRetry("상태 요청", STATUS_CMD));

        public override void OnPacketReceived(object sender, MioPacketData packet)
        {
            try
            {
                var data = new SENSOR_K300_DATA(packet.Message);


                IsUserDetected = data.IsDetectUser;
       

                base.OnPacketReceived(sender, packet);
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 수신 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
            }
        }
    }
}
