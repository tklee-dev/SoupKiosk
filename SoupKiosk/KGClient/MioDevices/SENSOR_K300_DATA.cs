using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class SENSOR_K300_DATA
    {
        //public bool IsPushAdminButton { get { return bit_Mio1Sensor[0]; } }

        //public bool IsDoorOpen { get { return bit_Mio1Sensor[1]; } }

        public bool IsDetectUser { get { return bit_Mio1Sensor[2]; } }

        //public bool IsCashUnit { get { return bit_Mio1Sensor[3]; } }

        //public bool IsBackDoorOpen { get { return bit_Mio1Sensor[4]; } }

        //public bool IsPushReturnButton { get { return bit_Mio2Sensor[0]; } }

        //public bool IsBillAcceptor { get { return bit_Mio2Sensor[1]; } }

        public byte Mio1Sensor { get; set; }

        public byte Mio2Sensor { get; set; }

        private BitArray bit_Mio1Sensor { get; set; }

        private BitArray bit_Mio2Sensor { get; set; }

        public SENSOR_K300_DATA(byte[] data)
        {
            if (data.Length != 3)
                throw new Exception("센서 데이터의 길이가 일치하지 않습니다.(3자리) - " + data.Length.ToString());

            Mio1Sensor = data[0];
            Mio2Sensor = data[1];
            //reserve = data[2];

            bit_Mio1Sensor = new BitArray(new byte[] { Mio1Sensor });
            bit_Mio2Sensor = new BitArray(new byte[] { Mio2Sensor });
        }
    }
}

