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

        Winforms.NotifyIcon noti;

        MioControl mioControl = new MioControl();
        PrintProcess printProcess = new PrintProcess();
        HIDControl hidControl = new HIDControl();


        public MainWindow()
        {
            InitializeComponent();

            if (noti == null)
                SetNotifyIcon();

            this.Hide();

            foreach (var portName in PrinterNames)
                cbPrinter.Items.Add(portName);

            foreach (var portName in serial_list)
                cbHID.Items.Add(portName);

            foreach (var portName in serial_list)
                cbMio.Items.Add(portName);


            //todo tray형태로 실행 * 완료
            //todo 1. 설정값 읽기 ( Mio Port, HID Port, 프린터명, Watcher경로 )
            //todo 2. 장비 초기화
            //todo 3. FileSystemWatcher 실행 
        }

        private void SetNotifyIcon()
        {
            noti = new Winforms.NotifyIcon();
            System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon();
            Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/KGClient;component/ImgResource/icons8-compute-60.ico")).Stream;
            var bitmap = new Bitmap(iconStream);
            noti.Icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
            noti.Visible = true;
            noti.Text = "KGClient";

            noti.DoubleClick += delegate (object sender, EventArgs eventArgs)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };

            Winforms.ContextMenu menu = new Winforms.ContextMenu();
            Winforms.MenuItem item1 = new Winforms.MenuItem();
            item1.Text = "프로그램 종료";

            item1.Click += delegate (object sender, EventArgs e)
            {
                //todo MIO포트 닫기 *MioControl.cs에 Close 메서드 추가
                
                if (hidControl != null)
                    hidControl.HID_SerialClose();

                Application.Current.Shutdown();
                noti.Dispose();
            };
            menu.MenuItems.Add(item1);
            noti.ContextMenu = menu;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //종료되지 않도록 처리 ( 트레이 버튼으로만 종료되도록 ) 
            this.Hide();
            e.Cancel = true;
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
            }
        }

        //! Click: 테스트 출력  + 인증기 배출
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(cbPrinter.SelectedItem.ToString()))
            {
                MessageBox.Show("프린터를 선택하세요");
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string pdfFilePath = System.IO.Path.Combine(path, "SamplePDF", "사업자등록증(에니텍시스)_전자세금계산서.pdf");
                bool res = await printProcess.PrintProc("1004", cbPrinter.SelectedItem.ToString(), pdfFilePath, mioControl);
            }
        }


        //! Click: HID 연결
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbHID.SelectedItem.ToString()))
            {
                MessageBox.Show("HID PORT를 선택하세요");
            }
            else
            {
                hidControl.HID_SerialOpen(cbHID.SelectedItem.ToString());
            }
        }
        //! Click: HID 끊기
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            hidControl.HID_SerialClose();
        }


    }
}
