using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    class MioPort : MioPortBase
    {
        protected override string LogHeader => "MIO포트";

        protected override string PrimaryPortName => "MioPort";

        protected override void Log(string log) => MioLogger.Log(log);

        protected override void Log(DeviceID dest, string log) => MioLogger.Log(dest, log);


        public override async Task<bool> TryOpenFunction()
        {
            var mio1 = new MioVersion(DeviceID.MIO1, this);
            try
            {
                return await mio1.GetVersion();
            }
            finally
            {
                mio1.Dispose();
            }
        }
    }
}
