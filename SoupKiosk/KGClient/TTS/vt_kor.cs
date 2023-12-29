using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    class vt_kor
    {
        private const string DLL_FILE = "vt_kor.dll";

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern LoadResults VT_LOADTTS_KOR(int hWnd, int nSpeakerID, string db_path, string licensefile);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VT_UNLOADTTS_KOR(int nSpeakerID);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern short VT_LOAD_UserDict_KOR(int dictidx, [In] string filename);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern short VT_UNLOAD_UserDict_KOR(int dictidx);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern PlayResults VT_PLAYTTS_KOR(IntPtr hcaller, uint umsg, [In] string text_buff, int nspeakerid, int pitch, int speed, int volume, int pause, int dictidx, int texttype);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VT_STOPTTS_KOR();

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VT_RESTARTTTS_KOR();

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VT_PAUSETTS_KOR();

        //static extern short vt_texttofile_kor(int fmt, char* tts_text, char* filename, int nspeakerid, int pitch, int speed, int volume, int pause, int dictidx, int texttype);
        //static extern int VT_TextToBuffer_KOR(int fmt, char* tts_text, char* output_buff, int* output_len, int flag, int nThreadID, int nSpeakerID, int pitch, int speed, int volume, int pause, int dictidx, int texttype);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VT_SetPitchSpeedVolumePause_KOR(int pitch, int speed, int volume, int pause, int nSpeakerID);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VT_SetCommaPause_KOR(int pause, int nSpeakerID);

        [DllImport(DLL_FILE, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VT_GetTTSInfo_KOR(int request, [In] string licensefile, [Out] StringBuilder value, int valuesize);
    }
}
