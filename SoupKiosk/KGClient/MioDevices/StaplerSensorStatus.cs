using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class StaplerSensorStatus : NotifyPropertyChangedBase
    {
        public ErrorStatus ErrorStatus { get; private set; }

        public bool IsError => ErrorStatus != ErrorStatus.Normal;



        internal void Set(AT2020_DATA data)
        {
            CMD = data.CMD;
            bit_Status1 = new BitArray(new byte[] { data.Status1 });
            bit_Status2 = new BitArray(new byte[] { data.Status2 });
            bit_Sensor1 = new BitArray(new byte[] { data.Sensor1 });
            bit_Sensor2 = new BitArray(new byte[] { data.Sensor2 });
            bit_Sensor3 = new BitArray(new byte[] { data.Sensor3 });
            bit_Motor = new BitArray(new byte[] { data.Motor });
            bit_Error1 = new BitArray(new byte[] { data.Error1 });
            bit_Error2 = new BitArray(new byte[] { data.Error2 });
            bit_Error3 = new BitArray(new byte[] { data.Error3 });
            bit_MotorError = new BitArray(new byte[] { data.MotorError });
            bit_MIO4Status = new BitArray(new byte[] { data.MIO4Status });

            //현재는 모델구분을 사용하지 않으니 패스 20210502 차종익
            //bit_ModelType = new BitArray(new byte[] { data.ModelType });

            bit_Version = new BitArray(new byte[] { data.Version });

            Version = ParseToVersion(data.Version);
            //K300은 별도 분리
            InputCount = data.PaperCount;
            DestCount = data.DestPaperCount;
            Set();
            RaisePropertyChanged();
        }

        public bool IsMortorStoppedAll()
        {
            return (IsDoingPlateDn || IsDoingPlateUp ||
                    IsDoingMainMotor || IsDoingPropeller) == false;
        }

        private string ParseToVersion(byte b)
        {
            var l = (b & 0x0f).ToString();
            var h = ((b >> 4) & 0x0f).ToString();
            return $"{h}.{l}";
        }

        private void Set()
        {
            IsIdle = !bit_Status1[0];//B0 : 인증기 IDLE 상태 0: IDLE 상태  1: BUSY 상태
            IsPaperIn = bit_Status1[1];//B1 : PAPER IN 상태
            IsDoingAlignPaper = bit_Status1[2];//B2 : PAPER 정렬 중
            IsDoingPunch = bit_Status1[3];//B3 : PUNCH 중
            IsDoingStaple = bit_Status1[4];//B4 : STAPLE 중
            IsDoingPlateUp = bit_Status1[5];//B5 : BOTTOM PLATE UP 중
            IsDoingPlateDn = bit_Status1[6];//B6 : BOTTOM PLATE DOWN 중
            IsPaperOut = bit_Status1[7];//B7 : PAPER OUT 상태

            IsErrorNotInputPaper = bit_Status2[0];//B0 : 급지대기 TIME OVER (2분)
            IsErrorReceiveSetPageAgain = bit_Status2[1];//B1 : 인증명령 재수신
            IsDoingReset = bit_Status2[2];//B2 : 인증기 RESET 상태
            IsErrorPaperShort = bit_Status2[3];//B3 : 용지가 부족하게 올라옴
            IsErrorPaperInNotCommand = bit_Status2[4];//B4 : 명령없이 용지 투입
            //public bool  {get {return bit_Status2[];}}//B5 : 소모품교체요망 (미사용)
            IsFeederOutputYet = bit_Status2[6];//B6 : 피더기에서 배출작업 전 상태
            IsTransferBan = bit_Status2[7];//B7 : 송신금지 명령 금지:1     허용:0

            IsDetectSensor1 = bit_Sensor1[0];//B0 : 급지센서1 신호
            IsDetectSensor2 = bit_Sensor1[1];//B1 : 급지센서2 신호
            IsDetectAlignSensor = bit_Sensor1[2];//B2 : 용지정렬센서
            IsDetectSensor4 = bit_Sensor1[3];//B3 : 용지배출센서(4번센서)
            IsDetectPunchSensor = bit_Sensor1[4];//B4 : 천공 센서
            IsHomePickupRoller = bit_Sensor1[5];//B5 : PICK UP ROLLER HOME
            IsHomePlate = bit_Sensor1[6];//B6 : BOTTOM PLATE HOME
            IsDetectSideJogSensor = bit_Sensor1[7];//B7 : Side Jog Sensor

            IsHomeStapleL = bit_Sensor2[0];//B0 : 좌측STAPLER HOME
            IsEmptyStapleL = bit_Sensor2[3];//B1 : 좌측STAPLE EMPTY
            IsHomeStapleR = bit_Sensor2[2];//B2 : 우측STAPLER HOME
            IsEmptyStapleR = bit_Sensor2[1];//B3 : 우측STAPLE EMPTY
            IsEmptyPaper2 = bit_Sensor2[4];//B4 : PRINTER 2PAPER EMPTY
            IsEmptyPaper3 = bit_Sensor2[5];//B5 : PRINTER 3PAPER EMPTY
            IsHomeFeederUp = bit_Sensor2[6];//B6 : Feeder Home(UP) Sensor
            IsHomeFeederDown = bit_Sensor2[7];//B7 : Feeder Down Sensor

            IsDetectSensor5 = bit_Sensor3[0];//B0 : 급지센서5 신호 (bottom plate)
            IsDetectSensor6 = bit_Sensor3[1];//B1 : 급지센서6 신호 (피더기 내부)
            IsDetectSensor7 = bit_Sensor3[2];//B2 : 급지센서7 신호 (도어 용지 감지)
            IsPBHomeHalf = bit_Sensor3[3];//B3 : 회수장치 반달 홈 센서

            IsDoingMainMotor = bit_Motor[0];//B0 : MAIN STEPPING MOTOR
            IsDoingSideJog = bit_Motor[1];//B1 : SIDE JOG MOTOR FWD
            IsDoingSideJogRVS = bit_Motor[2];//B2 : SIDE JOG MOTOR RVS
            IsDoingPropeller = bit_Motor[3];//B3 : PROPELLER MOTOR
            IsDoingPickUpFWD = bit_Motor[4];//B4 : PICK UP RPLLER MOTOR FWD
            IsDoingPickUpRVS = bit_Motor[5];//B5 : PICK UP RPLLER MOTOR RVS
            IsDoingPlateUpMotor = bit_Motor[6];//B6 : BOTTOM PLATE MOTOR UP
            IsDoingPlateDownMotor = bit_Motor[7];//B7 : BOTTOM PLATE MOTOR DOWN

            IsJamPaperNoInput = bit_Error1[0];//B0 : PAPER NO INPUT JAM
            IsJamPaperNotInThru = bit_Error1[1];//B1 : PAPER NOT IN THRU JAM
            IsJamPaperNotArrange = bit_Error1[2];//B2 : PAPER NOT ARRANGE JAM
            IsJamPapeNotPickUp = bit_Error1[3];//B3 : PAPER NOT PICK UP JAM
            IsJamPaperNoOutput = bit_Error1[4];//B4 : PAPER NO OUTPUT JAM
            IsJamPaperNotOutThru = bit_Error1[5];//B5 : PAPER NOT OUT THRU JAM
            IsJamPaperOver = bit_Error1[6];//B6 : PAPER OVER IN COME
            IsJamPaperInputNoCMD = bit_Error1[7];//B7: PAPER NO CMD INPUT

            IsErrorPaperPositionNotStaple = bit_Error2[0];//B0 : NO PAPER STAPLE
            IsErrorPaperOverCount = bit_Error2[1];//B1 : PAPER OVER COUNT
            IsPBErrorHalfFWD = bit_Error2[2];//B2 : Half모터 FWD 에러(회수기)
            IsPBErrorHalfRVS = bit_Error2[3];//B3 : Half모터 RVS 에러(회수기)
            IsPBErrorCamHome = bit_Error2[4];//B4 : CAM Home Error(회수기)
            IsPBErrorCamExit = bit_Error2[5];//B5 : CAM Exit Error(회수기)
            IsPBErrorCamBack = bit_Error2[6];//B6 : CAM back Error(회수기)

            IsDetectSensor5WhileInit = bit_Error3[0];//B0 : 센서5 용지 감지됨(초기화시)
            IsDetectSensor6WhileInit = bit_Error3[1];//B1 : 센서6 용지 감지됨(초기화시)
            IsDetectSensor7WhileInit = bit_Error3[2];//B2 :센서7 용지 감지됨(초기화시)

            IsErrorMainMotor = bit_MotorError[0];//B0 : MAIN STEPPING MOTOR ERROR
            IsErrorSideJog = bit_MotorError[1];//B1 : SIDE JOG MOTOR FWD ERROR
            IsErrorSideJogRVS = bit_MotorError[2];//B2 : SIDE JOG MOTOR RVS ERROR
            IsErrorPropeller = bit_MotorError[3];//B3 : PROPELLER MOTOR ERROR
            IsErrorPickUpFWD = bit_MotorError[4];//B4 : PICK UP RPLLER MOTOR FWD ERROR
            IsErrorPickUpRVS = bit_MotorError[5];//B5 : PICK UP RPLLER MOTOR RVS ERROR
            IsErrorPlateUp = bit_MotorError[6];//B6 : BOTTOM PLATE MOTOR UP ERROR
            IsErrorPlateDown = bit_MotorError[7];//B7 : BOTTOM PLATE MOTOR DOWN ERROR

            IsPBHomeCamClose = bit_MIO4Status[0];//B0 : Cam Home  완료
            IsPBHomeCamOpen = bit_MIO4Status[1];//B1 : Cam Exit    완료
            IsPBHomeCamCollect = bit_MIO4Status[2];//B2 : Cam back   완료

            IsPHomeHalf = bit_MIO4Status[4];//B4 : mio4_half_home_end :완료=1

            ErrorStatus = SetErrorStatus();
        }

        private ErrorStatus SetErrorStatus()
        {
            // 장애 상태
            if (IsErrorNotInputPaper)
                return ErrorStatus.Stapler_NoInputERR;
            else if (IsErrorPaperShort)
                return ErrorStatus.Stapler_PaperShotERR;
            else if (IsErrorPaperInNotCommand && (IsDetectSensor1 || IsDetectSensor2)) //명령없이 용지  진입시  SNS 2 나 SNS 3이 감지 되어야 함
                return ErrorStatus.Stapler_NoCMD_InPaperERR;
            else if (IsJamPaperNoInput)
                return ErrorStatus.Stapler_Paper_Jam_Sensor1;
            else if (IsJamPaperNotInThru)
                return ErrorStatus.Stapler_Paper_Jam_Sensor2;
            else if (IsJamPaperNotArrange)
                return ErrorStatus.Stapler_S3Sort_DT_PaperERR;
            else if (IsJamPapeNotPickUp)
                return ErrorStatus.Stapler_S3Out_NDT_PaperERR;
            else if (IsJamPaperNoOutput)
                return ErrorStatus.Stapler_S4Out_NDT_PaperERR;
            else if (IsJamPaperNotOutThru)
                return ErrorStatus.Stapler_S4JamERR;
            else if (IsJamPaperOver)
                return ErrorStatus.Stapler_PaperOverERR;

            else if (IsJamPaperInputNoCMD)
                return ErrorStatus.Stapler_NoCMD_InPaperERR;
            else if (IsErrorPaperOverCount)
                return ErrorStatus.Stapler_PaperOverERR;
            else if (IsErrorPaperPositionNotStaple)
                return ErrorStatus.Stapler_S3Sort_DT_PaperERR;
            else if (IsErrorMainMotor)
                return ErrorStatus.Stapler_MainMoterERR;
            else if (IsErrorSideJog)
                return ErrorStatus.Stapler_SideJog_ERR;
            else if (IsErrorSideJogRVS)
                return ErrorStatus.Stapler_SideJog_ERR;
            else if (IsErrorPropeller)
                return ErrorStatus.Stapler_PropellerERR;
            else if (IsErrorPickUpFWD)
                return ErrorStatus.Stapler_PickUp_FWD_ERR;
            else if (IsErrorPickUpRVS)
                return ErrorStatus.Stapler_PickUp_RVS_ERR;
            else if (IsErrorPlateUp)
                return ErrorStatus.Stapler_Plate_UP_ERR;

            else if (IsErrorPlateDown)
                return ErrorStatus.Stapler_Plate_DN_ERR;

            else if (IsPBErrorHalfFWD) //B2 : Half모터 FWD 에러(회수기)
                return ErrorStatus.Stapler_Feeder_PaperFWD_Error;

            else if (IsPBErrorHalfRVS) //B3 : Half모터 RVS 에러(회수기)
                return ErrorStatus.Stapler_Feeder_PaperRVS_Error;

            else if (IsPBErrorCamHome) //B4 : CAM Home Error(회수기)
                return ErrorStatus.Stapler_Feeder_Door_Close_Error;

            else if (IsPBErrorCamExit) //B5 : CAM Exit Error(회수기)
                return ErrorStatus.Stapler_Feeder_Door_Open_Error;

            else if (IsPBErrorCamBack) //B6 : CAM back Error(회수기)
                return ErrorStatus.Stapler_Feeder_Door_Paper_Down_Error;

            else if (IsDetectSensor5WhileInit)
                return ErrorStatus.Stapler_PaperDetectedInside;
            else if (IsDetectSensor6WhileInit)
                return ErrorStatus.Stapler_PaperDetectedInside;
            else if (IsDetectSensor7WhileInit)
                return ErrorStatus.Stapler_PaperDetectedInside;
            else if (InputCount > DestCount && IsIdle == false) //SW 체크
                return ErrorStatus.Stapler_PaperOverERR;

            return ErrorStatus.Normal;

            //Feeder_PlateFWD_Error, //	PLATE 전진 ERROR
            //Feeder_PlateRVS_Error, //	PLATE 후진 ERROR
            //Feeder_HalfFWD_Error, //	HALF 전진 ERROR
            //Feeder_HalfRVS_Error, //	HALF 후진 ERROR
            //Feeder_PaperSort_Error, //	용지 정렬 ERROR
            //Feeder_S7_DT_Paper, //  회수장치 종이 감지 ERROR
            //Feeder_TimeOver //	지정된 시간내에 용지를 가져 가지 않음
        }

        public ErrorStatus GetResetStatus(bool hasPBMachine)
        {
            if (IsIdle == false)
                return ErrorStatus.Stapler_Init_StatusBusy;
            if (IsPaperIn)
                return ErrorStatus.Stapler_Init_StatusPaperIn;
            if (IsDoingAlignPaper)
                return ErrorStatus.Stapler_Init_StatusDoingAlignPaper;
            if (IsDoingPunch)
                return ErrorStatus.Stapler_Init_StatusDoingPunch;
            if (IsDoingStaple)
                return ErrorStatus.Stapler_Init_StatusDoingStaple;
            if (IsDoingPlateUp)
                return ErrorStatus.Stapler_Init_StatusDoingPlateUp;
            if (IsDoingPlateDn)
                return ErrorStatus.Stapler_Init_StatusDoingPlateDn;
            if (IsPaperOut)
                return ErrorStatus.Stapler_Init_StatusPaperOut;

            if (IsErrorNotInputPaper)
                return ErrorStatus.Stapler_Init_ErrorNotInputPaper;
            if (IsErrorReceiveSetPageAgain)
                return ErrorStatus.Stapler_Init_ErrorReceiveSetPageAgain;
            if (IsErrorPaperShort)
                return ErrorStatus.Stapler_Init_ErrorPaperShort;
            if (IsErrorPaperInNotCommand)
                return ErrorStatus.Stapler_Init_ErrorPaperInNotCommand;
            //public bool  {get {return bit_Status2[];}}//B5 : 소모품교체요망 (미사용)


            if (IsTransferBan)
                return ErrorStatus.Stapler_Init_TransferBan;

            if (IsDetectSensor1)
                return ErrorStatus.Stapler_Init_DetectSensor1;
            if (IsDetectSensor2)
                return ErrorStatus.Stapler_Init_DetectSensor2;
            if (IsDetectAlignSensor)
                return ErrorStatus.Stapler_Init_DetectAlignSensor;
            if (IsDetectSensor4)
                return ErrorStatus.Stapler_Init_DetectSensor4;
            if (IsDetectPunchSensor)
                return ErrorStatus.Stapler_Init_DetectPunchSensor;
            if (IsHomePickupRoller)
                return ErrorStatus.Stapler_Init_HomePickupRoller;
            if (IsHomePlate)
                return ErrorStatus.Stapler_Init_HomePlate;

            if (IsDetectSideJogSensor == false)
                return ErrorStatus.Stapler_Init_DetectSideJogSensor;
            if (IsHomeStapleL == false)
                return ErrorStatus.Stapler_Init_HomeStapleL;
            if (IsHomeStapleR == false)
                return ErrorStatus.Stapler_Init_HomeStapleR;


            if (IsDoingMainMotor)
                return ErrorStatus.Stapler_Init_DoingMainMotor;

            //사이드조그 전진은 체크하지 말자. 완료되었는데 모터가 동작하는게 이상하잖아.
            //if (hasPBMachine == false && IsDoingSideJog == false) //회수기 있는 모델은 사이드조거 센서체크 미사용
            //    return "모터 오류 (사이드조그, 전진)";

            if (IsDoingSideJogRVS)
                return ErrorStatus.Stapler_Init_DoingSideJogRVS;
            if (IsDoingPropeller)
                return ErrorStatus.Stapler_Init_DoingPropeller;
            if (IsDoingPickUpFWD)
                return ErrorStatus.Stapler_Init_DoingPickUpFWD;
            if (IsDoingPickUpRVS)
                return ErrorStatus.Stapler_Init_DoingPickUpRVS;
            if (IsDoingPlateUpMotor)
                return ErrorStatus.Stapler_Init_DoingPlateUpMotor;
            if (IsDoingPlateDownMotor)
                return ErrorStatus.Stapler_Init_DoingPlateDownMotor;

            //인증기 리셋중 플래그는 마지막에 체크
            if (IsDoingReset)
                return ErrorStatus.Stapler_Init_DoingReset;

            if (InputCount != 0 || DestCount != 0)
                return ErrorStatus.Stapler_Init_PaperCount;

            if (hasPBMachine)
            {
                if (IsHomeFeederUp == false)
                    return ErrorStatus.Stapler_Init_HomeFeederUp;

                if (IsHomeFeederDown)
                    return ErrorStatus.Stapler_Init_HomeFeederDown;

                if (IsFeederOutputYet)
                    return ErrorStatus.Stapler_Init_FeederOutputYet;

                if (IsPBHomeCamClose == false)
                    return ErrorStatus.Stapler_Init_PBHomeCamClose;
            }

            return ErrorStatus.Normal;
        }

        public string InputStatus { get; private set; }

        public int InputCount { get; private set; }

        public int DestCount { get; private set; }

        public string Version { get; private set; }

        public bool IsIdle { get; private set; }

        public bool IsPaperIn { get; private set; }

        public bool IsDoingAlignPaper { get; private set; }

        public bool IsDoingPunch { get; private set; }

        public bool IsDoingStaple { get; private set; }

        public bool IsDoingPlateUp { get; private set; }

        public bool IsDoingPlateDn { get; private set; }

        public bool IsPaperOut { get; private set; }

        public bool IsErrorNotInputPaper { get; private set; }

        public bool IsErrorReceiveSetPageAgain { get; private set; }

        public bool IsDoingReset { get; private set; }

        public bool IsErrorPaperShort { get; private set; }

        public bool IsErrorPaperInNotCommand { get; private set; }

        public bool IsFeederOutputYet { get; private set; }

        public bool IsTransferBan { get; private set; }

        public bool IsDetectSensor1 { get; private set; }

        public bool IsDetectSensor2 { get; private set; }

        public bool IsDetectAlignSensor { get; private set; }

        public bool IsDetectSensor4 { get; private set; }

        public bool IsDetectPunchSensor { get; private set; }

        public bool IsHomePickupRoller { get; private set; }

        public bool IsHomePlate { get; private set; }

        public bool IsDetectSideJogSensor { get; private set; }

        public bool IsHomeStapleL { get; private set; }

        public bool IsEmptyStapleL { get; private set; }

        public bool IsHomeStapleR { get; private set; }

        public bool IsEmptyStapleR { get; private set; }

        public bool IsEmptyPaper2 { get; private set; }

        public bool IsEmptyPaper3 { get; private set; }

        public bool IsHomeFeederUp { get; private set; }

        public bool IsHomeFeederDown { get; private set; }

        public bool IsDetectSensor5 { get; private set; }

        public bool IsDetectSensor6 { get; private set; }

        public bool IsDetectSensor7 { get; private set; }

        public bool IsPBHomeHalf { get; private set; }

        public bool IsDoingMainMotor { get; private set; }

        public bool IsDoingSideJog { get; private set; }

        public bool IsDoingSideJogRVS { get; private set; }

        public bool IsDoingPropeller { get; private set; }

        public bool IsDoingPickUpFWD { get; private set; }

        public bool IsDoingPickUpRVS { get; private set; }

        public bool IsDoingPlateUpMotor { get; private set; }

        public bool IsDoingPlateDownMotor { get; private set; }

        public bool IsJamPaperNoInput { get; private set; }

        public bool IsJamPaperNotInThru { get; private set; }

        public bool IsJamPaperNotArrange { get; private set; }

        public bool IsJamPapeNotPickUp { get; private set; }

        public bool IsJamPaperNoOutput { get; private set; }

        public bool IsJamPaperNotOutThru { get; private set; }

        public bool IsJamPaperOver { get; private set; }

        public bool IsJamPaperInputNoCMD { get; private set; }

        public bool IsErrorPaperPositionNotStaple { get; private set; }

        public bool IsErrorPaperOverCount { get; private set; }

        public bool IsPBErrorHalfFWD { get; private set; }

        public bool IsPBErrorHalfRVS { get; private set; }

        public bool IsPBErrorCamHome { get; private set; }

        public bool IsPBErrorCamExit { get; private set; }

        public bool IsPBErrorCamBack { get; private set; }

        public bool IsDetectSensor5WhileInit { get; private set; }

        public bool IsDetectSensor6WhileInit { get; private set; }

        public bool IsDetectSensor7WhileInit { get; private set; }

        public bool IsErrorMainMotor { get; private set; }

        public bool IsErrorSideJog { get; private set; }

        public bool IsErrorSideJogRVS { get; private set; }

        public bool IsErrorPropeller { get; private set; }

        public bool IsErrorPickUpFWD { get; private set; }

        public bool IsErrorPickUpRVS { get; private set; }

        public bool IsErrorPlateUp { get; private set; }

        public bool IsErrorPlateDown { get; private set; }

        public bool IsPBHomeCamClose { get; private set; }

        public bool IsPBHomeCamOpen { get; private set; }

        public bool IsPBHomeCamCollect { get; private set; }

        public bool IsPHomeHalf { get; private set; }

        private byte CMD;
        private BitArray bit_Status1;
        private BitArray bit_Status2;
        private BitArray bit_Sensor1;
        private BitArray bit_Sensor2;
        private BitArray bit_Sensor3;
        private BitArray bit_Motor;
        private BitArray bit_Error1;
        private BitArray bit_Error2;
        private BitArray bit_Error3;
        private BitArray bit_MotorError;
        private BitArray bit_MIO4Status;
        private BitArray bit_Version;
    }
}
