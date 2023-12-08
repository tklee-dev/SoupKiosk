using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestMio
{
    public class MioControl : IDevices
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

        bool initRes = false;
        public async Task<bool> InitDeviceAsnyc()
        {
            initRes = await Initialize();
            if (initRes == false)
            {
                MessageBox.Show("포트오픈실패");
            }
            else
            {
                MessageBox.Show("초기화 성공");

                initRes = await InitStapler();
                if (initRes == false)
                {
                    MessageBox.Show("인증기 초기화실패");
                }
                else
                {
                    MessageBox.Show("인증기 성공");
                }
            }


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


            //! LED
            var led = new LedSignK300(_MioPort);
            if (await led.GetStatus())
                LedSignal = led;
            else
                LedSignal = new LedSign(_MioPort);

            //TODO LED 테스트용
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

        public void Dispose()
        {

            //인증기
            Stapler?.Dispose();
            Stapler = null;

            //안내 LED
            LedSignal?.Dispose();
            LedSignal = null;

            //센서류
            SensorUnit?.Dispose();
            SensorUnit = null;


            //키패드
            if (Keypad != null)
            {
                _KeypadAction = null;
                Keypad.OnPressKeypadKey -= Keypad_OnPressKeypadKey;
                Keypad.Dispose();
                Keypad = null;
            }


            if (_MioPort != null)
            {
                _MioPort.Dispose();
                _MioPort = null;
            }
        }
    }
}
