using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFJsonP
{
    //http://localhost:60372/Service1.svc/getdata/111?callback=222

    //http://localhost:60372/Service1.svc/setdataHID/99
    //http://localhost:60372/Service1.svc/setdataStaplerPrinter/99
    //http://localhost:60372/Service1.svc/SetDataSensor/77

    //http://localhost:60372/Service1.svc/setdata/tts/test123
    //http://localhost:60372/Service1.svc/GetdataTTS



    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IService1"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IService1
    {
        /* WCF <> K사 */
        [OperationContract]
        [WebGet(UriTemplate = "GetData/{value}", ResponseFormat = WebMessageFormat.Json)]
        Stream GetData(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetData/tts/{value}", ResponseFormat = WebMessageFormat.Json)]
        void TTS(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetData/reboot", ResponseFormat = WebMessageFormat.Json)]
        void Reboot();



        /*  WCF <> Client */
        [OperationContract]
        [WebGet(UriTemplate = "SetDataHID/{value}", ResponseFormat = WebMessageFormat.Json)]
        void SetDataHID(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetDataSensor/{value}", ResponseFormat = WebMessageFormat.Json)]
        void SetDataSensor(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetDataStaplerPrinter/{value}", ResponseFormat = WebMessageFormat.Json)]
        void SetDataStaplerPrinter(string value);

        [OperationContract]
        [WebGet(UriTemplate = "GetdataTTS", ResponseFormat = WebMessageFormat.Json)]
        Stream GetdataTTS();

        [OperationContract]
        [WebGet(UriTemplate = "GetdataReboot", ResponseFormat = WebMessageFormat.Json)]
        Stream GetdataReboot();


    }
    // 아래 샘플에 나타낸 것처럼 데이터 계약을 사용하여 복합 형식을 서비스 작업에 추가합니다.

    [DataContract]
    public class State
    {
        [DataMember(Order = 0)]
        public string ServerState { get; set; }

        [DataMember(Order = 1)]
        public string HID { get; set; }

        [DataMember(Order = 2)]
        public string ProximitySensor { get; set; }

        [DataMember(Order = 3)]
        public string StaplerPrinter { get; set; }
    }

    [DataContract]
    public class TTSState
    {
        public string Text { get; set; }
    }

    [DataContract]
    public class RebootState
    {
        public bool IsReboot { get; set; }
    }
}
