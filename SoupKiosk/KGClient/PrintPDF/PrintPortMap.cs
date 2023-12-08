using JelLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class PrinterPortMap
    {
        internal PrinterPortMap(PORT_INFO_2 port_info_2, string[] printerNames)
        {
            this.PortName = port_info_2.pPortName;
            this.Description = port_info_2.pDescription;
            this.MonitorName = port_info_2.pMonitorName;
            this.PrinterNames = printerNames;
        }

        public string PortName { get; private set; }
        public string Description { get; private set; }
        public string MonitorName { get; private set; }
        public string[] PrinterNames { get; private set; }

        public override string ToString()
        {
            return String.Format("{0} ({1})", PortName, String.Join(", ", PrinterNames));
        }
    }
}
