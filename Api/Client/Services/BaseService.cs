namespace MovieFiles.Api.Client.Services
{
    public class BaseService
    {
        protected readonly MovieFilesFunctions _client;
        protected readonly string _functionAppKey;
        public BaseService(string httpUrl, string functionAppKey)
        {
            _client = new MovieFilesFunctions(new HttpClient { BaseAddress = new Uri(httpUrl) });
            _client.BaseUrl = httpUrl;
            _functionAppKey = functionAppKey;
        }

    }
}
