using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Utility
{
    class HttpUtil
    {
        /// <summary>
        /// Get HTTP GET Request.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The response string</returns>
        public static string HttpGetRequest(string url)
        {
            var request = CreateHttpQuery(url);
            var response = (HttpWebResponse)request.GetResponse();
            return getResponseString(response);
        }

        /// <summary>
        /// Get HTTP POST Request.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The response string</returns>
        public static string HttpPostRequest(string url, string requestBody)
        {
            var request = CreateHttpPostQuery(url);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(requestBody);
            }
            var response = (HttpWebResponse)request.GetResponse();
            return getResponseString(response);
        }

        /// <summary>
        /// Get HTTP DELETE Request.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The response string</returns>
        public static string HttpDeleteRequest(string url)
        {
            var request = CreateHttpDeleteQuery(url);
            var response = (HttpWebResponse)request.GetResponse();
            return getResponseString(response);
        }

        /// <summary>
        /// Get HTTP PUT Request.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <param name="requestBody">The request body</param>
        /// <returns>The response string</returns>
        public static string HttpPutRequest(string url, string requestBody)
        {
            var request = CreateHttpPutQuery(url);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(requestBody);
            }
            var response = (HttpWebResponse)request.GetResponse();
            return getResponseString(response);
        }

        /// <summary>
        /// Gets the HttpWebRequest for PUT Method.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The HttpWebRequest</returns>
        private static HttpWebRequest CreateHttpPutQuery(string url)
        {
            var webRequest = CreateHttpQuery(url);
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            return webRequest;
        }

        /// <summary>
        /// Gets the HttpWebRequest for POST Method.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The HttpWebRequest</returns>
        private static HttpWebRequest CreateHttpPostQuery(string url)
        {
            var webRequest = CreateHttpQuery(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            return webRequest;
        }

        /// <summary>
        /// Gets the HttpWebRequest for DELETE Method.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The HttpWebRequest</returns>
        private static HttpWebRequest CreateHttpDeleteQuery(string url)
        {
            var webRequest = CreateHttpQuery(url);
            webRequest.Method = "DELETE";
            webRequest.ContentType = "application/json";
            return webRequest;
        }

        /// <summary>
        /// Gets the HttpWebRequest for GET Method.
        /// </summary>
        /// <param name="url">The URL to process</param>
        /// <returns>The HttpWebRequest</returns>
        private static HttpWebRequest CreateHttpQuery(string url)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            return webRequest;
        }

        /// <summary>
        /// Gets the HttpWebRequest for GET Method.
        /// </summary>
        /// <param name="response">The URL to process</param>
        /// <returns>The response in stringa</returns>
        private static string getResponseString(HttpWebResponse response)
        {

            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;
        }
    }
}
