using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;


namespace AD.Research.WebApi.Client
{
    public class HttpServiceClientBase
    {
        private string baseURL;
        private TimeSpan clientTimeout;
        #region Constructors
        public HttpServiceClientBase(string baseUrl)
        {
            this.baseURL = baseUrl;
        }
        #endregion

        #region Properties
        public string BaseURL
        {
            get
            {
                return this.baseURL;
            }
        }

        public TimeSpan ClientTimeout
        {
            get
            {
                return this.clientTimeout;
            }
        }
        #endregion

        #region Procedures
        /// <summary>
        /// Currently encountering problem with JSON.NET 4.5.0 library
        /// </summary>
        /// <param name="endpointURL"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected HttpResponseMessage HttpRequestAndReceive<T>(
            string endpointURL,
            MediaTypeFormatter formatter, T item, string type) where T : class
        {

            StringBuilder urlBuilder = new StringBuilder(BaseURL);
            urlBuilder.Append(endpointURL);

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = ClientTimeout;

                HttpResponseMessage response = null;
                try
                {
                    Task<HttpResponseMessage> requestTask = null;

                    switch (type)
                    {
                        case "POST":
                            requestTask =
                                client.PostAsync(urlBuilder.ToString(), item, formatter);
                            break;
                        case "PUT":
                            requestTask =
                                client.PutAsync(urlBuilder.ToString(), item, formatter);
                            break;
                        case "DELETE":
                            requestTask =
                                client.DeleteAsync(urlBuilder.ToString());
                            break;
                        default:
                            requestTask =
                               client.GetAsync(urlBuilder.ToString());
                            break;
                    }

                    requestTask.Wait();
                    response = requestTask.Result;

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            throw new HttpListenerException((int)HttpStatusCode.BadRequest,
                                "An improperly formatted message has been sent to the ivr service.");
                        case HttpStatusCode.InternalServerError:
                            throw new HttpListenerException((int)HttpStatusCode.InternalServerError,
                                "An error has occured in the ivr service.");
                        case HttpStatusCode.OK:
                            var logStr = response.Content.ReadAsStringAsync().Result;
                            break;
                        case HttpStatusCode.Accepted:
                            var jsonStr = response.Content.ReadAsStringAsync().Result;
                            break;
                        default:
                            throw new HttpListenerException((int)response.StatusCode, "An unpredicted status code has been received.");
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        #endregion
    }
}
