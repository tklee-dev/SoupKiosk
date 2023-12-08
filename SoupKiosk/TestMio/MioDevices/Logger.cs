using JelLib.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
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


    //public class ErrorLogger : LoggerBase<ErrorLogger>
    //{
    //    static ErrorLogger()
    //    {
    //        CreateLogger("Error");
    //    }

    //    public static void Log(string header, string msg, ModelErrorBase model)
    //        => LogH(header, $"{msg} - {model.LastServiceCode}, {model.LastErrorMesage}");
    //}

    public class Logger : LoggerBase<Logger>
    {
        static Logger()
        {
            CreateLogger("AP");
            //ErrorLogger에 기록되는 내용은 Logger에도 기록한다.
            //ErrorLogger.SubLogAction = WriteLogWithoutTime;
        }

        /// <summary>
        /// 화면 생성 파괴 관련 로그
        /// </summary>
        public static void WndH(string title, string log) =>
            LogH(title, $"[WND] {log}");

        /// <summary>
        /// 장치제어 관련 로그
        /// </summary>
        public static void DevH(string title, string log) =>
            LogH(title, $"[DEV] {log}");

        /// <summary>
        /// 장치제어 관련 장애 로그
        /// </summary>
        public static void DevErrorH(string title, string log) =>
            ErrorH(title, $"[DEV] {log}");

        ///// <summary>
        ///// 서비스 관련 로그
        ///// </summary>
        //public static void SvcH(string title, string svcDesc) =>
        //    LogH(title, $"[SVC] {svcDesc}");

        ///// <summary>
        ///// 서비스 관련 오류 로그
        ///// </summary>
        //public static void SvcErrorH(string title, string svcDesc, IServiceErrorMessage service) =>
        //    ErrorH(title, $"[SVC] {svcDesc ?? ""} - 실패, SvcCode: {(service?.kI
    }
}
