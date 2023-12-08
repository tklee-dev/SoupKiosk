using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStapler
{
    class Program : IDevices
    {
        public string InitialError { get; private set; } = String.Empty;

        public IStapler Stapler { get; private set; }
        public ISensorUnit SensorUnit { get; private set; }
        public IKeypad Keypad { get; private set; }

        private void SetSuccessMessage() => InitialError = "완료";
        private void SetResultMessage(string msg) => InitialError = msg;

        MioPort _MioPort;

        private Action<KeypadKeys> _KeypadAction;

        public ILedSignal LedSignal { get; private set; }


        static void Main(string[] args)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        internal MioVersion _Mio1Version;
        internal MioVersion _Mio2Version;
        internal MioVersion _Mio3Version;


        private  void StartDevice()
        {
             InitDeviceAsnyc();
        }

        bool initRes = false;
        private async Task<bool> InitDeviceAsnyc()
        {
            initRes = await Initialize();
            return initRes;
        }

        public virtual async Task<bool> Initialize()
        {


            bool rv = false;

            //포트 자원해제가 늦어지는것 같아 2초 딜레이
            await Task.Delay(2000);

            var mport = "";

            //MIO 포트 검색
            var mio = new MioPort();
            rv = await mio.Open(mport);
            if (rv == false)
            {
                SetResultMessage(mio.LastError);
                mio.Dispose();
                return false;
            }

            _MioPort = mio;

            _Mio1Version = new MioVersion(DeviceID.MIO1, mio);
            _Mio2Version = new MioVersion(DeviceID.MIO2, mio);
            _Mio3Version = new MioVersion(DeviceID.MIO3, mio);

            await _Mio1Version.GetVersion();
            await _Mio2Version.GetVersion();
            await _Mio3Version.GetVersion();


            //! LED
            var led = new LedSignK300(_MioPort);
            if (await led.GetStatus())
                LedSignal = led;
            else
                LedSignal = new LedSign(_MioPort);

            //TODO LED 테스트
            //LedSignal.SetAllOn();
            LedSignal.SetAllOff();


            //! 센서
            //true = 근접센서 사용여부
            var sensor = new SensorK300(_MioPort, true);
            if (await sensor.GetStatus())
            {
                SensorUnit = sensor;
            }
            else
            {
                //x K300외 발급기 용 사용하지 않음
                //sensor.Dispose();

                //_Mio2Sensor = new Mio2Sensor(_MioPort);
                //_Mio3Sensor = new Mio3Sensor(_MioPort);
                //_Sensor = new Sensor(_MioPort);
                //_UserDetectSensor = new UserDetectSensor(_MioPort);

                //SensorUnit = new SensorUnit(_Mio2Sensor, _Mio3Sensor, _Sensor, _UserDetectSensor, _DevSettings.UseUserDetectSensor);
            }

            //! 키패드 
            //true = 사용여부
            if (true)
            {
                Keypad = new Keypad(_MioPort);
                Keypad.OnPressKeypadKey += Keypad_OnPressKeypadKey;
            }

            SetSuccessMessage();
            return true;
        }


        private void Keypad_OnPressKeypadKey(object sender, KeypadKeys e) => _KeypadAction?.Invoke(e);
        protected virtual StaplerSensorStatus GetDevStaplerSensorStatus() => null;

        public Task<bool> InitStapler() => _InitStapler(true);
        protected async Task<bool> _InitStapler(bool runInit)
        {
            var stapler = new AT2020(_MioPort);

            var sensorstatus = GetDevStaplerSensorStatus();
            if (sensorstatus != null)
                stapler.SensorStatus = sensorstatus;

            if (await stapler.GetStatus())
            {
                Stapler = stapler;

                if (runInit == false || await stapler.Init())
                {
                    SetSuccessMessage();
                    return true;
                }
                else
                {
                    SetResultMessage(stapler.LastError);
                    return false;
                }
            }
            else
                stapler.Dispose();

            Stapler = null;
            SetResultMessage("장치 연결 실패 (인증기 응답없음)");
            return false;
        }
    }
}
