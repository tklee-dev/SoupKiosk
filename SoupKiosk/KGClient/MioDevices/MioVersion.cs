using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class MioVersion : MioDeviceBase
    {
        private readonly byte[] CMD_VERSION = { (byte)'V', Converter.ToFlipByte('V') };

        public string Version { get; private set; } = String.Empty;

        public MioVersion(DeviceID devId, MioPort control)
            : base(devId, control, 500)
        { }

        public Task<bool> GetVersion()
        {
            Version = String.Empty;
            return Task.Run(() => SendRetry("버전요청", CMD_VERSION));
        }

        public override void OnPacketReceived(object sender, MioPacketData packet)
        {
            try
            {
                Version = ParseToVersion(packet.Message[1]);
                MioLogger.Log(DeviceID, $"버전: {Version}");
                base.OnPacketReceived(sender, packet);
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 수신 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
                Version = String.Empty;
            }
        }

        private string ParseToVersion(byte b)
        {
            var l = (b & 0x0f).ToString();
            var h = ((b >> 4) & 0x0f).ToString();
            return $"{h}.{l}";
        }
    }
}
