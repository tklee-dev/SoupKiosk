using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Winforms = System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Threading;
using System.Reflection;
using System.Windows.Interop;
using System.Threading;


/*
 * 
 * 개발 주석처리
 * 
 * 
 - this.hide

- HID값 강제 ASCII값

- 프린터 드라이버, SFTP, 프로그램 수정사항 챙기기

 */

namespace KGClient
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string LogH { get; set; } = "TEST출력";
        public string[] serial_list = SerialPort.GetPortNames();
        public string[] PrinterNames => PrinterSettings.InstalledPrinters.Cast<string>().ToArray();

        Winforms.NotifyIcon notifyIcon;

        MioControl mioControl = new MioControl();
        PrintProcess printProcess = new PrintProcess();
        HIDControl hidControl = null;
        RegControl regControl = new RegControl();
        PDFWatcher pdfWatcher = null;
        RequestHTTP requestHTTP = new RequestHTTP();
        WindowWeb windowWeb = null;
        DispatcherTimer turnOffTimer = null;
        DispatcherTimer jsonTimer = null;
        DispatcherTimer rebootTimer = null;
        DispatcherTimer initDeviceTimer = null;
        DispatcherTimer printResponseTimer = null;
        DispatcherTimer afterPrintResponseTimer = null;
        DispatcherTimer initHIDCheckTimer = null;

        Voiceware tts = null;

        //WCF를 통해 들어온 print 요청 pdf 이름들을 저장한다.
        List<string> printRequestNames = new List<string>();
        List<string> printCurrentNames = new List<string>();
        List<string> printCurrentPath = new List<string>();


        public MainWindow()
        {
            InitializeComponent();

            #region 중복실행방지
            if (IsExistProcess(Process.GetCurrentProcess().ProcessName))
            {
                Buton_CloseProgram(null, null);
                Logger.Log("중복실행, 실행하지 않음");
            }

            bool IsExistProcess(string processName)
            {
                Process[] process = Process.GetProcesses();
                int cnt = 0;

                //프로세스명으로 확인해서 동일한 프로세스 개수가 2개이상인지 확인합니다. 
                //현재실행하는 프로세스도 포함되기때문에 1보다커야합니다.
                foreach (var p in process)
                {
                    if (p.ProcessName == processName)
                        cnt++;
                    if (cnt > 1)
                        return true;
                }
                return false;
            }
            #endregion

            hidControl = new HIDControl(this);




            //Ini컨트롤
            regControl.CreateReg();
            regControl.GetAllReg();

            //Tray형태로 넣기
            if (notifyIcon == null)
                SetNotifyIcon();

            ////!  실행 후 숨기기 ( Tray 형태로 구동 ) 테스트시 아래 주석
            this.Hide();

            //Reg값 Control에 입력
            InputSettingValues();

            //"KGAutoStart" 파일이 있을경우 자동으로 "시작"(메인프로세스) 시작
            string AutoStartFlagPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KGAutoStart");
            if (File.Exists(AutoStartFlagPath))
                Button_Start(null, null);
        }


        #region Method
        string printerName = "";

        //! Serial 이벤트: HID

        //HID 데이터 이벤트
        public void ReceivedHIDData(string hidNum)
        {
            ////! TEST
            ////hidNum = "25500001";
            //http://localhost:7001/Service1.svc/setdataHID/99
            //http://localhost:7001/Service1.svc/getdata/111?callback=222
            //lastHIDnum = hidNum.Trim();

            Logger.Log("HID 값:" + hidNum.Trim());
            string requestURL = regControl._ServerURL + "setdataHID/" + hidNum.Trim();
            requestHTTP.SetDataToServer(requestURL);
        }

        //! PDF Watcher (PDF생성시 LIST넣음,
        //! 1. 파일에 HID값이 포함안된경우 바로 삭제. ← 삭제예정
        //! 2. printRequestNames없는 값일 경우 삭제 (다른메서드에서)
        public void PDFCreated(FileSystemEventArgs e)
        {
            Logger.Log("PDF생성감지: " + e.FullPath);
            printCurrentNames.Add(System.IO.Path.ChangeExtension(e.Name, null));
            printCurrentPath.Add(e.FullPath);


        }

        public void PDFDeleted(string filePath)
        {
            Logger.Log("PDF삭제감지: " + filePath);
        }

        public async Task MainProcess()
        {
            /*  
             *  1. 포트 오픈 및 장비초기화 (1회)
             *  2. HID번호 인식 대기 및 인식시 *서버전송
             *  3. Watcher 구동 → PDF인식 → HID값 비교 *서버전송 (출력시작)
             *  4. 출력 및 인증기 프로세스 시작
             *  5. 출력 상태값 전송
             *  6. 완료
             */

            try
            {

                //TTS 생성
                var shellHwnd = new WindowInteropHelper(this).Handle;

                var shellDispatcher = Application.Current.Dispatcher;
                tts = new Voiceware(shellHwnd, shellDispatcher);

                if (IsUserInputValid())
                ////! TEST
                //if (true)
                {
                    printerName = cbPrinter.SelectedItem.ToString();
                    //! HID
                    bool res = hidControl.HID_SerialOpen(cbHID.SelectedItem.ToString());
                    if (res)
                    {
                        Logger.Log("HID 포트 오픈 성공");
                    }
                    else
                    {
                        Logger.Log("HID 포트 오픈실패");
                        MessageBox.Show("HID 포트오픈 실패");
                    }

                    //! MIO
                    res = await mioControl.InitDeviceAsnyc(cbMio.SelectedItem.ToString());
                    if (res)
                    {
                        Logger.Log("MIO 포트 오픈 성공");
                        //근접센서 이벤트
                        mioControl.SensorUnit.OnDetectUserChanged += SensorUnit_OnDetectUserChanged;
                    }
                    else
                    {
                        Logger.Log("MIO 초기화 실패");
                        MessageBox.Show("MIO 초기화 실패");
                    }

                    //! PDF Watcher
                    pdfWatcher = new PDFWatcher(this, tbPDFDir.Text);
                    Logger.Log("Watcher 구동완료" + tbPDFDir.Text);


                    //! WEB 표출            
                    windowWeb = new WindowWeb(this, tbWebURL.Text);
                    windowWeb.Show();

                    tts.Open();
                    StartRequestWCF();

                    WindowTurnOffChecker();
                }
                else
                {
                    MessageBox.Show("설정값이 입력되지 않았습니다(2)");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }

        private void SensorUnit_OnDetectUserChanged(object sender, EventArgs e)
        {
            if (IsSensorTest == true)
                MessageBox.Show("센서 감지");
            else
            {
                Logger.Log("센서감지:");
                string requestURL = regControl._ServerURL + "SetDataSensor/01";
                requestHTTP.SetDataToServer(requestURL);
            }
        }

        /// <summary>
        /// 반복하여 웹에 n초마다 요청하여 텍스트 값이 있을 경우 TTS를 재생한다. 
        /// </summary>
        private void StartRequestWCF()
        {
            //특정 초마다 호출하여 TTS를 Play한다.
            jsonTimer = new DispatcherTimer();
            jsonTimer.Interval = TimeSpan.FromMilliseconds(500);
            jsonTimer.Tick += JsonTimer_Tick;
            jsonTimer.Start();

            //특정 초마다 호출하여 Window를 Reboot한다.
            rebootTimer = new DispatcherTimer();
            rebootTimer.Interval = TimeSpan.FromMilliseconds(2000);
            rebootTimer.Tick += RebootTimer_Tick; ;
            rebootTimer.Start();

            //특정 초마다 호출하여 Mio를 중지 + 초기화 시킨다.
            initDeviceTimer = new DispatcherTimer();
            initDeviceTimer.Interval = TimeSpan.FromMilliseconds(2000);
            initDeviceTimer.Tick += InitDeviceTimer_Tick;
            initDeviceTimer.Start();

            //특정 초마다 호출하여 print요청이 있는지 확인한다.
            printResponseTimer = new DispatcherTimer();
            printResponseTimer.Interval = TimeSpan.FromMilliseconds(500);
            printResponseTimer.Tick += PrintResponseTimer_Tick; ;
            printResponseTimer.Start();

            //PrintResponseTimer에 값이 들어온 이후, 
            //5초동안 printRequestNames 값과, printCurrentNames 값을 비교하기 위한 타이머
            afterPrintResponseTimer = new DispatcherTimer();
            afterPrintResponseTimer.Interval = TimeSpan.FromMilliseconds(1000);
            afterPrintResponseTimer.Tick += AfterPrintResponseTimer_Tick;

            //HID 초기화 요청이 있는지 확인
            initHIDCheckTimer = new DispatcherTimer();
            initHIDCheckTimer.Interval = TimeSpan.FromMilliseconds(1000);
            initHIDCheckTimer.Tick += InitHIDCheckTimer_Tick;
        }

        private void InitHIDCheckTimer_Tick(object sender, EventArgs e)
        {
            //서버에서 초기화 요청시, 서버에 ""값 HID값을 전송
            string requestURL = regControl._ServerURL + "GetdataInitHID";
            InitHIDParam initHIDParam = requestHTTP.GetDataJson<InitHIDParam>(requestURL);
            if (initHIDParam.IsInitHID == "true")
            {
                Logger.Log("[JSON] HID값 초기화");
                // 서버에 빈값 HID를 전송. 
                requestURL = regControl._ServerURL + "setdataHID/" + "";
                requestHTTP.SetDataToServer(requestURL);
            }
        }

        private void PrintResponseTimer_Tick(object sender, EventArgs e)
        {
            string requestURL = regControl._ServerURL + "getdataPrint";
            PrintParamObject printParamObject = requestHTTP.GetDataJson<PrintParamObject>(requestURL);
            if (string.IsNullOrEmpty(printParamObject.printParam) == false)
            {
                Logger.Log("[JSON] 출력요청 값 있음" + printParamObject.printParam);
                printRequestNames = printParamObject.printParam.Split('^').ToList();

                tryCnt = 0;
                afterPrintResponseTimer.Start();
            }
        }

        int tryCnt = 0;
        private void AfterPrintResponseTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                List<string> _printRequestNames = new List<string>();
                List<string> _printCurrentNames = new List<string>();
                List<string> _printCurrentPath = new List<string>();

                _printRequestNames = printRequestNames;
                _printCurrentNames = printCurrentNames;
                _printCurrentPath = printCurrentPath;


                Logger.Log("PrintResponse프로세스 시작");
                if (tryCnt < 5)
                {
                    tryCnt++;

                    //의도: 실제 요청한 파일명(printRequestNames)이, 다 ftp올라와 있는지(printCurrentNames) 확인
                    _printRequestNames.Sort();
                    _printCurrentNames.Sort();
                    _printCurrentPath.Sort();
                    bool isEqual = Enumerable.SequenceEqual(_printRequestNames, _printCurrentNames);
                    if (isEqual)
                    {
                        //모두 다운로드 확인, 인쇄시작
                        afterPrintResponseTimer.Stop();
                        Logger.Log("같음");
                        //foreach (var item in printRequestNames)
                        //    Logger.Log($"printRequestNames = " + item);

                        //foreach (var item in printCurrentNames)
                        //    Logger.Log($"printCurrentNames = " + item);

                        Task.Delay(2000);
                        //출력 
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(async delegate
                        {
                            string requestURL = regControl._ServerURL + "setdataStaplerPrinter/" + "P01";
                            requestHTTP.SetDataToServer(requestURL);

                            bool res = await printProcess.PrintProc(printerName, _printCurrentPath, mioControl);
                            if (res)
                            {
                                Logger.Log("출력 완료");
                                requestURL = regControl._ServerURL + "setdataStaplerPrinter/" + "P05";
                                requestHTTP.SetDataToServer(requestURL);

                                AfterPrintWorkClear();
                            }
                            else
                            {
                                Logger.Log("출력 실패");
                                requestURL = regControl._ServerURL + "setdataStaplerPrinter/" + "P91";
                                requestHTTP.SetDataToServer(requestURL);

                                AfterPrintWorkClear();
                            }

                        }));

                    }
                    else
                    {

                        Logger.Log($"다름({tryCnt})");
                        foreach (var item in _printRequestNames)
                            Logger.Log($"printRequestNames = " + item);

                        foreach (var item in _printCurrentNames)
                            Logger.Log($"printCurrentNames = " + item);
                    }
                }
                else
                {
                    //5회 이상 시도
                    Logger.Log("PrintResponse프로세스 종료");
                    foreach (var item in _printRequestNames)
                        Logger.Log($"printRequestNames = " + item);

                    foreach (var item in _printCurrentNames)
                        Logger.Log($"printCurrentNames = " + item);

                    AfterPrintWorkClear();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }

        private void AfterPrintWorkClear()
        {
            Logger.Log("AfterPrintWorkClear()");
            printRequestNames.Clear();
            printCurrentNames.Clear();
            printCurrentPath.Clear();
            afterPrintResponseTimer.Stop();

            //파일 내 모든 파일삭제
            try
            {
                string path = tbPDFDir.Text;

                DirectoryInfo directory = new DirectoryInfo(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }

        }

        private void InitDeviceTimer_Tick(object sender, EventArgs e)
        {
            string requestURL = regControl._ServerURL + "getdataInitDevice";
            InitDeviceObject initDeviceObject = requestHTTP.GetDataJson<InitDeviceObject>(requestURL);
            if (initDeviceObject.IsInitDevice == "true")
            {
                Logger.Log("[JSON] 장비 중지+재시작");
                Button_PortClose(null, null);
                Thread.Sleep(1000);
                Button_Start(null, null);
            }
        }

        private void RebootTimer_Tick(object sender, EventArgs e)
        {
            string requestURL = regControl._ServerURL + "GetdataReboot";
            RebootObject rebootObject = requestHTTP.GetDataJson<RebootObject>(requestURL);
            if (rebootObject.IsReboot == "true")
            {
                Logger.Log("[JSON] 윈도우 재시작");
                System.Diagnostics.Process.Start("ShutDown", "-r");
            }
        }


        Queue<TTSObject> ttsObjectQueue = new Queue<TTSObject>();
        /// <summary>
        /// 일정 주기로 TTS Text 값을 가지고옴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonTimer_Tick(object sender, EventArgs e)
        {
            string requestURL = regControl._ServerURL + "GetdataTTS";
            TTSObject ttsObject = requestHTTP.GetDataJson<TTSObject>(requestURL);

            if (ttsObject.Text.Equals("STOP") || ttsObject.Text.Equals("stop"))
            {
                tts.Stop();
            }
            else if (!string.IsNullOrEmpty(ttsObject.Text))
            {
                ttsObjectQueue.Enqueue(ttsObject);

                if (ttsObjectQueue.Count > 0)
                {
                    Logger.Log("[TTS] Play");
                    //Text 변경시 바로 음성이 변경되도록 Queue에 쌓지않고 바로 재생.
                    tts.Play(ttsObjectQueue.Dequeue().Text);
                }
            }
        }








        /// <summary>
        /// n초마다 시간을 체크하여 설정된 시간 비교 윈도우를 종료한다.
        /// </summary>
        private void WindowTurnOffChecker()
        {
            if (checkUseOff.IsChecked == true)
            {
                int restartHour = Int32.Parse(tbHour.Text);
                int restartMinute = Int32.Parse(tbMinute.Text);

                Logger.Log($"윈도우 종료 사용 [{tbHour.Text}]시 [{tbMinute.Text}]분");
                DateTime restartDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, restartHour, restartMinute, 0);

                TimeSpan timer = restartDateTime - DateTime.Now;

                if (TimeSpan.Compare(timer, new TimeSpan(0)) >= 0)
                {
                    //정상
                }
                else
                {

                    //시간이 지났을 경우 다음날로
                    timer = timer.Add(new TimeSpan(24, 0, 0));
                }

                turnOffTimer = new DispatcherTimer();
                turnOffTimer.Interval = timer;
                turnOffTimer.Tick += Dt_Tick;
                turnOffTimer.Start();

            }
            else
            {
                Logger.Log("윈도우 종료 사용하지 않음.");
            }
            //시스템 종료 /s종료, /f응용프로그램 강제종료, /t 0 종료전 대기시간
            //System.Diagnostics.Process.Start("shutdown", "/s /f /t 0");
        }

        private void Dt_Tick(object sender, EventArgs e)
        {

            Logger.Log("[타이머] 윈도우 종료");
            turnOffTimer.Stop();
            //시스템 종료 /s종료, /f응용프로그램 강제종료, /t 0 종료전 대기시간
            System.Diagnostics.Process.Start("shutdown", "/s /f /t 0");


        }



        #endregion

        #region 테스트 버튼------------------------------------------------------------------------------------------------------------------------------------------------------------

        public bool IsSensorTest { get; set; } = false;
        //! 근접 센서
        private void Button_DetectedSensor(object sender, RoutedEventArgs e)
        {
            if (IsSensorTest == true)
                IsSensorTest = false;
            else
                IsSensorTest = true;
            //장비 초기화 이후 실행해야함. 
            MessageBox.Show("장비초기화 실행, 팝업 보이기: " + IsSensorTest.ToString());
        }


        //! TTS 테스트
        private async void Button_TTS테스트(object sender, RoutedEventArgs e)
        {
            //TTS 생성
            var shellHwnd = new WindowInteropHelper(this).Handle;

            var shellDispatcher = Application.Current.Dispatcher;
            tts = new Voiceware(shellHwnd, shellDispatcher);

            tts.Open();
            await tts.PlayAsync("안녕하세요. 무인민원발급기입니다.");
        }

        //! Click: 윈도우 종료 테스트
        private void Button_WindowOff(object sender, RoutedEventArgs e)
        {

            WindowTurnOffChecker();
        }

        //! Click: MIO 장비초기화
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbMio.SelectedItem.ToString()))
            {
                MessageBox.Show("MIO PORT를 선택하세요");
            }
            else
            {
                bool res = await mioControl.InitDeviceAsnyc(cbMio.SelectedItem.ToString());
                if (res)
                {
                    Logger.Log("MIO 포트 오픈 성공");
                    //근접센서 이벤트
                    mioControl.SensorUnit.OnDetectUserChanged += SensorUnit_OnDetectUserChanged;
                }
                else
                {
                    Logger.Log("MIO 초기화 실패");
                    MessageBox.Show("MIO 초기화 실패");
                }
            }
        }

        //! Click: 테스트 출력  + 인증기 배출
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (cbPrinter.SelectedItem == null)
            {
                MessageBox.Show("프린터를 선택하세요");
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                List<string> pdfPathList = new List<string>();
                pdfPathList.Add(System.IO.Path.Combine(path, "SamplePDF", "사업자등록증(에니텍시스)_전자세금계산서.pdf"));
                bool res = await printProcess.PrintProc(cbPrinter.SelectedItem.ToString(), pdfPathList, mioControl);
            }
        }


        //! Click: HID 연결
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (cbHID.SelectedItem == null)
            {
                MessageBox.Show("HID PORT를 선택하세요");
            }
            else
            {
                var res = hidControl.HID_SerialOpen(cbHID.SelectedItem.ToString());
                if (res)
                {
                    Logger.Log("HID 포트 오픈 성공");
                }
                else
                {
                    Logger.Log("HID 포트 오픈실패");
                    MessageBox.Show("HID 포트오픈 실패");
                }
            }
        }
        //! Click: HID 끊기
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            hidControl.HID_SerialClose();
        }

        //! Click: PDF Watcher
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            pdfWatcher = new PDFWatcher(this, tbPDFDir.Text);
        }
        #endregion

        #region 운영그룹------------------------------------------------------------------------------------------------------------------------------------------------------------
        //! FTP 폴더열기
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string dirPath = AppDomain.CurrentDomain.BaseDirectory;
            dirPath = tbPDFDir.Text;
            Process.Start(dirPath);
        }

        //! 프린터 상태 조회 웹 
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string url = "http://169.254.115.21/";
            var prs = new ProcessStartInfo("msedge", url);
            Process.Start(prs);
        }

        //! Click: 프로그램 종료
        private void Buton_CloseProgram(object sender, RoutedEventArgs e)
        {
            Button_PortClose(null, null);
            if (notifyIcon != null)
                notifyIcon.Dispose();
            Application.Current.Shutdown();
        }



        //! Click: Log 폴더열기
        private void Buton_OpenLogDir(object sender, RoutedEventArgs e)
        {
            string dirPath = AppDomain.CurrentDomain.BaseDirectory;
            dirPath = System.IO.Path.Combine(dirPath, "Log");
            Process.Start(dirPath);
        }

        //! Clikc: 중지
        private void Button_PortClose(object sender, RoutedEventArgs e)
        {
            if (windowWeb != null)
            {
                windowWeb.Close();
                windowWeb = null;
            }

            mioControl.Dispose();

            if (hidControl != null)
                hidControl.HID_SerialClose();
        }


        //! Click: 시작(메인프로세스)
        private async void Button_Start(object sender, RoutedEventArgs e)
        {
            await MainProcess();
        }
        #endregion

        #region 시작프로그램 등록------------------------------------------------------------------------------------------------------------------------------------------------------------


        string programName = "KGClient";
        //시작 프로그램 등록
        private void button_RegStartup(object sender, RoutedEventArgs e)
        {
            regControl.SetStartupProgram(programName, System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        //시작 프로그램 삭제
        private void button_DeleteStartup(object sender, RoutedEventArgs e)
        {
            regControl.DeleteStartupProgram(programName);
        }

        #endregion

        #region 설정 그룹------------------------------------------------------------------------------------------------------------------------------------------------------------


        //! Click: PDF경로 설정
        private void Button_PDFDirPath(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog()
            {
                InitialDirectory = "",
                IsFolderPicker = true
            };

            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tbPDFDir.Text = folderDialog.FileName;
            }
        }

        /// <summary>
        /// 기존 설정값(Reg) UI에 대입
        /// </summary>
        private void InputSettingValues()
        {

            //설정 기본값 입력 및 리스트 추가
            foreach (var printerName in PrinterNames)
            {
                cbPrinter.Items.Add(printerName);

                if (printerName.Equals(regControl._PrinterName))
                    cbPrinter.SelectedItem = printerName;
            }
            foreach (var portName in serial_list)
            {
                cbMio.Items.Add(portName);
                cbHID.Items.Add(portName);

                if (portName.Equals(regControl._MIOPort))
                    cbMio.SelectedItem = portName;
                if (portName.Equals(regControl._HIDPort))
                    cbHID.SelectedItem = portName;
            }
            tbPDFDir.Text = regControl._PDFDirPath;
            tbServerURL.Text = regControl._ServerURL;
            tbWebURL.Text = regControl._WebURL;

            if (string.IsNullOrEmpty(regControl._OffTime))
            {
                checkUseOff.IsChecked = false;
            }
            else
            {
                checkUseOff.IsChecked = true;
                button_UseOff(null, null);
                var splitedData = regControl._OffTime?.Split('^');
                tbHour.Text = splitedData[0];
                tbMinute.Text = splitedData[1];
            }

        }



        //! Click: 세팅값 저장 (Registry)
        private void Button_SaveSettings(object sender, RoutedEventArgs e)
        {
            //입력되지 않은 컨트롤이 있는지 확인
            if (IsUserInputValid() == true)
                ////! TEST
                if (true)
                {
                    regControl.ChangeReg(RegKeyNames.MIOPort, cbMio.SelectedItem.ToString());
                    regControl.ChangeReg(RegKeyNames.HIDPort, cbHID.SelectedItem.ToString());
                    regControl.ChangeReg(RegKeyNames.PrinterName, cbPrinter.SelectedItem.ToString());
                    regControl.ChangeReg(RegKeyNames.PDFDirPath, tbPDFDir.Text);
                    regControl.ChangeReg(RegKeyNames.ServerURL, tbServerURL.Text);
                    regControl.ChangeReg(RegKeyNames.WebURL, tbWebURL.Text);

                    if (checkUseOff.IsChecked == true)
                        regControl.ChangeReg(RegKeyNames.OffTime, tbHour.Text + "^" + tbMinute.Text);
                    else
                        regControl.ChangeReg(RegKeyNames.OffTime, "");
                    MessageBox.Show("저장 완료");
                }
                else
                {
                    MessageBox.Show("설정값이 입력되지 않았습니다(1)");
                }
        }


        /// <summary>
        /// 설정값 모두 입력되었는지 확인
        /// </summary>
        /// <returns>true = 모두입력, false = 입력되지 않은 값 있음</returns>
        private bool IsUserInputValid()
        {
            if (cbHID.SelectedItem != null
                && cbMio.SelectedItem != null
                && cbPrinter != null
                && !string.IsNullOrWhiteSpace(tbPDFDir.Text)
                && !string.IsNullOrWhiteSpace(tbServerURL.Text)
                && !string.IsNullOrWhiteSpace(tbWebURL.Text))
                return true;
            else
                return false;
        }



        //! Click: 종료사용 체크박스
        private void button_UseOff(object sender, RoutedEventArgs e)
        {
            if (checkUseOff.IsChecked == true)
            {
                tbHour.IsEnabled = true;
                tbMinute.IsEnabled = true;
            }
            else
            {
                tbHour.IsEnabled = false;
                tbMinute.IsEnabled = false;
            }
        }
        #endregion

        #region NotifyIcon 처리------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SetNotifyIcon()
        {
            notifyIcon = new Winforms.NotifyIcon();
            System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon();
            Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/KGClient;component/ImgResource/icons8-compute-60.ico")).Stream;
            var bitmap = new Bitmap(iconStream);
            notifyIcon.Icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
            notifyIcon.Visible = true;
            notifyIcon.Text = "KGClient";

            notifyIcon.Click += delegate (object sender, EventArgs eventArgs)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //종료되지 않도록 처리 ( 트레이 버튼으로만 종료되도록 ) 
            this.Hide();
            e.Cancel = true;
        }





        #endregion


    }
}