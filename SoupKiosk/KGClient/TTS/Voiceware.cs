using JelLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Threading;

namespace KGClient
{
    public class Voiceware
    {
        private const string LogH = "음성서비스";
        private const int SPEAKER_ID = -1; // 기본값 사용

        private IntPtr _Hwnd = IntPtr.Zero;
        private HwndSource _HWndSrc;
        private Dispatcher _Dispatcher;

        private uint _PlayId = Messages.WM_USER + 100;
        private Action _CompletedAction = null;
        private bool _IsPlayingAsync = false;

        public bool IsLoaded { get; private set; } = false;
        public PlaySettings PlaySettings { get; private set; } = new PlaySettings();

        //public IBrailleDisplay BrailleDisplay { get; set; } = null;

        //public bool IsEnalbedBlind { get; set; } //2021_0106

        public Voiceware(IntPtr hwnd, Dispatcher dispatcher)
        {
            Logger.LogH(LogH, "생성");
            try
            {
                _Dispatcher = dispatcher;
                _Hwnd = hwnd;
                _HWndSrc = HwndSource.FromHwnd(hwnd);
                _HWndSrc.AddHook(new HwndSourceHook(WndProc));
            }
            catch (Exception ex)
            {
                Logger.LogH(LogH, "생성Exceptioin: " + LoadResults.EXCEPTION.GetDescription());
                Logger.Log(ex);
            }
        }

        public bool Open()
        {
            try
            {
                //Dispatcher로 실행하지 않으면 일정시간 경과 후 음성재생이 되지 않는다.
                //(-5)가 리턴됨. 원인은 모르겠다.
                _Dispatcher.Invoke(() =>
                {
                    var rv = vt_kor.VT_LOADTTS_KOR((int)_Hwnd, SPEAKER_ID, "", "");
                    Logger.LogH(LogH, "초기화: " + rv.GetDescription());
                    IsLoaded = rv == LoadResults.VT_LOADTTS_SUCCESS;
                });
                return IsLoaded;
            }
            catch (Exception ex)
            {
                Logger.LogH(LogH, "TTS초기화: " + LoadResults.EXCEPTION.GetDescription());
                Logger.Log(ex);
                return false;
            }
        }

        public bool Close(int nSpeaker)
        {
            if (IsLoaded == false)
                return true;

            try
            {
                _Dispatcher.Invoke(() =>
                {
                    IsLoaded = false;
                    vt_kor.VT_UNLOADTTS_KOR(SPEAKER_ID);
                    Logger.LogH(LogH, "닫기: " + LoadResults.VT_LOADTTS_SUCCESS.GetDescription());
                });
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogH(LogH, "닫기: " + LoadResults.EXCEPTION.GetDescription());
                Logger.Log(ex);
                return false;
            }
        }

        //public void Braille(string text) => BrailleDisplay?.Display(text);

        public bool Play(string text)
        {
            if (IsLoaded == false)
                return true;

            return PlayVoice(text) == PlayResults.VT_PLAY_API_SUCCESS;
        }

        public bool Play(string text, Action completeAction)
        {
            if (IsLoaded == false)
            {
                completeAction?.Invoke();
                return true;
            }

            var rv = _Dispatcher.Invoke(() => PlayVoice(text, completeAction));
            return rv == PlayResults.VT_PLAY_API_SUCCESS;
        }

        public async Task<bool> PlayAsync(string text)
        {

           
            if (IsLoaded == false)
                return true;

            var tcs = new TaskCompletionSource<bool>();
            var rv = _Dispatcher.Invoke(() => PlayVoice(text, () => tcs.SetResult(true)));
            if (rv != PlayResults.VT_PLAY_API_SUCCESS)
            {
                tcs.SetCanceled();
                return false;
            }
            await tcs.Task;
            return true;
        }

        public void Stop()
        {
            if (IsLoaded == false)
                return;

            Logger.LogH(LogH, "재생중지");
            _Dispatcher.Invoke(() => vt_kor.VT_STOPTTS_KOR());
            if (_IsPlayingAsync)
            {
                Logger.LogH(LogH, "이전 음성 재생 완료 호출");
                NativeMethods.SendMessage((int)_Hwnd, (int)_PlayId, 0, -1);
            }
        }

        [HandleProcessCorruptedStateExceptions]
        private PlayResults PlayVoice(string text, Action completeAction = null)
        {
            try
            {
                Logger.LogH(LogH, ">> 음성재생");

                vt_kor.VT_STOPTTS_KOR();
                if (_IsPlayingAsync)
                {
                    Logger.LogH(LogH, "음성재생 - 이전 음성 재생 완료 호출");
                    NativeMethods.SendMessage((int)_Hwnd, (int)_PlayId, 0, -1);
                }

                if (String.IsNullOrWhiteSpace(text))
                {
                    completeAction?.Invoke();
                    return PlayResults.VT_PLAY_API_SUCCESS;
                }

                var strs = VoiceHelper.SplitBraille(text);
                var vText = VoiceHelper.RemoveBracket(strs.voice);

                //if (IsEnalbedBlind)
                //    SendBrailleDisplay(strs.braille);

                //if (RuntimeConfig.IsTestPC)
                //{
                //    if (ModuleLogger.WritePlayLog)
                //        PlayLogger.Log("음성: " + vText);
                //}

                PlayResults rv = PlayResults.UNDEFINED_ERROR;
                if (_PlayId == 0 || completeAction == null)
                {
                    rv = vt_kor.VT_PLAYTTS_KOR(IntPtr.Zero, 0, vText, SPEAKER_ID,
                    PlaySettings.Pitch, PlaySettings.Speed, PlaySettings.Volume, PlaySettings.PauseTime, -1, -1);
                    Logger.LogH(LogH, "<< 음성재생: " + rv.GetDescription());
                }
                else
                {
                    IncreaseID();

                    _IsPlayingAsync = true;
                    _CompletedAction = completeAction;

                    rv = vt_kor.VT_PLAYTTS_KOR(_Hwnd, _PlayId, vText, SPEAKER_ID,
                        PlaySettings.Pitch, PlaySettings.Speed, PlaySettings.Volume, PlaySettings.PauseTime, -1, -1);

                    if (rv != PlayResults.VT_PLAY_API_SUCCESS)
                    {
                        _CompletedAction = null;
                        _IsPlayingAsync = false;
                    }
                    Logger.LogH(LogH, $"<< 음성재생[ID:{_PlayId}]: " + rv.GetDescription());
                }

                return rv;
            }
            catch (Exception ex)
            {
                Logger.LogH(LogH, "<< 음성재생: " + PlayResults.EXCEPTION.GetDescription());
                Logger.Log(ex);
                return PlayResults.EXCEPTION;
            }

            void IncreaseID()
            {
                _PlayId++;
                if (_PlayId >= Messages.WM_USER + 1000)
                    _PlayId = Messages.WM_USER + 100;
            }
        }



        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            try
            {
                if (msg == _PlayId && _IsPlayingAsync)
                {
                    var msgid = (uint)msg;
                    // DevLogger.LogH(LogH, $"[ID:{msgid}] wp: {wParam}, lp: {lParam}");

                    if (lParam.ToInt64() == -1)
                    {
                        var action = _CompletedAction;
                        _CompletedAction = null;
                        _IsPlayingAsync = false;

                        Logger.LogH(LogH, $"음성재생콜백: 재생완료[ID:{msgid}]");

                        _Dispatcher.InvokeAsync(action);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogH(LogH, "음성재생콜백: 예외오류발생");
                Logger.Log(ex);
            }
            return IntPtr.Zero;
        }
    }
}
