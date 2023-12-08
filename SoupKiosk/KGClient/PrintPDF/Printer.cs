using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class Printer : DisposeBase
    {
        public Printer(string printerName)
        {
            if (PrinterHelper.PrinterNames.Contains(printerName) == false)
                throw new ArgumentException($"프린터를 찾을 수 없음 ({printerName})");

            PrinterName = printerName;
            IsAdministratePrinter = PrinterHelper.IsNetworkPrinter(printerName) == false;
            Queue = PrinterHelper.GetPrinterQueue(this.PrinterName);
        }

        protected override void DisposeManaged()
        {
            base.DisposeManaged();
            if (Queue != null)
            {
                Queue.Dispose();
                Queue = null;
            }  
        }

        public string PrinterName { get; private set; }

        /// <summary>
        /// 설치되어 있는 프린터 목록을 가져온다.
        /// </summary>
        public static string[] PrinterNames
        {
            get { return PrinterSettings.InstalledPrinters.Cast<string>().ToArray(); }
        }

        public bool IsAdministratePrinter { get; private set; }

        public PrintQueue Queue { get; private set; }

        public PrinterSettings Setting
        {
            get
            {
                if (setting == null)
                {
                    setting = new PrinterSettings();
                    setting.PrinterName = this.PrinterName;
                }
                return setting;
            }
        }
        private PrinterSettings setting = null;

        public int JobCount
        {
            get
            {
                Queue.Refresh();
                return Queue.NumberOfJobs;
            }
        }

        /// <summary>
        /// 프린터를 일시 중지 시킨다
        /// </summary>
        public void Pause()
        {
            CheckPermission();
            Queue.Refresh();
            Queue.Pause();
        }

        /// <summary>
        /// 프린터를 계속 진행 시킨다.
        /// </summary>
        public void Resume()
        {
            CheckPermission();
            Queue.Refresh();
            Queue.Resume();
        }

        /// <summary>
        /// 모든 작업을 삭제한다.
        /// </summary>
        public void Purge()
        {
            CheckPermission();
            Queue.Refresh();
            Queue.Purge();
        }

        /// <summary>
        /// 현재 인쇄작업을 모두 가저온다.
        /// </summary>
        /// <returns></returns>
        public PrintSystemJobInfo[] EnumJobs()
        {
            Queue.Refresh();
            return Queue.GetPrintJobInfoCollection().ToArray();
        }

        public PrintSystemJobInfo GetJob(int jobId)
        {
            Queue.Refresh();
            return Queue.GetJob(jobId);
        }

        public void PauseJob(int jobId)
        {
            GetJob(jobId).Pause();
        }

        public void ResumeJob(int jobId)
        {
            GetJob(jobId).Resume();
        }

        public void CancelJob(int jobId)
        {
            GetJob(jobId).Cancel();
        }

        public void CancelAllJobs()
        {
            var jobs = EnumJobs();
            foreach (var j in jobs)
                j.Cancel();
        }

        public void RestartJob(int jobId)
        {
            GetJob(jobId).Restart();
        }

        public PaperSource[] GetPrinterTrays(bool onlyBasicTrays)
        {
            return PrinterHelper.GetInputTrays(this.PrinterName, onlyBasicTrays);
        }

        private void CheckPermission()
        {
            if (IsAdministratePrinter == false)
                throw new Exception("AdministratePrinter가 아닙니다.");
        }

        public Task<bool> CheckCreated()
        {
            throw new NotImplementedException();
        }
    }
}
