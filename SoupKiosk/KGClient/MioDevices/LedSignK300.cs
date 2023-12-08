using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KGClient
{
    class LedSignK300 : MioDeviceBase, ILedSignal
    {
        /// <summary>
        /// 강제로 깜빡임 비활성화 TEST용으로 전체 LED깜빡이지 않게 할때 사용
        /// </summary>
        public static bool GlobalDisableFlicker = false;

        private readonly byte[] CMD_STATUS = { (byte)'S', JelLib.Converter.ToFlipByte('S') };

        enum LedDeviceID : byte
        {
            [Description("전체")]
            All = 0x00,
            [Description("입금")]
            CashInput = 0x01,
            //영수증에서 카드로 변경
            //[Description("영수증")]
            //Recipt = 0x02,
            [Description("신용카드")]
            CardPayment = 0x02,
            [Description("반환")]
            ChangeOut = 0x03,
            [Description("반환램프")]
            ChangeOutLamp = 0x04,
            [Description("용지배출구")]
            PaperGate = 0x05,
            [Description("지문인식기")]
            FingerPrint = 0x06,
            [Description("지문&배출구")]
            PaperGateAndFingerPrint = 0x07
        }

        enum LedColor : byte
        {
            Normal = 0x00,
            Red = 0x20,
            Green = 0x40,
            Blue = 0x80
        }

        public LedSignK300(MioPort control)
            : base(DeviceID.LED_K300, control)
        { }


        public bool IsSupportMultiColor => true;

        /// <summary>
        /// 용지 배출구 LED
        /// </summary>
        public bool OnPaperGate
        {
            get => _OnPaperGate;
            set => base.SetProperty(ref _OnPaperGate, value, () =>
            {
                if (value)
                    OnPaperGateComplete = false;
                Send(LedDeviceID.PaperGate, value, true, LedColor.Green);
            });
        }
        private bool _OnPaperGate = false;


        /// <summary>
        /// 용지 배출구 LED
        /// </summary>
        public bool OnPaperGateComplete
        {
            get => _OnPaperGateComplete;
            set => base.SetProperty(ref _OnPaperGateComplete, value, () =>
            {
                if (value)
                    OnPaperGate = false;
                Send(LedDeviceID.PaperGate, value, false, LedColor.Blue);
            });
        }
        private bool _OnPaperGateComplete = false;




        /// <summary>
        /// 대기모드 LED (K300전용)
        /// </summary>
        public bool OnStandby
        {
            get => _OnStandby;
            set => base.SetProperty(ref _OnStandby, value, () => Send(LedDeviceID.PaperGateAndFingerPrint, value, false, LedColor.Red));
        }

        private bool _OnStandby = false;

        public bool OnCardPayment
        {
            get => _OnCardPayment;
            set => base.SetProperty(ref _OnCardPayment, value, () => Send(LedDeviceID.CardPayment, value, true));
        }

        private bool _OnCardPayment = false;

        /// <summary>
        /// 전체 OFF
        /// </summary>
        public void SetAllOff()
        {
            _OnPaperGate = false;
            _OnStandby = false;
            _OnCardPayment = false;

            Send(LedDeviceID.All, false);
        }

        /// <summary>
        /// 전체 ON
        /// </summary>
        public void SetAllOn()
        {
            _OnPaperGate = true;
            _OnStandby = true;
            _OnCardPayment = true;

            Send(LedDeviceID.All, true, false, LedColor.Normal);
        }

        private void Send(LedDeviceID id, bool value, bool isFlicker = false, LedColor color = LedColor.Normal)
        {
            try
            {
                byte[] data = new byte[4];
                data[0] = (byte)id;

                if (value)
                {
                    data[1] = 0x01;
                }
                else
                {
                    data[1] = 0x00;
                }
                data[1] = (byte)(value ? 0x01 : 0x00);
                data[1] |= (byte)color; //색상
                data[2] = 0x00; //예약

                if (GlobalDisableFlicker)
                {
                    //강제로 깜빡임 비활성화
                    data[3] = 0x00;
                }
                else
                {
                    if (value && isFlicker)
                    {
                        data[1] |= 0x02; //깜빡임 여부
                        data[3] = 0x80; //LED 깜빡이는 시간 가격(단위: 1 = 128 msec )
                    }
                    else
                        data[3] = 0x00;
                }


                base.SendNoWait($"{id.GetDescription()} {(value ? "On" : "Off")}", data);
                Thread.Sleep(50);  // Led날리고 다른신호를 바로 날리면 명령이 안들어간다.
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 전송 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
            }
        }

        public Task<bool> GetStatus()
        {
            return Task.Run(() => SendRetry("상태요청", CMD_STATUS));
        }

        public override void OnPacketReceived(object sender, MioPacketData packet)
        {
            try
            {
                MioLogger.Log(DeviceID, $"K300 LED 응답 받음");
                base.OnPacketReceived(sender, packet);
            }
            catch (Exception ex)
            {
                MioLogger.Error(DeviceID, $"데이터 수신 중 오류 - {ex.Message}");
                MioLogger.Log(ex);
            }
        }
    }
}
