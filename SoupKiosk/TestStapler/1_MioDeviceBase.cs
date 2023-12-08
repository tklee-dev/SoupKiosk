using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestStapler
{
    abstract class MioDeviceBase : NotifyPropertyChangedBase
    {

        /// <summary>
        /// 마지막 오류 내용
        /// </summary>
        public string LastError
        {
            get => _LastError;
            set => base.SetProperty(ref _LastError, value);
        }
        private string _LastError = String.Empty;

        /// <summary>
        /// 장치 오류 여부
        /// </summary>
        public bool IsError
        {
            get => _IsError;
            set => base.SetProperty(ref _IsError, value);
        }
        private bool _IsError = false;


        public DeviceID DeviceID { get; private set; }

        /// <summary>
        /// 대기자를 호출하여 응답대기를 완료한다.
        /// </summary>
        /// <param name="packet"></param>
        public virtual void OnPacketReceived(object sender, MioPacketData packet) => _DataWaitor?.Set();

        private ManualResetEvent _DataWaitor = new ManualResetEvent(true);

        protected MioPortBase Control { get; set; }

        protected Func<bool> Validation { get; private set; } = null;

        /// <summary>
        /// 기본 타임아웃(ms)
        /// (기본값 : 3초)
        /// </summary>
        public int DefaultTimeout { get; protected set; }

        protected MioDeviceBase(DeviceID devId, MioPortBase control, int defTimeout = 3000)
        {
            DeviceID = devId;
            DefaultTimeout = defTimeout;

            Control = control;
            Control.AddEventHandler(this);
        }

        protected override void DisposeManaged()
        {
            base.DisposeManaged();
            _DataWaitor?.Dispose();
            _DataWaitor = null;

            Control.RemoveEventHandler(this);
            Control = null;
        }


        /// <summary>
        /// 명령을 실행하고 Validation을 통해 정상 처리 되었는지 확인하는
        /// 패턴을 구현한다.
        /// Validation은 OnPacketReceived에서 직접 호출해줘야한다
        /// </summary>
        protected Task<T> ExcuteAsync<T>(Func<T> sendFunc, Func<bool> validFunc) =>
            Task.Run(() => Excute(sendFunc, validFunc));

        /// <summary>
        /// 명령을 실행하고 Validation을 통해 정상 처리 되었는지 확인하는 패턴을 구현한다.
        /// Validation은 OnPacketReceived에서 직접 호출해줘야한다
        /// </summary>
        protected T Excute<T>(Func<T> sendFunc, Func<bool> validFunc)
        {
            try
            {
                Validation = validFunc;
                return sendFunc();
            }
            finally
            {
                Validation = null;
            }
        }

        /// <summary>
        /// 명령을 실행하고 IsError와 Validation을 통해
        /// 정상 처리 되었는지 확인하는 패턴을 구현한다.
        /// 기본 타임아웃 사용, 재시도 3회
        /// </summary>
        protected bool ExcuteWithError(string desc, byte cmd, Func<bool> validator)
            => ExcuteWithError(() => SendRetry(desc, cmd), validator);

        /// <summary>
        /// 명령을 실행하고 IsError와 Validation을 통해
        /// 정상 처리 되었는지 확인하는 패턴을 구현한다.
        /// </summary>
        protected bool ExcuteWithError(Func<bool> sendFunc, Func<bool> validator)
        {
            IsError = false; //에러를 클리어 시키고 명령을 전송한다.
            var rv = Excute(
                () => sendFunc(),
                () => IsError || validator()); //검증값이 성공이거나 에러 발생시 중지

            if (rv == false) //타임아웃
            {
                IsError = true;
                //LastErrorMesssage = "타임아웃"; 은 Send에서 넣어준다.
                return false;
            }
            else if (IsError) //장애
            {
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 명령을 실행하고 IsError와 Validation을 통해
        /// 정상 처리 되었는지 확인하는 패턴을 구현한다.
        /// 기본 타임아웃 사용, 재시도 3회
        /// </summary>
        protected Task<bool> ExcuteWithErrorAsync(string desc, byte cmd, Func<bool> validator)
            => ExcuteWithErrorAsync(() => SendRetry(desc, cmd), validator);

        /// <summary>
        /// 명령을 실행하고 IsError와 Validation을 통해
        /// 정상 처리 되었는지 확인하는 패턴을 구현한다.
        /// </summary>
        protected async Task<bool> ExcuteWithErrorAsync(Func<bool> sendFunc, Func<bool> validator)
        {
            IsError = false; //에러를 클리어 시키고 명령을 전송한다.
            var rv = await ExcuteAsync(
                () => sendFunc(),
                () => IsError || validator()); //검증값이 성공이거나 에러 발생시 중지

            if (rv == false) //타임아웃
            {
                IsError = true;
                //LastErrorMesssage = "타임아웃"; 은 Send에서 넣어준다.
                return false;
            }
            else if (IsError) //장애
            {
                return false;
            }
            else
                return true;
        }


        #region Send Methods
        /// <summary>
        /// 패킷 전송
        /// [O] 응답대기
        /// [O] 재시도 총3회
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected bool SendRetry(string desc, params byte[] data) =>
            Send(desc, DefaultTimeout, 3, data);

        /// <summary>
        /// 패킷 전송
        /// [O] 응답대기
        /// [O] 재시도 총3회
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected bool SendRetry(string desc, int timeoutMS, params byte[] data) =>
            Send(desc, timeoutMS, 3, data);

        /// <summary>
        /// 패킷 전송
        /// [O] 응답대기
        /// [X] 재시도
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected bool SendNoRetry(string desc, params byte[] data) =>
            Send(desc, DefaultTimeout, 1, data);

        /// <summary>
        /// 패킷 전송
        /// [O] 응답대기
        /// [X] 재시도
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected bool SendNoRetry(string desc, int timeoutMS, params byte[] data) =>
            Send(desc, timeoutMS, 1, data);

        /// <summary>
        /// 패킷 전송
        /// [X] 응답대기
        /// [X] 재시도
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected void SendNoWait(string desc, params byte[] data) =>
            SendPacket(desc, data);


        /// <summary>
        /// 패킷을 전송하고 응답이 올때까지 대기한다.
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected bool Send(string desc, int retryCnt, params byte[] data) =>
            Send(desc, DefaultTimeout, retryCnt, data);

        /// <summary>
        /// 패킷을 전송하고 응답이 올때까지 대기한다.
        /// </summary>
        /// <returns>True: 전송 후 응답 받음, False: 응답을 받지 못함 </returns>
        protected bool Send(string desc, int timeoutMS, int retryCnt, params byte[] data)
        {
            for (int i = 0; i < retryCnt; i++)
            {
                _DataWaitor.Reset();

                SendPacket(desc, data);

                if (_DataWaitor.WaitOne(timeoutMS))
                    return true;
            }

            LastError = "타임아웃";
            return false;
        }

        private void SendPacket(string desc, params byte[] data) =>
            Control.SendPacket(desc, DeviceID.PC, DeviceID, data);
        #endregion
    }








}
