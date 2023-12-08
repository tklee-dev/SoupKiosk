using System;
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
        //http://192.168.0.34:6008/info/Service1.svc/getdata/ABC?callback=123
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        public Stream GetData(string value)
        {
            DevicesState deviceState = new DevicesState();
            deviceState.HID = "999";
            deviceState.ProximitySensor = "999";
            deviceState.StaplerPrinter = "999";

            string jsonData = serializer.Serialize(deviceState);

            //CORS정책 대응코드
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            //JSONP의 MIME타입
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/javascript";

            //jsonData = Regex.Unescape(jsonData);
            string callback = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["callback"];
            string jsonpResponse = string.Format("{0}({1})", callback, jsonData);

           // return jsonpResponse;
            return new MemoryStream(Encoding.UTF8.GetBytes(jsonpResponse));
        }
    }
}
