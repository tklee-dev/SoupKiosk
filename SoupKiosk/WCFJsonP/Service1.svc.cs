﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace WCFJsonP
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "Service1"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서Service1.svc나 Service1.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class Service1 : IService1
    {

        public Service1()
        {

        }


        JavaScriptSerializer serializer = new JavaScriptSerializer();

        /* WCF <> K사 */

        public void TTS(string value)
        {
            SaveValues.TTSQueue.Enqueue(value);
        }

 
        public Stream GetData(string value)
        {
            //상태값 넣기
            State state = new State();
            state.ServerState = "02";
            state.HID = SaveValues.HID;
            state.ProximitySensor = SaveValues.ProximitySensor;
            state.StaplerPrinter = SaveValues.StaplerPrinter;

            //초기화
            SaveValues.Clear();

            //직렬화
            string jsonData = serializer.Serialize(state);

            //CORS정책 대응코드
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            //JSONP의 MIME타입
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/javascript";

            //JSONP형태로 변경
            string callback = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["callback"];
            string jsonpResponse = string.Format("{0}({1})", callback, jsonData);

            return new MemoryStream(Encoding.UTF8.GetBytes(jsonpResponse));
        }















        /*  WCF <> Client */

        //KGClient로 부터 값 입력 POST
        public void SetDataHID(string value)
        {
            SaveValues.HID = value;
        }

        public void SetDataSensor(string value)
        {
            SaveValues.ProximitySensor = value;
        }

        public void SetDataStaplerPrinter(string value)
        {
            SaveValues.StaplerPrinter = value;
        }

        public Stream GetdataTTS()
        {
            //TTS 입력값을 Client에 전달
            TTSState ttsState = new TTSState();

            if (SaveValues.TTSQueue.Count != 0)
                ttsState.Text = SaveValues.TTSQueue.Dequeue();
            else
                ttsState.Text = "";

            string jsonData = serializer.Serialize(ttsState);

            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/javascript";

            return new MemoryStream(Encoding.UTF8.GetBytes(jsonData));

        }
    }
}
