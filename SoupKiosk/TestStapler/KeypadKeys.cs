using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStapler
{
    public enum KeypadKeys
    {
        [Description("1")]
        No1,
        [Description("2")]
        No2,
        [Description("3")]
        No3,
        [Description("4")]
        No4,
        [Description("5")]
        No5,
        [Description("6")]
        No6,
        [Description("7")]
        No7,
        [Description("8")]
        No8,
        [Description("9")]
        No9,
        [Description("0")]
        No0,
        [Description("샵")]
        Pound,
        [Description("별")]
        Asterisk,
        [Description("시작")]
        L1_Left,
        [Description("취소")]
        L1_Right,
        [Description("위 화살표")]
        L2_Left,
        [Description("모음")]
        L2_Center,
        [Description("아래 화살표")]
        L2_Right,
        [Description("자음")]
        L3_Left,
        [Description("입력")]
        L3_Center,
        [Description("영문")]
        L3_Right,
        [Description("확인")]
        L4_Left,
        [Description("정정")]
        L4_Right
    }
}
