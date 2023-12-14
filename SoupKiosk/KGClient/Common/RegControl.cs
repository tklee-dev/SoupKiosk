using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KGClient
{

    public enum RegKeyNames
    {
        PrinterName,
        MIOPort,
        HIDPort,
        PDFDirPath,
        ServerURL,
        WebURL
    }

    public class RegControl
    {

        RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\AnytekSys");

        public RegControl()
        {

        }

        public void CreateReg()
        {

            try
            {

                if (reg == null)
                {
                    reg = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey("AnytekSys");
                    reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\AnytekSys", true);
                    reg.SetValue("PrinterName", "999");
                    reg.SetValue("MIOPort", "999");
                    reg.SetValue("HIDPort", "999");
                    reg.SetValue("PDFDirPath", "999");
                    reg.SetValue("ServerURL", "999");
                    reg.SetValue("WebURL", "999");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public string _PrinterName { get; set; }
        public string _MIOPort { get; set; }
        public string _HIDPort { get; set; }
        public string _PDFDirPath { get; set; }
        public string _ServerURL { get; set; }
        public string _WebURL { get; set; }


        /// <summary>
        /// 모든 ini 설정값을 읽는다.
        /// _PrinterName, _MIOPort, _HIDPort,_PDFFilePath prop접근하여 사용.
        /// </summary>
        public void GetAllReg()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\AnytekSys");
            _PrinterName = reg.GetValue("PrinterName").ToString();
            _MIOPort = reg.GetValue("MIOPort").ToString();
            _HIDPort = reg.GetValue("HIDPort").ToString();
            _PDFDirPath = reg.GetValue("PDFDirPath").ToString();
            _ServerURL = reg.GetValue("ServerURL").ToString();
            _WebURL = reg.GetValue("WebURL").ToString();

        }

        public void ChangeReg(RegKeyNames key, string value)
        {
            reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\AnytekSys", true);

            switch (key)
            {
                case RegKeyNames.PrinterName:
                    reg.SetValue("PrinterName", value);
                    break;
                case RegKeyNames.MIOPort:
                    reg.SetValue("MIOPort", value);
                    break;
                case RegKeyNames.HIDPort:
                    reg.SetValue("HIDPort", value);
                    break;
                case RegKeyNames.PDFDirPath:
                    reg.SetValue("PDFDirPath", value);
                    break;
                case RegKeyNames.ServerURL:
                    reg.SetValue("ServerURL", value);
                    break;
                case RegKeyNames.WebURL:
                    reg.SetValue("WebURL", value);
                    break;
                default:
                    break;
            }
        }




    }
}
