﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFJsonP
{
    static public class SaveValues
    {
        public static bool IsInitDevice { get; set; }
        public static string HID { get; set; }
        public static bool InitHID { get; set; }
        public static string ProximitySensor { get; set; } = "00";
        public static string StaplerPrinter { get; set; }


        static public void Clear()
        {
            ProximitySensor = "00";
            StaplerPrinter = "";
            InitHID = false;
            IsInitDevice = false;
        }


        public static Queue<string> TTSQueue { get; set; } = new Queue<string>();

        public static bool IsReboot { get; set; } = false;
    }
}