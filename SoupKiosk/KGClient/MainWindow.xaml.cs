﻿using System;
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
        MioControl mioControl = new MioControl();
        PrintProcess printProcess = new PrintProcess();
        HIDControl hidControl = new HIDControl();

        public MainWindow()
        {
            InitializeComponent();
        }

        //! Click: 장비초기화
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            bool res = await mioControl.InitDeviceAsnyc();
        }

        //! Click: 테스트 출력  + 인증기 배출
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //! 프린터명 고정 
            string printerName = "Canon LBP351/352 UFR II";
            string pdfFilePath = @"D:\02.업무자료_내부\사업자등록증\사업자등록증(에니텍시스)_전자세금계산서.pdf";
            bool res = await printProcess.PrintProc("1004", printerName, pdfFilePath, mioControl);
        }


        //! Click: HID 연결
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hidControl.HID_SerialOpen();
        }
        //! Click: HID 끊기
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            hidControl.HID_SerialClose();
        }


        #region 미사용
        protected string LogH { get; set; } = "TEST출력";
        public string[] PrinterNames => PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
        #endregion

      
    }
}
