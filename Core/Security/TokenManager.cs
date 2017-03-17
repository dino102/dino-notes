using System;
using Newtonsoft.Json;
using RestSharp;

namespace DinoNotes.Core.Security {
    public static class TokenManager {

        public static Token GetToken(string apiHost, string username, string password) {
            Token result = new Token();
            // call api token auth
            RestClient client = new RestClient(apiHost);
            RestRequest request = new RestRequest("/token", Method.POST);
            // set credentials
            string requestValue = $"grant_type=password&username={username}&password={password}";
            request.AddParameter("text/xml", requestValue, ParameterType.RequestBody);

            // get response
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                result = JsonConvert.DeserializeObject<Token>(response.Content);
            }
            else {
                result = null;
            }
            return result;
        }

    }
}
