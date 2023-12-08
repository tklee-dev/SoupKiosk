using JelLib.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStapler
{
    class MioLogger : LoggerBase<MioLogger>
    {
        static MioLogger()
        {
            CreateLogger("MIO");
        }

        public static void Log(DeviceID devId, string log) =>
            WriteLog($"[{devId.GetDescription()}]\t{log}");

        public static void Log(DeviceID devId, string format, params object[] args) =>
            WriteLog($"[{devId.GetDescription()}]\t{String.Format(format, args)}");

        public static void Error(DeviceID devId, string log) =>
            WriteLog($"[{devId.GetDescription()}]\t[ERROR] {log}");

        public static void Error(DeviceID devId, string format, params object[] args) =>
            WriteLog($"[{devId.GetDescription()}]\t[ERROR]{String.Format(format, args)}");
    }
}
