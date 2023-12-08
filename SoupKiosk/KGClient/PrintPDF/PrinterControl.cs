using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class PrinterControl : DisposeBase
    {
        public string PrinterName { get; private set; }

        public PrinterControl(string printerName)
        {
            PrinterName = printerName;
            Printer = new Printer(printerName);
        }

        protected override void DisposeManaged()
        {
            base.DisposeManaged();
            if (Printer != null)
            {
                Printer.Dispose();
                Printer = null;
            }
        }

        public Printer Printer { get; private set; }

        public string LastErrorMessage { get; private set; }

        /// <summary>
        /// 현재 프린터를 기본 프린터로 변경 한다.
        /// </summary>
        public async Task<bool> SetDefaultPrinter()
        {
            return await ExcuteAndRetry(() =>
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(PrinterName))
                        throw new Exception("프린터명이 공백으로 설정됨");

                    PrinterHelper.SetDefaultPrinter(PrinterName);

                    if (String.Equals(PrinterName, PrinterHelper.DefaultPrinterName) == false)
                        throw new Exception("기본 프린터 설정 실패");

                    return true;
                }
                catch (Exception ex)
                {
                    LastErrorMessage = ex.Message;
                    return false;
                }
            });
        }

        /// <summary>
        /// 프린터를 일시중지 시키고 작업이 존재할 경우 삭제 시킨다.
        /// </summary>
        public async Task<bool> InitPrinter()
        {
            return await ExcuteAndRetry(async () =>
            {
                try
                {
                    Printer.Pause();

                    if (await DelAllJobs() == false)
                        throw new Exception("작업 삭제 실패");

                    return true;
                }
                catch (Exception ex)
                {
                    LastErrorMessage = ex.Message;
                    return false;
                }
            });
        }

        /// <summary>
        /// 프린터 일시중지를 해제 시킨다.
        /// </summary>
        public async Task<bool> ResumePrinter()
        {
            return await ExcuteAndRetry(() =>
            {
                try
                {
                    Printer.Resume();
                    return true;
                }
                catch (Exception ex)
                {
                    LastErrorMessage = ex.Message;
                    return false;
                }
            });
        }

        /// <summary>
        /// 프린터를 일시중지 시킨다.
        /// </summary>
        public async Task<bool> PausePrinter()
        {
            return await ExcuteAndRetry(() =>
            {
                try
                {
                    Printer.Pause();
                    return true;
                }
                catch (Exception ex)
                {
                    LastErrorMessage = ex.Message;
                    return false;
                }
            });
        }

        /// <summary>
        /// 프린터 작업 목록 갯수
        /// </summary>
        public async Task<int> JobCount()
        {
            int result = -1;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    result = Printer.JobCount;
                    break;
                }
                catch (Exception ex)
                {
                    LastErrorMessage = ex.Message;
                }

                await Task.Delay(1000);
            }
            return result;
        }

        /// <summary>
        /// 인쇄 작업을 모두 삭제한다.
        /// </summary>
        public async Task<bool> DelAllJobs()
        {
            try
            {
                int purgeCnt = 0;
                while (Printer.JobCount > 0)
                {
                    if (purgeCnt == 10)
                        return false;

                    purgeCnt++;
                    Printer.Purge();
                    await Task.Delay(3000);
                }
                return true;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return false;
            }
        }

        private async Task<bool> ExcuteAndRetry(Func<Task<bool>> func, int retryCnt = 3)
        {
            bool result = false;

            for (int i = 0; i < retryCnt; i++)
            {
                result = await func();
                if (result)
                    break;

                await Task.Delay(1000);
            }

            return result;
        }

        private async Task<bool> ExcuteAndRetry(Func<bool> func, int retryCnt = 3)
        {
            bool result = false;

            for (int i = 0; i < retryCnt; i++)
            {
                result = func();
                if (result)
                    break;

                await Task.Delay(1000);
            }

            return result;
        }
    }
}
