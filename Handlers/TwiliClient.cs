using Twilio.Clients;
using Twilio.Http;

namespace praktika.Handlers
{
    public class TwiliClient : ITwilioRestClient
    {
        private readonly ITwilioRestClient _innerClient;

        public TwiliClient(IConfiguration config, System.Net.Http.HttpClient httpclient)
        {
            httpclient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");
            _innerClient = new TwilioRestClient(
                config["twilio:AccountSid"],
                config["twilio:AuthToken"],
                httpClient: new SystemNetHttpClient(httpclient));
        }

        public string AccountSid => _innerClient.AccountSid;
        public string Region => _innerClient.Region;
        public Twilio.Http.HttpClient HttpClient => _innerClient.HttpClient;

        public Response Request(Request request) => _innerClient.Request(request);     
        public Task<Response> RequestAsync(Request request) => _innerClient.RequestAsync(request);        
    }
}
