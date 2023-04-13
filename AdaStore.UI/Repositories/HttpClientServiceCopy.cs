using System.Text.Json;
using System.Text;
using AdaStore.UI.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AdaStore.UI.Repositories
{
    public class HttpClientServiceCopy 
    {
        private string _apiToken;

        private JsonSerializerOptions jsonDefaulOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public HttpClientServiceCopy(IConfiguration configuration)
        {
            _apiToken = configuration.GetValue<string>("ApiToken");
        }

        //public async Task<HttpResponseBase<object>> Post<T>(string url, T body)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        AddBasicAuthHeader(client);
        //        var sendJson = JsonSerializer.Serialize(body);
        //        var sendContent = new StringContent(sendJson, Encoding.UTF8, "application/json");
        //        var httpResponse = await client.PostAsync(url, sendContent);

        //        return new HttpResponse<object>(!httpResponse.IsSuccessStatusCode, null, httpResponse);
        //    }
        //}

        //public async Task<HttpResponseBase<TResponse>> Post<T, TResponse>(string url, T enviar)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        AddBasicAuthHeader(client);
        //        var enviarJSON = JsonSerializer.Serialize(enviar);
        //        var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
        //        var responseHttp = await client.PostAsync(url, enviarContent);

        //        if (responseHttp.IsSuccessStatusCode)
        //        {
        //            var response = await DeserializeResponse<TResponse>(responseHttp, jsonDefaulOptions);
        //            return new HttpResponse<TResponse>(false, response, responseHttp);
        //        }
        //        else
        //        {
        //            return new HttpResponse<TResponse>(true, default, responseHttp);
        //        }
        //    }
        //}

        //public async Task<HttpResponseBase<object>> Put<T>(string url, T body)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        AddBasicAuthHeader(client);
        //        var sendJson = JsonSerializer.Serialize(body);
        //        var sendContent = new StringContent(sendJson, Encoding.UTF8, "application/json");
        //        var httpResponse = await client.PutAsync(url, sendContent);

        //        return new HttpResponse<object>(!httpResponse.IsSuccessStatusCode, null, httpResponse);
        //    }
        //}

        //public async Task<HttpResponseBase<T>> Get<T>(string url)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        AddBasicAuthHeader(client);
        //        var httpResponse = await client.GetAsync(url);

        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            var response = await DeserializeResponse<T>(httpResponse, jsonDefaulOptions);
        //            return new HttpResponse<T>(false, response, httpResponse);
        //        }
        //        else
        //        {
        //            return new HttpResponse<T>(true, default, httpResponse);
        //        }
        //    }
        //}

        //public async Task<HttpResponseBase<object>> Delete(string url)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        AddBasicAuthHeader(client);
        //        var httpResponse = await client.DeleteAsync(url);

        //        return new HttpResponse<object>(!httpResponse.IsSuccessStatusCode, null, httpResponse);
        //    }
        //}

        //private async Task<T> DeserializeResponse<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        //{
        //    var responseString = await httpResponse.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        //}

        //private void AddBasicAuthHeader(HttpClient client)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes($"{_apiToken}:ADMIN");
        //    string base64 = Convert.ToBase64String(bytes);

        //    var headers = new Dictionary<string, string>()
        //    {
        //      { "Authorization", $"Basic {base64}"}
        //    };

        //    client.DefaultRequestHeaders.Add(headers.FirstOrDefault().Key, headers.FirstOrDefault().Value);
        //}
    }
}