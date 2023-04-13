using AdaStore.Shared.Models;
using AdaStore.UI.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AdaStore.UI.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IHttpClientService _httpClientService;
        private string _apiUrl;

        //public OrdersRepository(IConfiguration configuration, IHttpClientService httpClientService)
        //{
        //    _apiUrl = configuration.GetValue<string>("ApiUrl");
        //    _httpClientService = httpClientService;
        //}

        //public async Task<HttpResponseBase<object>> CreateOrder<T>(Product product)
        //{
        //    var url = $"{_apiUrl}/Orders";
        //    var httpResponse = await _httpClientService.Post("", product);
           
        //    return new HttpResponse<object>(!httpResponse.IsSuccessStatusCode, null, httpResponse);
        //}

        //private async Task<T> DeserializeResponse<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        //{
        //    var responseString = await httpResponse.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        //}
    }
}
