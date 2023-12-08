using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    public static class Converter
    {
        public static System.DateTime UnixTimeStampToDateTime(double timestamp)
        {
            System.DateTime converted = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            System.DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        }

        public static double DateTimeToUnixTimeStamp(System.DateTime dt)
        {
            System.DateTime origin = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = dt - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static byte[] IntToByteArray(int n)
        {
            return System.BitConverter.GetBytes(n);
        }

        public static byte[] IntToByteArray(Int16 n)
        {
            return System.BitConverter.GetBytes(n);
        }

        public static int ByteArrayToInt(byte[] b)
        {
            byte[] d = new byte[4];
            Array.Copy(b, d, b.Length);
            return BitConverter.ToInt32(d, 0);
        }

        public static Int16 ByteArrayToInt16(byte[] b)
        {
            byte[] d = new byte[4];
            Array.Copy(b, d, b.Length);
            return BitConverter.ToInt16(d, 0);
        }

        public static String ByteArrayToString(byte[] s)
        {
            return System.Text.Encoding.UTF8.GetString(s);
        }

        public static byte[] StringToByteArrayUTF8(String s)
        {
            return System.Text.Encoding.UTF8.GetBytes(s);
        }

        public static byte[] StringToByteArrayANSI(String s)
        {
            return System.Text.Encoding.Default.GetBytes(s);
        }

        public static string HexToStr(byte data)
        {
            return data.ToString("X2");
        }

        public static string HexDataToStr(byte[] data)
        {
            string str = String.Empty;
            foreach (byte b in data)
            {
                str += HexToStr(b) + " ";
            }
            return str.TrimEnd();
        }

        public static string DoubleToDollarString(double d, bool dollarsymbol = false)
        {
            if (dollarsymbol)
                return String.Format("${0:n2}", d);
            else
                return String.Format("{0:n2}", d);
        }

        public static string DecimalToDollarString(decimal d, bool dollarsymbol = false)
        {
            if (dollarsymbol)
                return String.Format("${0:n2}", d);
            else
                return String.Format("{0:n2}", d);
        }

        public static string DecimalToCommaString(decimal d)
        {
            return d.ToString("n0");
        }

        public static string IntToCommaString(int d)
        {
            return d.ToString("n0");
        }

        public static string IntToCommaString(decimal d)
        {
            return d.ToString("n0");
        }

        public static string ToCommaString(int d, int pointLength = 0)
        {
            return d.ToString("n" + pointLength);
        }

        public static string ToCommaString(decimal d, int pointLength = 0)
        {
            return d.ToString("n" + pointLength);
        }

        public static string ToCommaString(double d, int pointLength = 0)
        {
            return d.ToString("n" + pointLength);
        }

        public static byte ToFlipByte(char c)
        {
            uint u = ~(uint)c;
            return (byte)u;
        }

        public static byte ToFlipByte(byte c)
        {
            uint u = ~(uint)c;
            return (byte)u;
        }

        public static string ExceptionToString(Exception e)
        {
            try
            {
                string result = String.Empty;
                result = e.Message + "\r\nStackTrace : " + e.StackTrace;
                if (e.InnerException != null)
                    result += "\r\nInnerException - " + ExceptionToString(e.InnerException);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string Number2Hangle(Int64 x, bool addWon = false)
        {
            bool isMinus = x < 0;

            if (isMinus)
                x = x * -1;

            string HAmt = ""; string EAmt = "";
            Int64 KLen = 0; Int64 ELen = 0;
            int j = 0; int k = 0;
            string W = ""; string Y = "";

            try
            {

                EAmt = x.ToString();
                ELen = EAmt.Length;
                k = 0;
                for (j = 0; j < ELen; j++)
                {
                    KLen = Convert.ToInt64(EAmt.Substring(j, 1));
                    switch (KLen)
                    {
                        case 1:
                            W = "일";
                            break;
                        case 2:
                            W = "이";
                            break;
                        case 3:
                            W = "삼";
                            break;
                        case 4:
                            W = "사";
                            break;
                        case 5:
                            W = "오";
                            break;
                        case 6:
                            W = "육";
                            break;
                        case 7:
                            W = "칠";
                            break;
                        case 8:
                            W = "팔";
                            break;
                        case 9:
                            W = "구";
                            break;
                        case 0:
                            W = "영";
                            break;
                    }
                    switch (ELen)
                    {
                        case 17:
                            Y = "경천백십조천백십억천백십만천백십원";
                            break;
                        case 16:
                            Y = "천백십조천백십억천백십만천백십원";
                            break;
                        case 15:
                            Y = "백십조천백십억천백십만천백십원";
                            break;
                        case 14:
                            Y = "십조천백십억천백십만천백십원";
                            break;
                        case 13:
                            Y = "조천백십억천백십만천백십원";
                            break;
                        case 12:
                            Y = "천백십억천백십만천백십원";
                            break;
                        case 11:
                            Y = "백십억천백십만천백십원";
                            break;
                        case 10:
                            Y = "십억천백십만천백십원";
                            break;
                        case 9:
                            Y = "억천백십만천백십원";
                            break;
                        case 8:
                            Y = "천백십만천백십원";
                            break;
                        case 7:
                            Y = "백십만천백십원";
                            break;
                        case 6:
                            Y = "십만천백십원";
                            break;
                        case 5:
                            Y = "만천백십원";
                            break;
                        case 4:
                            Y = "천백십원";
                            break;
                        case 3:
                            Y = "백십원";
                            break;
                        case 2:
                            Y = "십원";
                            break;
                        case 1:
                            Y = "원";
                            break;
                    }
                    if (W != "영")
                        HAmt = HAmt + (W + Y.Substring(k, 1));
                    else if (String.IsNullOrWhiteSpace(HAmt))
                        HAmt = W;

                    if (Y.Substring(k, 1) == "억")
                    {
                        if (W == "영")
                        {
                            HAmt = HAmt + "억";
                        }
                    }
                    else if (Y.Substring(k, 1) == "만")
                    {
                        if (W == "영")
                        {
                            HAmt = HAmt + "만";
                        }
                    }
                    else if (Y.Substring(k, 1) == "원")
                    {
                        if (W == "영")
                        {
                            HAmt = HAmt + "원";
                        }
                    }

                    k = k + 1;
                }
            }
            catch (Exception err)
            {
                throw err;
            }

            if (addWon == false)
                HAmt = HAmt.Remove(HAmt.Length - 1);

            if (isMinus)
                HAmt = "-" + HAmt;
            return HAmt;

        }
    }
}
