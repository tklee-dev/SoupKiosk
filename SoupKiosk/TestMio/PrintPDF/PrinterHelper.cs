using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Net;
using System.Printing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JelLib.Native;

namespace TestMio
{

    public static class PrinterHelper
    {
        /// <summary>
        /// 설치되어 있는 프린터 목록을 가져온다.
        /// </summary>
        public static string[] PrinterNames => PrinterSettings.InstalledPrinters.Cast<string>().ToArray();

        /// <summary>
        /// 기본 프린터 이름을 가져온다.
        /// </summary>
        public static string DefaultPrinterName
        {
            get
            {
                var ps = new PrinterSettings();
                return ps.IsDefaultPrinter ? ps.PrinterName : String.Empty;
            }
        }

        /// <summary>
        /// 기본 프린터 변경
        /// </summary>
        public static void SetDefaultPrinter(string printerName) => JelLib.Native.NativeMethods.SetDefaultPrinter(printerName);


        /// <summary>
        /// 프린터의 용지함 목록을 가져온다.
        /// </summary>
        /// <param name="printerName">프린터 이름</param>
        /// <param name="onlyBasicTrays">기본용지함만 가져올지 여부(자동, 수동, 용지함1,2)</param>
        /// <returns></returns>
        public static PaperSource[] GetInputTrays(string printerName, bool onlyBasicTrays)
        {
            if (String.IsNullOrWhiteSpace(printerName))
                throw new ArgumentException("프린터 이름은 Null 또는 공백일수 없습니다.");

            if (PrinterNames.Contains(printerName) == false)
                throw new ArgumentException(String.Format("프린터 \"{0}\"이 설치되어 있지 않습니다.", printerName));

            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = printerName;

            if (onlyBasicTrays)
                return ps.PaperSources.Cast<PaperSource>().Where(tray =>
                    tray.SourceName.Contains("자동") || tray.SourceName.Contains("수동") || tray.SourceName.Contains("용지함")).ToArray();
            else
                return ps.PaperSources.Cast<PaperSource>().ToArray();
        }

        public static PrinterPortMap[] GetPortMaps(bool includeComport = false)
        {
            var prnQueues = GetPrinterQueues(PrinterQueueTypes.OnlyLocal);
            var prnPorts = GetInstalledPorts();
            if (includeComport == false)
                prnPorts = prnPorts.Where(item => Regex.IsMatch(item.pPortName, @"^COM\d+") == false).ToArray();

            List<PrinterPortMap> prns = new List<PrinterPortMap>();
            foreach (var p in prnPorts)
                prns.Add(new PrinterPortMap(p,
                    prnQueues.Where(item => p.pPortName.Equals(item.QueuePort.Name)).Select(item => item.Name).ToArray()));
            return prns.OrderBy(item => item.PortName).ToArray();
        }

        public static PORT_INFO_2[] GetInstalledPorts()
        {
            uint pcbNeeded = 0;
            uint pcReturned = 0;

            if (NativeMethods.EnumPorts(null, 2, IntPtr.Zero, 0, ref pcbNeeded, ref pcReturned))
            {
                //succeeds, but must not, because buffer is zero (too small)!
                throw new Exception("EnumPorts should fail!");
            }

            int lastWin32Error = Marshal.GetLastWin32Error();
            //ERROR_INSUFFICIENT_BUFFER = 122 expected, if not -> Exception
            if (lastWin32Error != 122)
            {
                throw new Win32Exception(lastWin32Error);
            }

            IntPtr pPorts = Marshal.AllocHGlobal((int)pcbNeeded);
            if (NativeMethods.EnumPorts(null, 2, pPorts, pcbNeeded, ref pcbNeeded, ref pcReturned))
            {
                IntPtr currentPort = pPorts;
                PORT_INFO_2[] pinfo = new PORT_INFO_2[pcReturned];


                for (int i = 0; i < pcReturned; i++)
                {
                    pinfo[i] = (PORT_INFO_2)Marshal.PtrToStructure(currentPort, typeof(PORT_INFO_2));
                    currentPort = (IntPtr)(currentPort.ToInt32() + Marshal.SizeOf(typeof(PORT_INFO_2)));
                }
                Marshal.FreeHGlobal(pPorts);

                return pinfo;
            }

            throw new Win32Exception(Marshal.GetLastWin32Error());
        }


