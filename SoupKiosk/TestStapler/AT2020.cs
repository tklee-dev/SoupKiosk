using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestStapler
{
    class AT2020 : MioDeviceBase, IStapler
    {
        public StaplerType StaplerType { get; } = StaplerType.AT2020;

        private readonly byte[] CMD_STATUS = { (byte)'0', JelLib.Converter.ToFlipByte('0') };
        private readonly byte[] CMD_RESET = { (byte)'R', JelLib.Converter.ToFlipByte('R') };
        private readonly byte[] CMD_TEST = { (byte)'T', JelLib.Converter.ToFlipByte('T') };
        private readonly byte[] CMD_SOMO = { (byte)'P', JelLib.Converter.ToFlipByte('P') };
        private readonly byte[] CMD_FUNCTION_TEST = { (byte)'3' };
        private readonly byte[] CMD_AUTH = { (byte)'@' };
        private readonly byte[] CMD_FEEDER = { 0x50, JelLib.Converter.ToFlipByte(0x50) };
        private readonly byte[] CMD_NON_FEEDER = { 0x51, JelLib.Converter.ToFlipByte(0x51) };

        //public readonly byte PB_OPEN_DOOR_CMD = (byte)'6';//‘6’	회수기 문을 연다
        //public readonly byte PB_CLOSE_DOOR_CMD = (byte)'Z';//‘Z’	회수기 문을 닫는다
        //public readonly byte PB_MOVE_DOOR_PAPERBACK_CMD = (byte)'7';//‘7’	회수기 문을 문서회수 위치로 이동한다.
        public readonly byte PB_PAPER_OUTPUT_CMD = (byte)'1';//‘1’	피더를 올리고 용지를 배출
        public readonly byte PB_BACK_FEEDER_CMD = (byte)'2';//‘2’	피더를 원위치로 들어올림
        //public readonly byte PB_MOVE_PAPERBACK_CMD = (byte)'8';//‘8’	용지 원위치로 빨아들임(반달)
        //public readonly byte PB_DROP_PAPER_CMD = (byte)'9';//‘9’	용지를 회수통으로 떨어뜨린다.(반달)
        //public readonly byte PB_CLOSE_DOOR_MOVEBACK_FEEDER_CMD = (byte)'C';//‘C’	회수기 문을 닫고 피더를 원위치 한다.
        public readonly byte PB_CHECK_PAPER_CMD = (byte)'F';

        #region 미사용 항목. MIO를 통하기 때문에 포트 관련 메서드 및 프로퍼티는 사용하지 않는다.

        public string PortName => String.Empty;
        public bool IsOpen => true;
        public void Close() { }

        #endregion

        public ErrorStatus ErrorStatus { get; private set; }

        public int InputedPaper => SensorStatus.InputCount;

        public int TotalDestPaper => SensorStatus.DestCount;

        public int StackedPageCount { get; private set; }

        public bool IsPaperEmpty2 => SensorStatus.IsEmptyPaper2;

        public bool IsPaperEmpty3 => SensorStatus.IsEmptyPaper3;

        public bool IsStapleEmptyL => SensorStatus.IsEmptyStapleL;

        public bool IsStapleEmptyR => SensorStatus.IsEmptyStapleR;

        public string Version => SensorStatus.Version;

        public bool IsWorking { get; private set; } = false;

        /// <summary>
        /// 회수기능 사용 여부
        /// </summary>
        public bool UseDocCollect { get; set; } = true;

        /// <summary>
        /// 회수기 최대 적재용량
        /// </summary>
        public int MaxStackCount { get; set; } = 30;

        /// <summary>
        /// 사용자 문서 회수 타임아웃
        /// </summary>
        [Obsolete("이 장치에서는 사용되지 않습니다.")]
        public int TimeoutGetDocument { get; set; } = 180;

        public StaplerSensorStatus SensorStatus { get; internal set; } = new StaplerSensorStatus();

        private AT2020_DATA _Packet;

        private AutoResetEvent _ReceivedSignal = new AutoResetEvent(false);

        public AT2020(MioPort control)
            : base(DeviceID.STAPLE_MACHINE, control, 3000)
        { }

        protected override void DisposeManaged()
        {
            base.DisposeManaged();

            _ReceivedSignal?.Dispose();
            _ReceivedSignal = null;
        }

        public Task<bool> Open(string portName = "") => Task.FromResult(true);

        public Task<bool> Init() => Task.Run(() => _Init());

        private bool _Init()
        {
            IsError = false;
            _ReceivedSignal?.Reset();

            //초기화 응답이 오기까지 대략 2.2초 소요됨
            var rv = Excute(() => Send("초기화", 3000, 2, CMD_RESET), () => SensorStatus.IsDoingReset);

            if (rv == false)
                return false;

            var sw = Stopwatch.StartNew();
            //초기화 완료 될때까지 60초 대기한다.
            while (true)
            {
                if (sw.Elapsed.TotalSeconds > 60)
                {
                    //60초 동안 초기화 안되면 오류 처리
                    MioLogger.Log(DeviceID, "초기화 60초 경과 - 오류 처리");
                    break;
                }
                else if (_ReceivedSignal?.WaitOne(10000) == false)
                {
                    //10초 동안 인증기에서 아무 신호 안올라오면 오류 처리
                    //K100인증기 속도가 느려서 오류 대기를 3초에서 10초로 늘림
                    MioLogger.Log(DeviceID, "초기화 완료 안되었는데 3초 동안 응답 없음 - 오류 처리");
                    break;
                }
                else if (isCompleted(_Packet))
                {
                    MioLogger.Log(DeviceID, $"초기화 완료");
                    return true;
                }
            }

            ErrorStatus = SensorStatus.GetResetStatus(true);
            if (ErrorStatus == ErrorStatus.Normal)
                ErrorStatus = ErrorStatus.Stapler_Init_Error;

            LastError = ErrorStatus.GetDescription();

            MioLogger.Log(DeviceID, $"초기화 실패 - {LastError ?? ""}");

            if (String.IsNullOrWhiteSpace(LastError))
                LastError = "인증기 초기화 실패";

            return false;

            bool isCompleted(AT2020_DATA packet)
            {
                return packet.CMD == 0x06 &&
                    packet.Status1 == 0x00 &&
                    packet.Status2 == 0x00 &&
                    packet.Sensor1 == 0x80 &&
                    (packet.Sensor2 & 0x45) == 0x45 && //AT2004와 다름
                                                       //data.Sensor3 == 0x08 && // 반달에 홈센서에 잘 감지 안됨
                    (packet.Motor == 0x00 || packet.Motor == 0x02) &&
                    packet.Error1 == 0x00 &&
                    packet.Error2 == 0x00 &&
                    packet.Error3 == 0x00 &&
                    packet.MotorError == 0x00 &&
                    packet.MIO4Status == 0x00 && //회수기 없음
                    packet.DestPaperCount == 0x00 &&
                    packet.PaperCount == 0x00;
            }
        }

        public async Task<bool> SetPageAsync(int page, bool useStaple)
        {
            //인증기 상태를 먼저 요청한다.
            if (await GetStatus() == false || IsError)
                return false;

            var rv = await ExcuteWithErrorAsync(() => SendRetry("인증요청", genSetPageBuf()),
                () => SensorStatus.IsIdle == false && SensorStatus.InputCount == 0 && SensorStatus.DestCount == page);


            IsWorking = rv;

            return rv;

            byte[] genSetPageBuf()
            {
                List<byte> cmd = new List<byte>();
                cmd.AddRange(CMD_AUTH);
                cmd.Add((byte)page);// 급지매수
                cmd.Add((byte)(useStaple ? 0x01 : 0x00));
                cmd.Add(0x00); // 천공
                cmd.Add(0x00); // 직인
                cmd.Add(0x00); // 직인방법
                cmd.Add(0x00); // 직인위치
                cmd.Add(0x00); // 용지선택 (0x00 :A4, 0x01: A5)
                cmd.Add(0x00); // 예비1
                cmd.Add(0x00); // 예비2
                cmd.Add(0x00); // 예비3
                return cmd.ToArray();
            }
        }

        public Task<bool> GetStatus() => ExcuteAsync(
                () => SendRetry("상태 요청", 1000, CMD_STATUS), null);

        public Task<bool> WaitWorking() => Task.Run(() => _WaitWorking());

        private bool _WaitWorking()
        {
            while (true)
            {
                if (InputedPaper == TotalDestPaper && SensorStatus.IsIdle && SensorStatus.IsMortorStoppedAll())
                {
                    IsWorking = false;
                    StackedPageCount += InputedPaper;
                    return true;
                }
                else if (IsError)
                {
                    return false;
                }

                Thread.Sleep(1000);
            }
        }

        public (bool isworking, int remain, int total) WorkingStatus()
        {
            if (IsError)
            {
                IsWorking = false;
                return (false, SensorStatus.DestCount, SensorStatus.DestCount);
            }
            else
            {
                if (IsWorking == false)
                    return (false, 0, TotalDestPaper);

                var remain = TotalDestPaper - InputedPaper;

                if (remain > 0)
                {
                    return (true, remain, TotalDestPaper);
                }
                else
                {
                    if (InputedPaper == TotalDestPaper && SensorStatus.IsIdle && SensorStatus.IsMortorStoppedAll())
                    {
                        IsWorking = false;
                        return (false, 0, TotalDestPaper);
                    }
                    else
                        return (true, 1, TotalDestPaper);

                }
            }
        }

        /// <summary>
        /// 인쇄 준비, 회수기의 용지 수량 확인하여 용지 배출
        /// </summary>
        public async Task<PrintingResults> BeginPrint(int currentCopy)
        {
            //마지막 출력 후 피더가 내려간 상태이기 때문에 피더를 올려줘야한다.
            if (await Task.Run(() => FeederMoveHome()) == false)
                return PrintingResults.PbMachineError;

            if (UseDocCollect == false)
            {
                StackedPageCount = 0;
                //회수 기능을 사용하지 않을 경우
                //회수기 문을 열고 피더를 위로 올린다.
                return PrintingResults.Success;
            }
            else
            {
                if (currentCopy <= 1)
                    StackedPageCount = 0;

                return PrintingResults.Success;
            }
        }

        /// <summary>
        /// 회수기 미사용 또는 외부 증명일 경우 바로 NeedOutputDocument을 리턴하면 문서를 배출할 수 있도록 한다.
        /// </summary>
        public async Task<PrintingResults> AfterPrint(int nextpage, int currentCopy, int totalCopy, bool excuteDispense)
        {
            if (UseDocCollect == false)
            {
                if (excuteDispense)
                {
                    //회수 기능을 사용하지 않으면 무조건 용지를 배출한다.
                    if (await Task.Run(() => DocumentDispense()))
                    {
                        //용지가 완전히 배출될때까지 일정시간 대기한다.
                        //용지가 나갈때까지 대기하지 않으면 인증기로 다음 명령이 전송되며
                        //용지 배출 작동이 멈춘다.
                        //펌웨어 5.x는 빠른 모터
                        //펌웨어 2.x는 느린 모터
                        var delay = 10000;
                        if (double.TryParse(Version, out double ver) && ver >= 5.0)
                            delay = 3000;

                        await Task.Delay(delay);
                        return PrintingResults.Success;
                    }
                    else
                        return PrintingResults.PbMachineError;
                }
                else
                    return PrintingResults.LastCopyOrNeedDipense;
            }
            else
            {
                //문서를 배출하고 수령할때까지 대기한다.
                if (excuteDispense)
                {
                    StackedPageCount = 0;
                    if (await Task.Run(() => DocumentDispense()) == false)
                        return PrintingResults.PbMachineError;
                    else
                        return PrintingResults.Success;
                }

                //마지막 부수일 경우 용지를 무조건 배출해야한다.
                if (currentCopy >= totalCopy) //
                    return PrintingResults.LastCopyOrNeedDipense;

                //적재 장수 + 다음출력 장수가 적재용량보다 작거나 같으면 정상
                if ((StackedPageCount + nextpage) <= MaxStackCount)
                    return PrintingResults.StackedDocument;
                else
                    return PrintingResults.LastCopyOrNeedDipense;
            }
        }

        /// <summary>
        /// 모든 발급이 완료 되었다.
        /// 증명서를 배출 및 시간 초과시 회수한다. (피터 모드는 게이트를 닫는다)
        /// </summary>
        public Task<PrintingResults> AfterPrintAll() =>
            Task.FromResult(PrintingResults.Success);

        /// <summary>
        /// 피더를 이용하여 용지 배출
        /// </summary>
        public bool DocumentDispense()
        {
            var rv = ExcuteWithError(
               () => SendRetry("피더 용지 배출", 10000, PB_PAPER_OUTPUT_CMD),
               () => SensorStatus.IsHomeFeederDown);

            //피더가 다운되고 용지를 밀어내는 시간이 있어 2초 대기한다.
            if (rv)
                Thread.Sleep(2000);

            return rv;
        }


        /// <summary>
        /// 피더 홈으로 이동 (Up)
        /// </summary>
        public bool FeederMoveHome()
        {
            //피더가 이미 홈위치에 있는 경우 응답을 하지 않는다.
            if (SensorStatus.IsHomeFeederUp == false)
            {
                return ExcuteWithError(
                    () => SendRetry("피더 홈", 10000, PB_BACK_FEEDER_CMD),
                    () => SensorStatus.IsHomeFeederUp);
            }
            else
                return true;
        }

        public override void OnPacketReceived(object sender, MioPacketData packet)
        {
            try
            {
                _Packet = new AT2020_DATA(packet.Message);
                SensorStatus.Set(_Packet);

                //에러 메시지 중복 업데이트를 막자
                if (IsError == false && SensorStatus.IsError)
                {
                    IsError = true;
                    ErrorStatus = SensorStatus.ErrorStatus;
                    LastError = ErrorStatus.GetDescription();
                }

                var rv = Validation?.Invoke();

                //_Validation이 null 이거나 
                //검증 결과가 True이면 대기 해제
                if (rv.HasValue == false || rv.Value)
                    base.OnPacketReceived(sender, packet);

                _ReceivedSignal?.Set();
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 수신 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
            }
        }
    }
}
