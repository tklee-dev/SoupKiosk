using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KGClient
{
    public static class VoiceHelper
    {
        public const string SplitHeader = "<braille>";
        public const string SplitFooter = "</braille>";

        public static string RemoveNewLines(string src) => (src ?? "").Replace('\n', ' ').Replace("\r", "").Replace("  ", " ");

        public static string RemoveBracket(string src)
        {
            //괄호 열기는 공백, 괄호 닫기는 ""으로 변경
            var str = Regex.Replace(src ?? "", @"[\[\{\(]", " ");
            str = Regex.Replace(str ?? "", @"[\]\}\)]", "");
            return str.Replace("  ", " ");
        }

        public static string RemoveVtml(string src)
        {
            try
            {
                var begin = src.IndexOf("<vtml");
                if (begin < 0)
                    return src;

                var end = src.IndexOf(">");
                src = src.Remove(begin, end - begin + 1);

                begin = src.IndexOf("</vtml");
                if (begin < 0)
                    return src;

                end = src.IndexOf(">");
                src = src.Remove(begin, end - begin + 1);

                return RemoveVtml(src);
            }
            catch (Exception)
            {
                return src;
            }
        }

        /// <summary>
        /// 구분자로 "|"를 만들어 전달하면 첫자리는 음성, 둘째자리는 점자디스플레이에 포시
        /// ex> "나는 <braille>음성|점자</braille>합니다. 그리고 <braille>음성으로|점자로</braille> 출력됩니다." 
        /// </summary>
        public static string ToSplitBraille(string voice, string braille) =>
            $"{SplitHeader}{voice}|{braille}{SplitFooter}";

        /// <summary>
        /// 구분자로 "|"를 만들어 전달하면 첫자리는 음성, 둘째자리는 점자디스플레이에 포시
        /// ex> "나는 <braille>음성|점자</braille>합니다. 그리고 <braille>음성으로|점자로</braille> 출력됩니다." 
        /// </summary>
        public static (string voice, string braille) SplitBraille(string src)
        {
            try
            {
                var voice = String.Empty;
                var braille = String.Empty;
                var temp = src;

                while (true)
                {
                    var begin = temp.IndexOf(SplitHeader);
                    if (begin < 0)
                        return (voice + temp, braille + temp);

                    voice += temp.Substring(0, begin);
                    braille += temp.Substring(0, begin);

                    temp = temp.Remove(0, begin + SplitHeader.Length);

                    var end = temp.IndexOf(SplitFooter);
                    if (end < 0)
                        return (src, src);

                    var payload = temp.Substring(0, end);
                    temp = temp.Remove(0, end + SplitFooter.Length);

                    var strs = payload.Split('|');
                    if (strs.Length == 2)
                    {
                        voice += strs[0];
                        braille += strs[1];
                    }
                    else
                        return (src, src);
                }
            }
            catch (Exception)
            {
                return (src, src);
            }
        }


        public static string NumberOfCopyToVoceText(int copy)
        {
            var voice = String.Empty;
            switch (copy)
            {
                case 1: voice = "한 부"; break;
                case 2: voice = "두 부"; break;
                case 3: voice = "세 부"; break;
                case 4: voice = "네 부"; break;
                case 5: voice = "다섯 부"; break;
                case 6: voice = "여섯 부"; break;
                case 7: voice = "일곱 부"; break;
                case 8: voice = "여덟 부"; break;
                case 9: voice = "아홉 부"; break;
                default: return "";
            }

            return ToSplitBraille(voice, $"{copy}부");
        }
    }
}
