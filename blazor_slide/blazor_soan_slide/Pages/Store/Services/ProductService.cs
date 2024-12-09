using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using blazor_soan_slide.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

public class ProductStoreService
{
    private readonly HttpClient _httpStore;
    public ProductStoreService(IServiceProvider serviceProvider)
    {
        _httpStore = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("apiStore");;
    }
    public async Task<ProductStore[]> GetAllProductAsync(string keyword="")
    {
        // Sử dụng ExternalHttpClient
        string url = "/api/Product";
        if(!string.IsNullOrEmpty(keyword)){
            url += $"{url}?keyword={keyword}";
        }
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>(url);
        Console.WriteLine(JsonConvert.SerializeObject(res));
        return res.content;
    }

    public async Task<ProductStore[]> CreateProduct(ProductStore newProduct)
    {
        // Sử dụng ExternalHttpClient
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>("api/Product");
        Console.WriteLine(JsonConvert.SerializeObject(res));
        return res.content;
    }
    public async Task<ProductStore[]> UpdateProduct(int id, ProductStore product)
    {
        // Sử dụng ExternalHttpClient
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>("api/Product");
        Console.WriteLine(JsonConvert.SerializeObject(res));
        return res.content;
    }
    public async Task<ProductStore[]> DeleteProduct(int id)
    {
        // Sử dụng ExternalHttpClient
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>("api/Product");
        Console.WriteLine(JsonConvert.SerializeObject(res));
        return res.content;
    }
}
