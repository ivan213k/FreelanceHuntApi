using FreelanceHuntApi.Model;
using FreelanceHuntApi.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntAPI
{
    public class FreelancehuntApi
    {
        private readonly string token;
        private readonly string apiSecret;

        public FreelancehuntApi(string token, string apiSecret)
        {
            this.token = token;
            this.apiSecret = apiSecret;
        }
        #region WebService
        private async Task<string> HttpClientCall(string url, string methodName, HttpMethod httpMethod, string requestString = default(string))
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

        private async Task<HttpResponseMessage> CreateResponse(string url, string methodName, HttpMethod httpMethod, string requestString)
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

        private AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(username + ":" + password);
            var res = Convert.ToBase64String(byteArray);
            return new AuthenticationHeaderValue("Basic", res);
        }
        #endregion

        public async Task<Profile> GetAccountInfoAsync(string login = "me")
        {
            var url = $"https://api.freelancehunt.com/profiles/{login}";
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);
            Profile result = Profile.FromJson(response);
            return result;
        }

        public async Task<List<Message>> GetNewMessagesAsync()
        {
            var url = "https://api.freelancehunt.com/threads?filter=new";
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);

            var listMessage = Message.ListMessageFromJson(response);

            return listMessage;
        }

        public async Task<List<Message>> GetAllMessageAsync()
        {
            var url = "https://api.freelancehunt.com/threads";
            var response = await this.HttpClientCall(url, "GET", HttpMethod.Get);

            var listMessage = Message.ListMessageFromJson(response);

            return listMessage;
        }


    }
}
