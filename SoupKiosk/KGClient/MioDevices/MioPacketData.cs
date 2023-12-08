using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class MioPacketData
    {
        public MioPacketData()
        {
            this.SRC =
            this.DEST = DeviceID.Unknonw;

            this.CMD_ID =
            this.RVS =
            this.Length = 0x00;
            this.Message = new byte[0];
        }

        public DeviceID SRC { get; set; }
        public DeviceID DEST { get; set; }
        public byte CMD_ID { get; set; }
        public byte RVS { get; set; }
        public byte Length { get; set; }
        public byte[] Message { get; set; }
        public byte BCC { get; set; }
    }
}
