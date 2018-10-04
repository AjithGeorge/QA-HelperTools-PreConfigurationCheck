using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Check_PreCondition_v2
{
    class GetRequest
    {
        public string get(string username,string password, string baseurl, string endpoint)
        {
            string Baseurl = baseurl;
            string Endpoint = endpoint;
            string Username = username;
            string Password = password;


            //string credentials = "ajith.george@gadgeon.com:Welcome*123";
            string credentials = Username + ":" + Password;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(Baseurl+Endpoint);
            req.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));
            req.PreAuthenticate = true;
            req.Method = "GET";
            req.ContentType = "application/json";


            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            return responseFromServer;
        }

    }
}
