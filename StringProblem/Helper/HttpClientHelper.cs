using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;  

namespace StringProblem.Helper
{
    public class HttpClientHelper
    {
        public static string GetAsync(string url)
        {

            var request = (HttpWebRequest)System.Net.WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            
            string responseText = string.Empty;
            HttpWebResponse response = null;
            try
            {
                request.ContentLength = 0;

                
                response = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    response = (HttpWebResponse)ex.Response;
                }
            }

            return responseText;
        }
    }
}