namespace AdaStore.UI.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string url);
        Task<HttpResponseMessage> Post<T>(string url, T enviar);
    }
}
