using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Utils
{
    class WebService
     {
        private readonly string token;
        private readonly string apiSecret;

        public WebService(string token, string apiSecret)
        {
            this.token = token;
            this.apiSecret = apiSecret;
        }

        internal  async Task<string> HttpClientCall(string url, string methodName, HttpMethod httpMethod, string requestString = default(string))
        {
            try
            {
                HttpResponseMessage response = await CreateResponse(url, methodName, httpMethod, requestString);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return string.Empty;
                }
                string responseAsString = await response.Content.ReadAsStringAsync();
                return responseAsString;
            }
            catch
            {
                return string.Empty;
            }
        }

        internal async Task<HttpResponseMessage> CreateResponse(string url, string methodName, HttpMethod httpMethod, string requestString)
        {
            HttpClient httpClient = new HttpClient();

            var signature = HMACHashCreator.GetSHA256Key(url + methodName, apiSecret, requestString);
            httpClient.DefaultRequestHeaders.Authorization = CreateBasicHeader(token, signature);
            var request = new HttpRequestMessage(httpMethod, url);
            if (httpMethod == HttpMethod.Post)
            {
                request.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
            }
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return response;
        }

        private  AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(username + ":" + password);
            var res = Convert.ToBase64String(byteArray);
            return new AuthenticationHeaderValue("Basic", res);
        }
        
    }
}
