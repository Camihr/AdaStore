using AdaStore.Shared.Models;
using AdaStore.UI.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AdaStore.UI.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private JsonSerializerOptions jsonDefaulOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        private readonly IHttpClientService _httpClientService;
        private string _apiUrl;

        public ProductsRepository(IConfiguration configuration, IHttpClientService httpClientService)
        {
            _apiUrl = configuration.GetValue<string>("ApiUrl");
            _httpClientService = httpClientService;
        }

        //public async Task<HttpResponseBase<List<Product>>> GetProducts()
        //{
        //    try
        //    {
        //        var url = $"{_apiUrl}Product";
        //        var httpResponse = await _httpClientService.Get(url);

        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            var response = await DeserializeResponse<List<Product>>(httpResponse, jsonDefaulOptions);
        //            return new HttpResponse<List<Product>>(false, response, httpResponse);
        //        }
        //        else
        //        {
        //            return new HttpResponse<List<Product>>(true, default, httpResponse);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        //return new HttpResponse<List<Product>>(true, default);
        //    }
        //}

        //private async Task<T> DeserializeResponse<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        //{
        //    var responseString = await httpResponse.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        //}
    }
}
