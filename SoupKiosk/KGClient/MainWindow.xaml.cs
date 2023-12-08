using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
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



        MioControl mioControl = new MioControl();
        PrintProcess printProcess = new PrintProcess();
        HIDControl hidControl = new HIDControl();


        public MainWindow()
        {
            InitializeComponent();

            foreach (var portName in PrinterNames)
                cbPrinter.Items.Add(portName);

            foreach (var portName in serial_list)
                cbHID.Items.Add(portName);

            foreach (var portName in serial_list)
                cbMio.Items.Add(portName);
        }



        //! Click: 장비초기화
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool res = await mioControl.InitDeviceAsnyc(cbMio.SelectedItem.ToString());
        }

        //! Click: 테스트 출력  + 인증기 배출
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            string pdfFilePath = System.IO.Path.Combine(path, "SamplePDF", "사업자등록증(에니텍시스)_전자세금계산서.pdf");

            bool res = await printProcess.PrintProc("1004", cbPrinter.SelectedItem.ToString(), pdfFilePath, mioControl);
        }


        //! Click: HID 연결
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hidControl.HID_SerialOpen(cbHID.SelectedItem.ToString());
        }
        //! Click: HID 끊기
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            hidControl.HID_SerialClose();
        }




    }
}
