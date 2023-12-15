﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KGClient
{
    /// <summary>
    /// WindowWeb.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WindowWeb : Window
    {
        MainWindow mainWindow= null;
        public WindowWeb(MainWindow mainWindow, string url)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            ChromeBrowser.Address = url;
        }

        private void ChromeBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.J)
            {
                //KGClient 열기
                mainWindow.Show();
                mainWindow.Topmost = true;
            }            
        }
    }
}
