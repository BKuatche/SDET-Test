using RestSharp;

namespace JsonPlaceHolder.Api.Test.Base
{
    public class Settings
    {
        public IRestResponse Response { get; set; }
        public IRestRequest Request { get; set; }
        public RestClient RestClient { get; set; }
    }
}
