using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStapler
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CodeAttribute : Attribute
    {
        public CodeAttribute(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TextAttribute : Attribute
    {
        public TextAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }



    public enum ErrorStatus
    {
        [Code(""), ServerCode(""), ServerTitle(""), Description("Normal"), Text("")]
        Normal,

        [Code("I001"), ServerCode("KATAJ001"), ServerTitle("초기화 실패"), Description("MIO 초기화 실패"), Text("기본장치에서 장애가 발생하였습니다..")]
        Mio_Error,

        //var error = new DeviceError("I001", "KATAJ004", "초기화 실패", "Mio 포트 검색 실패");
        //var error = new DeviceError("I002", "KCMAC026", "초기화 실패", msg);//현금
        //var error = new DeviceError("I003", "KCMAB001", "초기화 실패", msg);//인증기
        //var error = new DeviceError("I004", "KCMAG001", "초기화 실패", msg);//배출구

        [Code("CR001"), ServerCode("KCMAC013"), ServerTitle("동전 반환 장애"), Description("500원 동전 반환 장애"), Text("동전 반환중 장애가 발생하였습니다.")]
        Cash_Coin500,
        [Code("CR002"), ServerCode("KCMAC012"), ServerTitle("동전 반환 장애"), Description("100원 동전 반환 장애"), Text("동전 반환중 장애가 발생하였습니다.")]
        Cash_Coin100,
        [Code("CR003"), ServerCode("KCMAC011"), ServerTitle("동전 반환 장애"), Description("50원 동전 반환 장애"), Text("동전 반환중 장애가 발생하였습니다.")]
        Cash_Coin50,
        [Code("C001"), ServerCode("KCMAC003"), ServerTitle("동전부 장애"), Description("동전 반환 장애"), Text("동전 반환중 장애가 발생하였습니다.")]
        Cash_CoinReturnError,
        [Code("C002"), ServerCode("KCMAC027"), ServerTitle("지폐인식기 장애"), Description("지폐인식기 장애"), Text("지폐인식기에서 장애가 발생하였습니다.")]
        Cash_BillError,
        [Code("C003"), ServerCode("KCMAC028"), ServerTitle("입출금부 장애"), Description("입출금부 장애"), Text("입출금부에서 장애가 발생하였습니다.")]
        Cash_Error,

        [Code("P001"), ServerCode("KCMAD001"), ServerTitle("프린터 장애"), Description("지정된 프린터가 미존재"), Text("프린터에서 장애가 발생하였습니다.")]
        Prn_프린터없음,
        [Code("P002"), ServerCode("KCMAD003"), ServerTitle("프린터 장애"), Description("프린터 설정 실패"), Text("프린터에서 장애가 발생하였습니다.")]
        Prn_프린터설정실패,
        [Code("P003"), ServerCode("KCMAD003"), ServerTitle("프린터 장애"), Description("프린터 작업 설정 실패"), Text("프린터에서 장애가 발생하였습니다.")]
        Prn_프린터작업설정실패,
        [Code("P004"), ServerCode("KATAD001"), ServerTitle("프린터 장애"), Description("인쇄 문서가 생성되지 않음"), Text("프린터에서 장애가 발생하였습니다.")]
        Prn_문서생성실패,
        [Code("P100"), ServerCode("KCMAD003"), ServerTitle("프린터 장애"), Description("프린터 오류"), Text("프린터에서 장애가 발생하였습니다.")]
        Prn_프린터에러,

        [Code("S001"), ServerCode("KCMAB024"), ServerTitle("인증기 장애"), Description("인증기 내부 용지 감지"), Text("인증기 내부에 용지 검출 되었습니다.")]
        Stapler_PaperDetectedInside,
        [Code("S002"), ServerCode("KATAB003"), ServerTitle("인증기 장애"), Description("용지잼(1번센서)"), Text("인증기 급지부에서 용지 잼이 발생하였습니다.")]
        Stapler_Paper_Jam_Sensor1,
        [Code("S003"), ServerCode("KATAB004"), ServerTitle("인증기 장애"), Description("용지잼(2번센서)"), Text("인증기 급지부에서 용지 잼이 발생하였습니다.")]
        Stapler_Paper_Jam_Sensor2,
        [Code("S004"), ServerCode("KATAB005"), ServerTitle("인증기 장애"), Description("용지 정렬 에러"), Text("인증기 적재부에서 용지 잼이 발생하였습니다.")]
        Stapler_S3Sort_DT_PaperERR,
        [Code("S005"), ServerCode("KATAB006"), ServerTitle("인증기 장애"), Description("3번센서 용지 미감지"), Text("인증기 적재부에서 용지 잼이 발생하였습니다.")]
        Stapler_S3Out_NDT_PaperERR,
        [Code("S006"), ServerCode("KATAB007"), ServerTitle("인증기 장애"), Description("4번센서 용지 미감지"), Text("인증기 배출부에서 용지 잼이 발생하였습니다.")]
        Stapler_S4Out_NDT_PaperERR,
        [Code("S007"), ServerCode("KATAB008"), ServerTitle("인증기 장애"), Description("용지잼(4번센서)"), Text("인증기 배출부에서 용지 잼이 발생하였습니다.")]
        Stapler_S4JamERR,
        [Code("S008"), ServerCode("KATAB009"), ServerTitle("인증기 장애"), Description("배출구 용지 감지"), Text("배출구에 용지 검출 되었습니다.")]
        Stapler_Door_DT_Paper,
        [Code("S009"), ServerCode("KATAB010"), ServerTitle("인증기 장애"), Description("인증기 통신 에러"), Text("인증기 통신 장애가 발생하였습니다.")]
        Stapler_NotConnect,
        [Code("S010"), ServerCode("KATAB011"), ServerTitle("인증기 장애"), Description("사이드 조그 에러"), Text("인증기 정렬부에서 장애가 발생하였습니다.")]
        Stapler_SideJog_ERR,
        [Code("S011"), ServerCode("KATAB012"), ServerTitle("인증기 장애"), Description("픽업 에러 (전진)"), Text("인증기에서 장애가 발생하였습니다.")]
        Stapler_PickUp_FWD_ERR,
        [Code("S012"), ServerCode("KATAB013"), ServerTitle("인증기 장애"), Description("픽업 에러 (후진)"), Text("인증기에서 장애가 발생하였습니다.")]
        Stapler_PickUp_RVS_ERR,
        [Code("S013"), ServerCode("KATAB014"), ServerTitle("인증기 장애"), Description("플레이트 Up 에러"), Text("인증기에서 장애가 발생하였습니다.")]
        Stapler_Plate_UP_ERR,
        [Code("S014"), ServerCode("KATAB015"), ServerTitle("인증기 장애"), Description("플레이트 Down 에러"), Text("인증기에서 장애가 발생하였습니다.")]
        Stapler_Plate_DN_ERR,
        [Code("S016"), ServerCode("KATAB016"), ServerTitle("인증기 장애"), Description("용지 미감지 에러"), Text("배출구에 용지가 감지되지 않았습니다.")]
        Stapler_Door_NDT_PaperERR,
        [Code("S017"), ServerCode("KCMAB038"), ServerTitle("인증기 장애"), Description("용지 미출력"), Text("프린터에서 용지가 출력되지 않았습니다.")]
        Stapler_NoInputERR,
        [Code("S018"), ServerCode("KATAB017"), ServerTitle("인증기 장애"), Description("용지가 적게 출력됨"), Text("프린터에서 용지가 적게 출력되었습니다.")]
        Stapler_PaperShotERR,
        [Code("S019"), ServerCode("KATAB018"), ServerTitle("인증기 장애"), Description("명령없이 용지 출력"), Text("인증기 급지부에서 잼이 발생하였습니다.")]
        Stapler_NoCMD_InPaperERR,

        [Code("S020"), ServerCode("KCMAB007"), ServerTitle("인증기 장애"), Description("4번 센서 용지 배출 에러"), Text("인증기 배출부에서 잼이 발생하였습니다.")]
        Stapler_S4_PaperOut_END,
        [Code("S021"), ServerCode("KATAB019"), ServerTitle("인증기 장애"), Description("용지가 많이 출력됨"), Text("인증기 급지부에서 잼이 발생하였습니다.")]
        Stapler_PaperOverERR,
        [Code("S022"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("메인모터 에러"), Text("인증기 장애가 발생하였습니다.")]
        Stapler_MainMoterERR,
        [Code("S023"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("프로펠러 에러"), Text("인증기 장애가 발생하였습니다.")]
        Stapler_PropellerERR,

        [Code("S024"), ServerCode("KCMAB001"), ServerTitle("인증기 장애"), Description("타임아웃"), Text("인증기 통신 장애가 발생하였습니다.")]
        Stapler_TimeOut,

        [Code("S025"), ServerCode("KCMAB001"), ServerTitle("인증기 장애"), Description("회수기 응답 없음"), Text("회수기 통신 장애가 발생하였습니다.")]
        Stapler_Feeder_NotRsp, //	FEEDER 응답이 없음
        [Code("S026"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 배출구 닫기 에러"), Text("회수기 배출구에서 장애가 발생하였습니다.")]
        Stapler_Feeder_Door_Close_Error,//	DOOR CLOSE ERROR
        [Code("S027"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 배출구 열기 에러"), Text("회수기 배출구에서 장애가 발생하였습니다.")]
        Stapler_Feeder_Door_Open_Error, //	DOOR OPEN ERROR
        [Code("S028"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 배출구 회수 위치 에러"), Text("회수기 배출구에서 장애가 발생하였습니다.")]

        Stapler_Feeder_Door_Paper_Down_Error, //	DOOR Paper Down Position ERROR
        [Code("S029"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 용지 전진 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_PaperFWD_Error, //	용지 전진 ERROR
        [Code("S030"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 용지 후진 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_PaperRVS_Error, //	용지 후진 ERROR

        [Code("S031"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 Plate 전진 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_PlateFWD_Error, //	PLATE 전진 ERROR
        [Code("S032"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 Plate 후진 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_PlateRVS_Error, //	PLATE 후진 ERROR
        [Code("S033"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 Half 모터 전진 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_HalfFWD_Error, //	HALF 전진 ERROR
        [Code("S034"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 Half 모터 후진 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_HalfRVS_Error, //	HALF 후진 ERROR
        [Code("S035"), ServerCode("KCMAB032"), ServerTitle("인증기 장애"), Description("회수기 용지 정렬 에러"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_PaperSort_Error, //	용지 정렬 ERROR

        [Code("S036"), ServerCode("KCMAB007"), ServerTitle("인증기 장애"), Description("회수기 7번 센서 용지 감지"), Text("회수기에서 장애가 발생하였습니다.")]
        Stapler_Feeder_S7_DT_Paper, //  회수장치 종이 감지 ERROR
        [Code("S037"), ServerCode("KCMAB001"), ServerTitle("인증기 장애"), Description("용지를 가져가지 않음"), Text("용지 가져가지 않았습니다.")]
        Stapler_Feeder_TimeOver, //	지정된 시간내에 용지를 가져 가지 않음

        ///////////////////
        //초기화중 오류
        ///////////////////
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("초기화 에러"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_Error,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (Busy 상태)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusBusy,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (PAPER IN 상태)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusPaperIn,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (PAPER 정렬 중)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusDoingAlignPaper,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (PUNCH 중)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusDoingPunch,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (STAPLE 중)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusDoingStaple,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (BOTTOM PLATE UP 중)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusDoingPlateUp,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (BOTTOM PLATE DOWN 중)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusDoingPlateDn,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 변화 없음 (PAPER OUT 상태)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_StatusPaperOut,

        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (급지대기 TIME OVER)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_ErrorNotInputPaper,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (인증명령 재수신)"), Text("")]
        Stapler_Init_ErrorReceiveSetPageAgain,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (용지가 부족하게 올라옴)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_ErrorPaperShort,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (명령없이 용지 투입)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_ErrorPaperInNotCommand,

        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (송신금지 명령 금지)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_TransferBan,

        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (1번 센서)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DetectSensor1,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (2번 센서)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DetectSensor2,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (용지 정렬 센서)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DetectAlignSensor,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (4번 센서, 용지배출센서)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DetectSensor4,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (천공 센서)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DetectPunchSensor,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (픽업 롤러)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_HomePickupRoller,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (플레이트)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_HomePlate,

        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (사이즈조그)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DetectSideJogSensor,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (좌측호침)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_HomeStapleL,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (우측호침)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_HomeStapleR,

        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (메인모터)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingMainMotor,

        //사이드조그 전진은 체크하지 말자. 완료되었는데 모터가 동작하는게 이상하잖아.
        //if (hasPBMachine == false && IsDoingSideJog == false) //회수기 있는 모델은 사이드조거 센서체크 미사용
        //    return "모터 오류 (사이드조그, 전진)";

        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (사이드조그, 후진)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingSideJogRVS,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (프로펠러)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingPropeller,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (픽업, 전진)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingPickUpFWD,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (픽업, 후진)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingPickUpRVS,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (플레이트 Up)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingPlateUpMotor,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("모터 오류 (플레이트 Down)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingPlateDownMotor,

        //인증기 리셋중 플래그는 마지막에 체크
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (인증기 RESET 상태)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_DoingReset,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (용지 장수)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_PaperCount,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (피더Up 상태 아님)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_HomeFeederUp,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (피더Down 상태임)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_HomeFeederDown,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("상태 오류 (피더기에서 배출작업 전 상태)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_FeederOutputYet,
        [Code("S015"), ServerCode("KCMAB002"), ServerTitle("인증기 초기화 실패"), Description("센서 오류 (회수기 배출구 위치 홈 에러)"), Text("인증기 초기화 중 장애가 발생하였습니다.")]
        Stapler_Init_PBHomeCamClose,

        [Code("G001"), ServerCode("KATAH002"), ServerTitle("배출구 장애"), Description("배출구 열기 에러)"), Text("배출구에서 장애가 발생하였습니다.")]
        Stapler_PaperGate_OpenFail,
        [Code("G002"), ServerCode("KATAH003"), ServerTitle("배출구 장애"), Description("배출구 닫기 에러"), Text("배출구에서 장애가 발생하였습니다.")]
        Stapler_PaperGate_CloseFail,
        [Code("G003"), ServerCode("KCMAG001"), ServerTitle("배출구 장애"), Description("배출구 응답없음"), Text("배출구에서 장애가 발생하였습니다.")]
        Stapler_PaperGate_Timeout,

        [Code("S100"), ServerCode("KCMAB001"), ServerTitle("인증기 장애"), Description("기타 오류"), Text("인증기에서 장애가 발생하였습니다.")]
        Stapler_Error
    }
}
