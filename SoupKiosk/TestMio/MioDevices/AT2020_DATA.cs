using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    class AT2020_DATA
    {
        public static readonly int MessageLength = 15;

        public byte CMD { get; private set; }

        public byte Status1 { get; private set; }

        public byte Status2 { get; private set; }

        public byte Sensor1 { get; private set; }

        public byte Sensor2 { get; private set; }

        public byte Sensor3 { get; private set; }

        public byte Motor { get; private set; }

        public byte Error1 { get; private set; }

        public byte Error2 { get; private set; }

        public byte Error3 { get; private set; }

        public byte MotorError { get; private set; }

        public byte MIO4Status { get; private set; }

        //삭제 20210503
        //public byte ModelType { get; private set; }

        public byte Version { get; private set; }

        public byte DestPaperCount { get; private set; }

        public byte PaperCount { get; private set; }

        public BitArray bit_CMD { get; private set; }

        public BitArray bit_Status1 { get; private set; }

        public BitArray bit_Status2 { get; private set; }

        public BitArray bit_Sensor1 { get; private set; }

        public BitArray bit_Sensor2 { get; private set; }

        public BitArray bit_Sensor3 { get; private set; }

        public BitArray bit_Motor { get; private set; }

        public BitArray bit_Error1 { get; private set; }

        public BitArray bit_Error2 { get; private set; }

        public BitArray bit_Error3 { get; private set; }

        public BitArray bit_MotorError { get; private set; }

        public BitArray bit_MIO4Status { get; private set; }

        //삭제 20210503
        //public BitArray bit_ModelType { get; private set; }

        public BitArray bit_Version { get; private set; }

        //public BitArray bit_PaperCount { get; private set; }

        public AT2020_DATA(byte[] data)
        {
            if (data.Length != MessageLength)
                throw new Exception($"인증기 데이터의 길이가 일치하지 않습니다.({MessageLength}자리) - {data.Length}");
            CMD = data[0];
            Status1 = data[1];
            Status2 = data[2];
            Sensor1 = data[3];
            Sensor2 = data[4];
            Sensor3 = data[5];
            Motor = data[6];
            Error1 = data[7];
            Error2 = data[8];
            Error3 = data[9];
            MotorError = data[10];
            MIO4Status = data[11];
            //ModelType = data[12];
            Version = data[12];
            PaperCount = data[13];
            DestPaperCount = data[14];

            bit_CMD = ToBitArray(CMD);
            bit_Status1 = ToBitArray(Status1);
            bit_Status2 = ToBitArray(Status2);
            bit_Sensor1 = ToBitArray(Sensor1);
            bit_Sensor2 = ToBitArray(Sensor2);
            bit_Sensor3 = ToBitArray(Sensor3);
            bit_Motor = ToBitArray(Motor);
            bit_Error1 = ToBitArray(Error1);
            bit_Error2 = ToBitArray(Error2);
            bit_Error3 = ToBitArray(Error3);
            bit_MotorError = ToBitArray(MotorError);
            bit_MIO4Status = ToBitArray(MIO4Status);
            //bit_ModelType = ToBitArray(ModelType);
            bit_Version = ToBitArray(Version);
            //bit_PaperCount = ToBitArray(PaperCount);

            BitArray ToBitArray(byte b) => new BitArray(new byte[] { b });
        }
    }
}
