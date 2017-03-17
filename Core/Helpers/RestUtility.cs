using System.Configuration;
using RestSharp;
using DinoNotes.Core.Security;

namespace DinoNotes.Core.Helpers {
    public class RestUtility<T> {
        public string ApiHost { get; set; }
        public Token Token { get; set; }
        public string ResultRaw { get; set; }
        public T Result { get; set; }

        public RestUtility(string apiHost, Token token) {
            this.ApiHost = apiHost;
            this.Token = token;
        }

        public bool SendGet<T>() {
            bool result = false;
            return result;
        }

        public bool SendPost<T>() {
            bool result = false;
            return result;
        }
    }
}
