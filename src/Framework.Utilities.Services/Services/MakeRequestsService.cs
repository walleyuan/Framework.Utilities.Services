// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MakeRequestsService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the MakeRequestsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.Services
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using Enums;

    using Newtonsoft.Json;

    /// <summary>
    /// The make requests service.
    /// </summary>
    public class MakeRequestsService
    {
        /// <summary>
        /// The get authenticate token.
        /// </summary>
        /// <param name="method"> The method. </param>
        /// <param name="contentType"> The content type. </param>
        /// <param name="requestTokenUri"> The request token uri. </param>
        /// <param name="postData"> The body. </param>
        /// <returns> The <see cref="T"/>. </returns>
        public static T GetAuthenticateToken<T>(RequestMethod method, string contentType, string requestTokenUri, string postData)
        {
            var response = MakeRequest(method, contentType, requestTokenUri, postData);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseText = reader.ReadToEnd();

                    var token = JsonConvert.DeserializeObject<T>(responseText);

                    return token;
                }
            }

            return default(T);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="contentType"> The content type. </param>
        /// <param name="requestTokenUri"> The request token uri. </param>
        /// <param name="token"> The token. </param>
        /// <typeparam name="T"> Response type. </typeparam>
        /// <returns> Given type of object. </returns>
        public static T Get<T>(string contentType, string requestTokenUri, string token)
        {
            var response = MakeRequest(RequestMethod.Get, contentType, requestTokenUri, token: token);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseText = reader.ReadToEnd();

                    var obj = JsonConvert.DeserializeObject<T>(responseText);

                    return obj;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Get make request
        /// </summary>
        /// <param name="contentType">content type</param>
        /// <param name="requestTokenUri">request token uri</param>
        /// <param name="token">token</param>
        /// <returns>HttpWebResponse</returns>
        public static HttpWebResponse Get(string contentType, string requestTokenUri, string token)
        {
           return MakeRequest(RequestMethod.Get, contentType, requestTokenUri, token: token);
        }

        /// <summary>
        /// The make request.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="contentType">
        /// The content type. i.e. application/json, text/plain.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="postData">
        /// The post data.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="HttpWebResponse"/>.
        /// </returns>
        private static HttpWebResponse MakeRequest(RequestMethod method, string contentType, string url, string postData = "", string token = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = method.ToString().ToUpper();
            request.ContentType = contentType;
            request.ContentLength = data.Length;
            request.Timeout = 60000;

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", token);
            }

            try
            {
                if (request.Method == "POST")
                {
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                var response = (HttpWebResponse)request.GetResponse();
                
                return response;
            }
            catch (WebException ex)
            {
                return (HttpWebResponse)ex.Response;
            }
        }

        /// <summary>
        /// The make async request.
        /// </summary>
        /// <param name="contentType">
        /// The content type.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<T> MakeAsyncRequest<T>(string contentType, string url, string token = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = contentType;
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 60000;
            request.Proxy = null;

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers[HttpRequestHeader.Authorization] = $"Bearer {token}";
            }

            Task<WebResponse> getResponseTask = request.GetResponseAsync();

            WebResponse response = await getResponseTask;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader readStream = new StreamReader(stream, Encoding.UTF8);

                var responseText = readStream.ReadToEnd();

                var obj = JsonConvert.DeserializeObject<T>(responseText);

                return obj;
            }
        }
    }
}