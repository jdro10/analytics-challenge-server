using analytics_challenge.Exceptions;
using analytics_challenge.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

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

        /// <summary>
        /// Perfoms an HTTP POST request to a specific endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The body data</param>
        /// <returns>The API response or empty string in case of an error code</returns>
        public async Task<string> PostAsync(string endpoint, object body)
        {
            this.ValidateApiConfiguration();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{this._apiUrl}/{endpoint}");
            request.Headers.Add("X-API-Key", _apiKey);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates if the API is correctly configured
        /// </summary>
        private void ValidateApiConfiguration()
        {
            if (string.IsNullOrEmpty(this._apiUrl) || string.IsNullOrEmpty(this._apiKey))
            {
                throw new ConfigurationException("Invalid API configuration. Please update the API URL and API KEY in the appsettings.json file!");
            }
        }
    }
}
