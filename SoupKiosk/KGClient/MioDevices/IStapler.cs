using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public enum StaplerType
    {
        /// <summary>
        /// 미디어솔루션
        /// </summary>
        IS2008,
        /// <summary>
        /// AT6000
        /// </summary>
        AT2004,
        /// <summary>
        /// K100, K200
        /// </summary>
        AT2010,
        /// <summary>
        /// K300
        /// </summary>
        AT2020
    }
    public interface IStapler : IDisposable
    {
        string LastError { get; }

        string PortName { get; }
        bool IsOpen { get; }

        StaplerType StaplerType { get; }

        /// <summary>
        /// 현재 에러 상태인지 여부
        /// </summary>
        bool IsError { get; }

        ErrorStatus ErrorStatus { get; }

        /// <summary>
        /// 현재 출력 장수
        /// </summary>
        int InputedPaper { get; }

        /// <summary>
        /// 목표 장수
        /// </summary>
        int TotalDestPaper { get; }

        /// <summary>
        /// 현재 스택 되어있는 장수
        /// </summary>
        int StackedPageCount { get; }

        /// <summary>
        /// 2번 용지함 용지 부족
        /// </summary>
        bool IsPaperEmpty2 { get; }

        /// <summary>
        /// 3번 용지함 용지 부족
        /// </summary>
        bool IsPaperEmpty3 { get; }

        /// <summary>
        /// 왼쪽 호침 부족
        /// </summary>
        bool IsStapleEmptyL { get; }

        /// <summary>
        /// 오른쪽 호침 부족
        /// </summary>
        bool IsStapleEmptyR { get; }

        /// <summary>
        /// 펌웨어 버전
        /// </summary>
        string Version { get; }

        /// <summary>
        /// 현재 인쇄 처리 중 여부
        /// </summary>
        bool IsWorking { get; }

        /// <summary>
        /// 문서 회수 사용 여부
        /// </summary>
        bool UseDocCollect { get; set; }

        /// <summary>
        /// 회수기 최대 적재 용량
        /// </summary>
        int MaxStackCount { get; set; }

        /// <summary>
        /// 사용자 문서 회수까지 타임아웃
        /// </summary>
        int TimeoutGetDocument { get; set; }

        /// <summary>
        /// 인증기 포트 열기
        /// </summary>
        /// <returns></returns>
        Task<bool> Open(string portName = "");

        /// <summary>
        /// 인증기 닫기
        /// </summary>
        void Close();

        /// <summary>
        /// 인증기 기화
        /// </summary>
        Task<bool> Init();

        /// <summary>
        /// 현재 상태 조회
        /// </summary>
        Task<bool> GetStatus();

        /// <summary>
        /// 인쇄 준비 요청
        /// </summary>
        /// <param name="currentCopy">현재출력부수</param>
        /// <returns></returns>
        Task<PrintingResults> BeginPrint(int currentCopy);

        /// <summary>
        /// 인증 명령
        /// </summary>
        Task<bool> SetPageAsync(int page, bool useStaple);

        /// <summary>
        /// 인쇄 완료시까지 대기
        /// </summary>
        Task<bool> WaitWorking();

        /// <summary>
        /// 현재 작동 상태
        /// </summary>
        (bool isworking, int remain, int total) WorkingStatus();

        /// <summary>
        /// 1부 인쇄 완료 처리
        /// 회수기 사용할 경우 excuteDispense = false로 호출해서
        /// 다음부수 출력 가능 여부화인하고 필요할 경우 
        /// excuteDispense = true로 재호출한다.
        /// excuteDispense = true일경우 nextpage, currentCopy, totalCopy 값과 관계없이 배출한다.
        /// </summary>
        /// <param name="nextpage">다음 출력 장부</param>
        /// <param name="currentCopy">현재 부수</param>
        /// <param name="totalCopy">총 부수</param>
        /// <param name="excuteDispense">회수기 용량 부족시 용지 배출 실행 여부</param>
        /// <returns></returns>
        Task<PrintingResults> AfterPrint(int nextpage, int currentCopy, int totalCopy, bool excuteDispense);

        /// <summary>
        /// 인쇄 완료 처리
        /// </summary>
        Task<PrintingResults> AfterPrintAll();
    }
}
