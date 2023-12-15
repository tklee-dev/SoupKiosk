using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KGClient
{
    public class RequestHTTP
    {
        public void SetDataToServer(string url)
        {
            try
            {
                string responseText = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 30 * 1000; // 30초
                request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법

                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    HttpStatusCode status = resp.StatusCode;
                    Console.WriteLine(status);  // 정상이면 "OK"

                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader sr = new StreamReader(respStream))
                    {
                        responseText = sr.ReadToEnd();
                    }
                }

                Console.WriteLine(responseText);
            }
            catch (Exception e)
            {
                //MessageBox.Show("WEB Exception: "+ url);
                Logger.Log("[WEB] Exception: " + e.ToString());
            }
        }
    }
}
