using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KGClient
{

    // PDF를 출력 메인 프로세스 프린트 + 인증기 컨트롤 포함 전체 프로세스를 담당함
    public class PrintProcess
    {
        protected string LogH { get; set; } = "PrintProcess.cs";

        public PrintProcess()
        {

        }

        public async Task<bool> PrintProc(string printerName, List<string> pdfPathList, MioControl mioControl, bool? useStapler)
        {
            bool _useStapler = false;
            if (useStapler == true)
                _useStapler = true;
            else
                _useStapler = false;



            //todo Logger.LogH(LogH, $"{certIndex}번 증명서 출력 시작 - {item.CertName}, 신청부수 {item.Copies}");
            try
            {
                var prnControl = new PrinterControl(printerName);

                Logger.LogH(LogH, $"기본 프린터 변경 - {printerName}");
                //기본 프린터 설정
                if (await prnControl.SetDefaultPrinter() == false)                 //첫화면으로 복귀 가능
                {
                    //todo await ErrorProc(model, ErrorStatus.Prn_프린터설정실패, "");
                    return false;
                }

                Logger.Log(LogH, "인쇄 초기화");

                //! K사는 무조건 1장으로 가정

                Logger.LogH(LogH, "인증기 준비 작업 요청");

                var prv1 = await mioControl.Stapler.BeginPrint(pdfPathList.Count);
                //var prv = await _Stapler.BeginPrint(i);
                if (prv1 != PrintingResults.Success)
                {
                    //todo 실패시 처리
                    //_CanMoveHomeWhenError = false; //인증기 관련 장애시 첫화면으로 돌아가면 안됨
                    //Logger.DevErrorH(LogH, $"인증기 설정 - 실패: {_Stapler.ErrorStatus.GetCode()}, {_Stapler.ErrorStatus.GetDescription()}");
                    //await ErrorProc(model, _Stapler.ErrorStatus, _Stapler.LastError);
                    return false;
                }


                Logger.LogH(LogH, $"1부 인쇄 시작 {pdfPathList.Count}장");

                Logger.LogH(LogH, "프린터 작업 삭제 및 일시 중지");
                //! 프린터 작업 삭제 및 일시 중지
                if (await prnControl.InitPrinter() == false)
                {
                    //실패시
                    return false;
                }

                //! 프린트 출력 작업 #######################################################
                Logger.Log(LogH, "인쇄 작업 요청");
                Print print = new Print();
                int printResult = await print.PrintFileAsync(pdfPathList);
                if (printResult > 0)
                {
                    Logger.Log("출력 - 성공");
                    //MessageBox.Show("출력 - 성공");   
                }
                else
                {
                    Logger.Log("출력 - 실패");
                    //MessageBox.Show("출력 - 실패");
                    return false;
                }


                //테스트용으로 XPS 프린터를 사용할 경우 일시중지 되어 있어도
                //바로 출력이 되기 때문에 인쇄 작업 갯수를 확인하면 안된다.
                if (prnControl.PrinterName.ToUpper().Contains("XPS Document Writer".ToUpper()) == false)
                {
                    Logger.LogH(LogH, "생성된 인쇄 작업 갯수 확인");
                    //출력한 문서가 프린터 큐에 생성되었는지 검증

                    int jobcnt = 0;

                    //인쇄 스풀러에 문서가 늦게 올라올수 있어서 5초동안 시도해본다.
                    for (int j = 0; j < 5; j++) //
                    {
                        jobcnt = await prnControl.JobCount();
                        if (jobcnt > 0)
                            break;

                        await Task.Delay(1000);
                    }

                    Logger.LogH(LogH, "생성된 인쇄 작업 갯수 :" + jobcnt);

                    if (jobcnt == 0)
                        await ErrorProc("출력 문서 생성 실패", "프린터 작업이 생성되지 않았습니다.");
                    else if (jobcnt < 0)
                    {
                        //var msg = GetMessage("출력문서 생성 확인 실패", model.LastErrorMesage);
                        //await ErrorProc(model, msg.msg, msg.vmsg);
                    }
                }


                ////bool useStapler = false;
                ////if (pdfPathList.Count > 1)
                ////    useStapler = true;
                ////else
                ////    useStapler = false;

                Logger.DevH(LogH, $"인증기 페이지 설정 - {pdfPathList.Count} 장");
                //인증기 명령
                //if (await _Stapler.SetPageAsync(model.BasicInfo.NumberOfPages, model.BasicInfo.NumberOfPages > 1) == false)
                //! 인증기 설정 ( 장수 1: (테스트) , Stapler사용 여부)

                if (await mioControl.Stapler.SetPageAsync(pdfPathList.Count, _useStapler) == false)
                {
                    //todo 인증기 설정 실패시 
                    //Logger.DevErrorH(LogH, $"인증기 페이지 설정 - 실패: {_Stapler.ErrorStatus.GetCode()}, {_Stapler.ErrorStatus.GetDescription()}");
                    //await ErrorProc(model, _Stapler.ErrorStatus, _Stapler.LastError);
                    Logger.DevErrorH(LogH, $"인증기 페이지 설정 - 실패: {mioControl.Stapler.ErrorStatus.GetCode()}, {mioControl.Stapler.ErrorStatus.GetDescription()}");
                    //await ErrorProc(model, mioControl.Stapler.ErrorStatus, mioControl.Stapler.LastError);
                    return false;
                }

                Logger.LogH(LogH, "프린터 일시중지 해제");
                //! 프린터 일시중지 해제
                if (await prnControl.ResumePrinter() == false)
                {
                    //todo 일시중지 (재기동 실패시) 
                    //첫화면으로 복귀 가능
                    //await ErrorProc(model, ErrorStatus.Prn_프린터설정실패, "");

                    return false;
                }

                Logger.DevH(LogH, $"인증기 출력 대기");
                //! 인쇄 완료까지 대기
                if (await mioControl.Stapler.WaitWorking() == false)
                {
                    //todo 실패 처리
                    //Logger.DevErrorH(LogH, $"인증기 출력 - 실패: {mioControl.Stapler.ErrorStatus.GetCode()}, {mioControl.Stapler.ErrorStatus.GetDescription()}");
                    //await ErrorProc(model, mioControl.Stapler.ErrorStatus, mioControl.Stapler.LastError);
                    return false;
                }
                else
                    Logger.DevH(LogH, $"인증기 출력 완료");

                bool needPayment = false;
                bool needDispense = false;

                //! 용지 배출 확인 ( 1부로 세팅함 테스트 ) 
                prv1 = await mioControl.Stapler.AfterPrint(1, 1, 1, true);
                if (prv1 == PrintingResults.Success)
                {
                    // 회수기가 없을 경우
                    needPayment = true; // 수수료는 정산하고
                    needDispense = false; // 따로 배출 처리할 필요는 없다.
                }
                else if (prv1 == PrintingResults.LastCopyOrNeedDipense)
                {
                    // 마지막 부수 이거나 적재되어 있는 증명서를 배출해야한다.
                    needPayment = true; // 적재되어있는 증명서 수수료를 정산하고
                    needDispense = true; // 증명서를 배출한다.
                }
                else if (prv1 == PrintingResults.StackedDocument)
                {
                    // 증명서가 회수기에 적재 되었다.
                    needPayment = false; // 수수료 정산 필요없고
                    needDispense = false; // 배출도 필요없다.
                }
                else
                {
                    Logger.DevErrorH(LogH, $"인증기 완료 - 실패: {mioControl.Stapler.ErrorStatus.GetCode()}, {mioControl.Stapler.ErrorStatus.GetDescription()}");
                    // await ErrorProc(model, mioControl.Stapler.ErrorStatus, mioControl.Stapler.LastError);
                    return false;
                }

                // Logger.LogH(LogH, $"1부 출력 완료- 정산처리: {needPayment}, 배출처리:{needDispense}");
                Logger.LogH(LogH, $"1부 출력 완료");

                //! 용지 배출
                //prv1 = await mioControl.Stapler.AfterPrint(0, 0, 0, true);
                if (await AfterPrintResultProc(prv1) == false)
                    return false;


                //await base.MessageService.CloseMessage();

                mioControl.LedSignal.OnPaperGate = false;



                var sw = Stopwatch.StartNew();

                mioControl.LedSignal.OnPaperGate = true;

                //인쇄 완료 메시지 표시

                var ts = sw.Elapsed.TotalSeconds;
                if (ts < 5)
                    await Task.Delay((5 - (int)ts) * 1000);


                mioControl.LedSignal.OnPaperGate = false;


                // }
                //H/W대기 시간을 위해 1초 딜레이
                await Task.Delay(1000);
            }
            //}
            catch (Exception ex)
            {
                Logger.Log(ex);
                var msg = GetMessage("인쇄 중 예기치 못한 오류 발생", ex.Message);
            }


            return true;

            async Task<bool> AfterPrintResultProc(PrintingResults prnResult)
            {
                if (prnResult == PrintingResults.Success)
                    return true;

                //오류 발생시 배출구 LED를 꺼준다.
                mioControl.LedSignal.OnPaperGate = false;
                Logger.DevErrorH(LogH, $"용지 배출 - 실패: {mioControl.Stapler.ErrorStatus.GetCode()}, {mioControl.Stapler.ErrorStatus.GetDescription()}");
                await ErrorProc(mioControl.Stapler.ErrorStatus, mioControl.Stapler.LastError);

                return false;
            }
        }

        private (string msg, string vmsg) GetMessage(string msg, string innerMsg = "")
        {
            if (String.IsNullOrWhiteSpace(innerMsg))
                return ($"{msg}", $"{msg}.");
            else
                return ($"{msg}\r\n({innerMsg})", $"{msg}, {innerMsg}.");
        }


        private async Task ErrorProc(ErrorStatus error, string lastError)
        {
            //todo 에러처리
            //var msg = Utilities.DeviceErrorToMessage(error, lastError);

            ////첫화면으로 갈 수 없는 장애는 등록한다.
            //if (_CanMoveHomeWhenError == false)
            //    _ = Task.Run(() => _StatusModel.RegisterKioskStatus(msg.serverMsg, error));

            //await ErrorProc(model, msg.msg, msg.vmsg, msg.code);
        }

        private async Task ErrorProc(string msg, string vmsg, string code = "")
        {

        }
    }
}
