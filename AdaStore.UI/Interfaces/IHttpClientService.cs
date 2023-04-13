namespace AdaStore.UI.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Post2<T, TResponse>(string url, T enviar);
    }
}
