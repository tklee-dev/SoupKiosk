using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStapler
{

    enum DeviceID : byte
    {
        [Description("미정의")]
        Unknonw = 0x00,
        [Description("MIO1")]
        MIO1 = 0x11,
        [Description("MIO2")]
        MIO2 = 0x12,
        [Description("MIO3")]
        MIO3 = 0x13,
        [Description("입출금(구형)")]
        MONEY_OLD = 0x20,
        [Description("동전")]
        COIN = 0x21,
        [Description("MIO2,지폐")]
        BILL = 0x22,
        [Description("콘락스MIO")]
        CONLUX = 0x25,
        [Description("키패드")]
        KEYPAD = 0x30,
        [Description("PC")]
        PC = 0x40,
        [Description("인증기")]
        STAPLE_MACHINE = 0x50,
        [Description("배출구")]
        PaperGate = 0x60,
        [Description("금액표시기")]
        SEGEMENT = 0x70,
        [Description("UPS")]
        UPS = 0x80,
        [Description("안내LED")]
        LED = 0x90,
        [Description("센서")]
        SENSOR = 0xA0,
        [Description("사용자감지센서")]
        DETECT_SENSOR = 0xF0,
        [Description("앰프보드")]
        AMP = 0x66,

        //K300에서 추가된 장치들
        [Description("(신)사용안내 표시기(LED)")]
        LED_K300 = 0x91,
        [Description("(신)센서")]
        SENSOR_K300 = 0xA1,
        [Description("오디오보드")]
        AMP_K300 = 0xB0,
        [Description("전원 및 광고 LED 제어")]
        POWER_CONTROL = 0xC0,
        [Description("RFID 도어락")]
        RFID_DOOR_LOCK = 0xD0
    }
}
