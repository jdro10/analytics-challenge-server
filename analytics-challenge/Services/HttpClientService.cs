using analytics_challenge.Exceptions;
using analytics_challenge.Services.Interfaces;

namespace analytics_challenge.Services
{
    public sealed class HttpClientService : IHttpClientService
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpClientService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this._configuration = configuration;
            this._apiUrl = this._configuration["ApiSettings:ApiUrl"] ?? string.Empty;
            this._apiKey = this._configuration["ApiSettings:ApiKey"] ?? string.Empty;
            this._httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GetAsync(string endpoint)
        {
            this.ValidateApiConfiguration();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{this._apiUrl}/{endpoint}");
            request.Headers.Add("X-API-Key", _apiKey);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();

            }

            return string.Empty;
        }

        public async Task<string> PostAsync(string endpoint, string body)
        {
            this.ValidateApiConfiguration();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{this._apiUrl}/{endpoint}");
            request.Headers.Add("X-API-Key", _apiKey);
            request.Content = JsonContent.Create(body);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();

            }

            return string.Empty;
        }

        private void ValidateApiConfiguration()
        {
            if (string.IsNullOrEmpty(this._apiUrl) || string.IsNullOrEmpty(this._apiKey))
            {
                throw new ConfigurationException("Invalid API configuration. Please update the API URL and API KEY in the appsettings.json file!");
            }

        }
    }
}
