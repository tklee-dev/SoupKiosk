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
        WebURL,
        OffTime,
        UseStapler
    }

    /// <summary>
    /// 기능1. 설정값을 Registry에 저장 및 삭제
    /// 기능2. 프로그램을 레지스트리 시작프로그램 등록/삭제
    /// </summary>
    public class RegControl
    {
        //컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\AnytekSys
        //64bit의 경우 WOW6432Node
        RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AnytekSysKG");

        public RegControl()
        {

        }

        /// <summary>
        /// 설정 레지스트리 초기화
        /// </summary>
        public void CreateReg()
        {
            try
            {

                if (reg == null)
                {
                    reg = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("AnytekSysKG");
                    reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AnytekSysKG", true);
                    reg.SetValue("PrinterName", "999");
                    reg.SetValue("MIOPort", "999");
                    reg.SetValue("HIDPort", "999");
                    reg.SetValue("PDFDirPath", "999");
                    reg.SetValue("ServerURL", "999");
                    reg.SetValue("WebURL", "999");
                    reg.SetValue("OffTime", "999");
                    reg.SetValue("UseStapler", "false");
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
        public string _OffTime { get; set; }
        public string _UseStapler { get; set; }


        /// <summary>
        /// 모든 ini 설정값을 읽는다.
        /// _PrinterName, _MIOPort, _HIDPort,_PDFFilePath prop접근하여 사용.
        /// </summary>
        public void GetAllReg()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AnytekSysKG");
            _PrinterName = reg.GetValue("PrinterName")?.ToString();
            _MIOPort = reg.GetValue("MIOPort")?.ToString();
            _HIDPort = reg.GetValue("HIDPort")?.ToString();
            _PDFDirPath = reg.GetValue("PDFDirPath")?.ToString();
            _ServerURL = reg.GetValue("ServerURL")?.ToString();
            _WebURL = reg.GetValue("WebURL")?.ToString();
            _OffTime = reg.GetValue("OffTime")?.ToString();
            _UseStapler = reg.GetValue("UseStapler")?.ToString();

        }

        /// <summary>
        /// 설정 레지스트리 값 번경
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ChangeReg(RegKeyNames key, string value)
        {
            reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AnytekSysKG", true);

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
                case RegKeyNames.OffTime:
                    reg.SetValue("OffTime", value);
                    break;
                case RegKeyNames.UseStapler:
                    reg.SetValue("UseStapler", value);
                    break;
                default:
                    break;
            }
        }




        // 부팅시 시작 프로그램을 등록하는 레지스트리 경로
        private static readonly string _startupRegPath =
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private Microsoft.Win32.RegistryKey GetRegKey(string regPath, bool writable)
        {
            //컴퓨터\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
            return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regPath, writable);
        }

        /// <summary>
        /// 시작프로그램 등록
        /// </summary>
        public void SetStartupProgram(string programName, string executablePath)
        {
            using (var regKey = GetRegKey(_startupRegPath, true))
            {
                try
                {
                    // 키가 이미 등록돼 있지 않을때만 등록
                    if (regKey.GetValue(programName) == null)
                        regKey.SetValue(programName, executablePath);

                    regKey.Close();
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString());
                }
            }
        }

        //시작 프로그램 삭제
        public void DeleteStartupProgram(string programName)
        {
            using (var regKey = GetRegKey(_startupRegPath, true))
            {
                try
                {
                    // 키가 이미 존재할때만 제거
                    if (regKey.GetValue(programName) != null)
                        regKey.DeleteValue(programName, false);

                    regKey.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
