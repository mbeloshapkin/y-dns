using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace y_check
{
    class Program {
        //
        const string api_getIP = "http://ipv4.internet.yandex.net/internet/api/v0/ip";

        static void Main(string[] args){
            string ip_resp = Get(api_getIP).Trim('"');

            Console.Write(ip_resp);
        }

        static string Get(string req) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(req);
            request.Method = "GET";
            string strResponce = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResponce = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            return strResponce;
        }

    }
}
