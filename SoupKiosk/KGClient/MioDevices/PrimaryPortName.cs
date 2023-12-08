using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class PrimaryPortName
    {
        private const string BasekeyPath = @"SOFTWARE\Anyteksys\Device\";
        private const string ValueKeyName = "PrimaryPort";

        public string DeviceName { get; private set; }

        public PrimaryPortName(string devName)
        {
            this.DeviceName = devName;
        }

        public string GetPrimaryPortName()
        {
            using (var baseKey = Registry64.CurrentUser.CreateSubKey(BasekeyPath + DeviceName))
                return baseKey.GetValue("PrimaryPort", "").ToString();
        }

        public void SetPrimaryPortName(string portname)
        {
            using (var baseKey = Registry64.CurrentUser.CreateSubKey(BasekeyPath + DeviceName))
                baseKey.SetValue("PrimaryPort", portname);
        }
    }
}
