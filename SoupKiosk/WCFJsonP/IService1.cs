﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFJsonP
{
    //http://localhost:60372/Service1.svc/getdata/111?callback=222
    //http://localhost:60372/Service1.svc/setdataHID/99
    //http://localhost:60372/Service1.svc/setdataStaplerPrinter/99
    //http://localhost:60372/Service1.svc/SetDataSensor/77

    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IService1"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "GetData/{value}", ResponseFormat = WebMessageFormat.Json)]
        Stream GetData(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetDataHID/{value}", ResponseFormat = WebMessageFormat.Json)]
        void SetDataHID(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetDataSensor/{value}", ResponseFormat = WebMessageFormat.Json)]
        void SetDataSensor(string value);

        [OperationContract]
        [WebGet(UriTemplate = "SetDataStaplerPrinter/{value}", ResponseFormat = WebMessageFormat.Json)]
        void SetDataStaplerPrinter(string value);

        // TODO: 여기에 서비스 작업을 추가합니다.
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

    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
