using JsonPlaceHolder.Api.Test.Ressources;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace JsonPlaceHolder.Api.Test.Helpers
{
    public class RestClientHelper
    {
        private readonly IRestClient _client;
        private readonly IRestRequest _restRequest;

        public RestClientHelper()
        {
            _client = new RestClient();
            _restRequest = new RestRequest();
        }

        public async Task<IRestResponse<T>> GetAsync<T>(IRestRequest restRequest) where T : class, new()
        {
            IRestResponse<T> restResponse = default;
            try
            {
                _client.BaseUrl = new Uri(Constants.Ressource.BaseUrl);
                restResponse = await _client.ExecuteGetAsync<T>(restRequest);

                return restResponse;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                const string message = "Error retrieving response.";
                throw new ApplicationException(message, restResponse.ErrorException);

            }

        }


        public IRestRequest GetRestRequest(string endpoint)
        {
            try
            {
                _restRequest.Resource = endpoint;
                _restRequest.Method = Method.GET;
                _restRequest.AddHeader("Content-Type", "application/json");

                return _restRequest;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                throw e;
            }

        }
    }
}
