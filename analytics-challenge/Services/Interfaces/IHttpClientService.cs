namespace analytics_challenge.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string endpoint);

        Task<string> PostAsync(string endpoint, string body);
    }
}
