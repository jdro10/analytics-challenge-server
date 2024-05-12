namespace analytics_challenge.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> PostAsync(string endpoint, object body);
    }
}
