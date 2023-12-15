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

        public MainWindow()
        {
            InitializeComponent();          
            hidControl = new HIDControl(this);

            //Ini컨트롤
            regControl.CreateReg();
            regControl.GetAllReg();

            //Tray형태로 넣기
            if (notifyIcon == null)
                SetNotifyIcon();

            //! 실행 후 숨기기 ( Tray 형태로 구동 ) 테스트시 주석
            this.Hide();





            #region 기존 설정값(Reg)을 설정UI에 대입
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
            #endregion



            string AutoStartFlagPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KGAutoStart");
            if (File.Exists(AutoStartFlagPath))
            {
                //!  "KGAutoStart" 파일이 있을경우 자동으로 "시작"(메인프로세스) 시작
                Button_Start(null, null);
            }


            //todo 1. 자동 "시작" 되도록 
            //todo 2. FTP 서버 구성
            //todo 3. IIS 설정
        }

        #region NotifyIcon 처리
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

        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //종료되지 않도록 처리 ( 트레이 버튼으로만 종료되도록 ) 
            this.Hide();
            e.Cancel = true;
        }




        #region 테스트 버튼


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
                string pdfFilePath = System.IO.Path.Combine(path, "SamplePDF", "사업자등록증(에니텍시스)_전자세금계산서.pdf");
                bool res = await printProcess.PrintProc(cbPrinter.SelectedItem.ToString(), pdfFilePath, mioControl);
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



        //! Click: 프로그램 종료
        private void Buton_CloseProgram(object sender, RoutedEventArgs e)
        {

            Button_PortClose(null, null);
            notifyIcon.Dispose();
            Application.Current.Shutdown();

        }

        //! Click: 세팅값 저장 (Registry)
        private void Button_SaveSettings(object sender, RoutedEventArgs e)
        {
            //입력되지 않은 컨트롤이 있는지 확인
            if (IsUserInputValid() == true)
            {
                regControl.ChangeReg(RegKeyNames.MIOPort, cbMio.SelectedItem.ToString());
                regControl.ChangeReg(RegKeyNames.HIDPort, cbHID.SelectedItem.ToString());
                regControl.ChangeReg(RegKeyNames.PrinterName, cbPrinter.SelectedItem.ToString());
                regControl.ChangeReg(RegKeyNames.PDFDirPath, tbPDFDir.Text);
                regControl.ChangeReg(RegKeyNames.ServerURL, tbServerURL.Text);
                regControl.ChangeReg(RegKeyNames.WebURL, tbWebURL.Text);

                MessageBox.Show("저장 완료");
            }
            else
            {
                MessageBox.Show("설정값이 입력되지 않았습니다(1)");
            }
        }

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





        string printerName = "";

        //! Click: 시작(메인프로세스)
        private async void Button_Start(object sender, RoutedEventArgs e)
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
                if (IsUserInputValid())
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


        //! HID
        string lastHIDnum = "999";
        //HID 데이터 이벤트
        public void ReceivedHIDData(string hidNum)
        {
            //http://localhost:7001/Service1.svc/setdataHID/99
            //http://localhost:7001/Service1.svc/getdata/111?callback=222
            lastHIDnum = hidNum.Trim();

            Logger.Log("HID 값:" + lastHIDnum);
            string requestURL = regControl._ServerURL + "setdataHID/" + lastHIDnum;


            requestHTTP.SetDataToServer(requestURL);
        }



        //! PDF Watcher
        public void PDFCreated(string filePath)
        {
            Logger.Log("PDF생성감지: " + filePath);

            if (filePath.Contains(lastHIDnum) == false)
            {
                Logger.Log($"HID 값이 일치하지 않음");
                Logger.Log($"Last HID Number [{lastHIDnum}]");
                Logger.Log($"filePath [{filePath}]");
            }
            else
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(async delegate
                {
                    string requestURL = regControl._ServerURL + "setdataStaplerPrinter/" + "P01";
                    requestHTTP.SetDataToServer(requestURL);

                    bool res = await printProcess.PrintProc(printerName, filePath, mioControl);
                    if (res)
                    {
                        Logger.Log("출력 완료");
                        requestURL = regControl._ServerURL + "setdataStaplerPrinter/" + "P05";
                        requestHTTP.SetDataToServer(requestURL);
                    }
                    else
                    {
                        Logger.Log("출력 완료");
                        requestURL = regControl._ServerURL + "setdataStaplerPrinter/" + "P91";
                        requestHTTP.SetDataToServer(requestURL);
                    }

                    try
                    {
                        //PDF 파일삭제 
                        File.Delete(filePath);
                    }
                    catch (Exception e)
                    {
                        Logger.Log(e.ToString());

                    }
                }));
            }
        }


        public void PDFDeleted(string filePath)
        {
            Logger.Log("PDF삭제감지: " + filePath);
        }

        //! Click: 로그폴더
        private void Buton_OpenLogDir(object sender, RoutedEventArgs e)
        {
            string dirPath = AppDomain.CurrentDomain.BaseDirectory;
            dirPath = System.IO.Path.Combine(dirPath, "Log");
            Process.Start(dirPath);
        }

        //! Clikc: 포트닫기
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


        #region 시작프로그램 등록


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
    }
}