        public enum PrinterQueueTypes { All, OnlyLocal, OnlyNetwork }
        /// <summary>
        /// 프린터 큐 목록을 AdministratePrinter 권한으로 가져온다.
        /// 네트워크 프린터의 경우 UsePrinter권한으로 가져온다.
        /// </summary>
        public static PrintQueue[] GetPrinterQueues(PrinterQueueTypes queueType, bool throwException = false)
        {
            LocalPrintServer localPrintServer = new LocalPrintServer(PrintSystemDesiredAccess.AdministrateServer);
            try
            {
                localPrintServer.Refresh();
                PrintQueueCollection prnCollection;
                if (queueType == PrinterQueueTypes.OnlyLocal)
                {
                    prnCollection = localPrintServer.GetPrintQueues(
                    new[] { EnumeratedPrintQueueTypes.Local });
                }
                else if (queueType == PrinterQueueTypes.OnlyNetwork)
                {
                    prnCollection = localPrintServer.GetPrintQueues(
                    new[] { EnumeratedPrintQueueTypes.Connections });
                }
                else
                {
                    prnCollection = localPrintServer.GetPrintQueues(
                    new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
                }

                List<PrintQueue> qList = new List<PrintQueue>();
                foreach (var q in prnCollection)
                {
                    try
                    {
                        if (localPrintServer.Name.Equals(q.HostingPrintServer.Name))
                        {
                            try
                            {
                                qList.Add(new PrintQueue(q.HostingPrintServer, q.Name, PrintSystemDesiredAccess.AdministratePrinter));
                            }
                            catch (Exception)
                            {
                                // 재시도
                                qList.Add(new PrintQueue(q.HostingPrintServer, q.Name, PrintSystemDesiredAccess.UsePrinter));
                            }
                        }
                        else
                            qList.Add(new PrintQueue(q.HostingPrintServer, q.Name, PrintSystemDesiredAccess.UsePrinter));
                        q.Dispose();
                    }
                    catch (Exception ex)
                    {
                        if (throwException)
                            throw new Exception(q.Name + ", " + q.HostingPrintServer, ex);
                    }
                }

                return qList.ToArray();
            }
            finally
            {
                localPrintServer.Dispose();
            }
        }

        public static bool IsNetworkPrinter(string printerName)
        {
            Regex r = new Regex("^" + Regex.Escape("\\\\") + "(.*?)" + Regex.Escape("\\"));
            return r.IsMatch(printerName);
        }

        /// <summary>
        /// 프린터 큐를 AdministratePrinter 권한으로 가져온다.
        /// 네트워크 프린터는 가져올수 없다.
        /// </summary>
        public static PrintQueue GetPrinterQueue(string printerName)
        {
            if (String.IsNullOrWhiteSpace(printerName))
                throw new ArgumentException("프린터 이름은 Null 또는 공백일수 없습니다.");

            if (IsNetworkPrinter(printerName))
            {
                var nq = GetPrinterQueues(PrinterQueueTypes.OnlyNetwork).SingleOrDefault(item => item.FullName.ToUpper().Equals(printerName.ToUpper()));
                if (nq == null)
                    throw new ArgumentException(String.Format("프린터 \"{0}\"이 설치되어 있지 않습니다.", printerName));
                return nq;
            }
            else
            {
                if (PrinterNames.Contains(printerName) == false)
                    throw new ArgumentException(String.Format("프린터 \"{0}\"이 설치되어 있지 않습니다.", printerName));

                var printServer = new LocalPrintServer(PrintSystemDesiredAccess.AdministrateServer);
                try
                {
                    var q = new PrintQueue(printServer, printerName, PrintSystemDesiredAccess.AdministratePrinter); ;
                    return q;
                }
                finally
                {
                    printServer.Dispose();
                }
            }
        }

        public static string GetNetworkPrinterIP(string printername)
        {
            ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath);
            var ports = new Dictionary<string, IPAddress>();
            var selectQuery = new SelectQuery("Win32_TCPIPPrinterPort");
            selectQuery.SelectedProperties.Add("CreationClassName");
            selectQuery.SelectedProperties.Add("Name");
            selectQuery.SelectedProperties.Add("HostAddress");
            selectQuery.Condition = "CreationClassName = 'Win32_TCPIPPrinterPort'";

            using (var searcher = new ManagementObjectSearcher(objScope, selectQuery))
            {
                var objectCollection = searcher.Get();
                foreach (ManagementObject managementObjectCollection in objectCollection)
                {
                    var ipaddress = managementObjectCollection.GetPropertyValue("HostAddress").ToString();
                    var name = managementObjectCollection.GetPropertyValue("Name").ToString();
                    if (name.Equals(printername))
                        return ipaddress;
                }
            }
            return String.Empty;

            //using (var printServer = new PrintServer(string.Format(@"\\{0}", PrinterServerName)))
            //{
            //    foreach (var queue in printServer.GetPrintQueues())
            //    {
            //        if (!queue.IsShared)
            //        {
            //            continue;
            //        }
            //        yield return new Printer
            //                     {
            //                        Location = queue.Location,
            //                        Name = queue.Name,
            //                        PortName = queue.QueuePort.Name,
            //                        PortAddress = ports[queue.QueuePort.Name]
            //                     };
            //    }
            //}
        }

        public static void PauseAllLocalPrinter()
        {
            var q = GetPrinterQueues(PrinterQueueTypes.OnlyLocal);
            foreach (PrintQueue pq in q)
                pq.Pause();
        }

        public static void ResumeAllPrinter()
        {
            var q = GetPrinterQueues(PrinterQueueTypes.OnlyLocal);
            foreach (PrintQueue pq in q)
                pq.Resume();
        }

        public static void PausePrinter(string printerName)
        {
            CheckPermissionByName(printerName);
            using (var q = GetPrinterQueue(printerName))
                q.Pause();
        }

        public static void ResumePrinter(string printerName)
        {
            CheckPermissionByName(printerName);
            using (var q = GetPrinterQueue(printerName))
                q.Resume();
        }

        public static void PurgePrinter(string printerName)
        {
            CheckPermissionByName(printerName);
            using (var q = GetPrinterQueue(printerName))
                q.Purge();
        }

        private static void CheckPermissionByName(string printerName)
        {
            if (IsNetworkPrinter(printerName))
                throw new Exception("네트워크 프린터에서는 실행할 수 없는 명령입니다.");
        }

    }
}

