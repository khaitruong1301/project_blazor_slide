

using blazor_soan_slide.Models;
using blazor_soan_slide.ModelsOther;
using blazor_soan_slide.Services.Utility;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class ProductStoreService
{
    private readonly HttpClient _httpStore;
    public ProductStoreService(IServiceProvider serviceProvider)
    {
        _httpStore = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("apiStore"); ;
    }
    public async Task<ProductStoreModel[]> GetAllProductAsync(string keyword = "")
    {
        // Sử dụng ExternalHttpClient
        string url = "/api/Product";
        if (!string.IsNullOrEmpty(keyword))
        {
            url += $"{url}?keyword={keyword}";
        }
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStoreModel[]>>(url);
        return res.content;
    }

    public async Task<ProductStore[]> CreateProduct(ProductStore newProduct)
    {
        // Sử dụng ExternalHttpClient
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>("api/Product");
        return res.content;
    }
    public async Task<ProductStore> GetProductById(string id="")
    {
        if (!string.IsNullOrEmpty(id))
        {
            // Sử dụng ExternalHttpClient
            var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore>>($"api/Product/getbyid?id={id}");
            var productModel = FunctionUtility.MapToModel<ProductStore>(res.content);
            return productModel;
        }
        return new ProductStore();
           // var apiResponse = new ApiResponse { Id = 1, Name = "Product A", Price = 100, Alias = "PA", Size = "M" };
    // var productModel = MapToModel<ProductModel>(apiResponse);

    }
    public async Task<ProductStore[]> UpdateProduct(int id, ProductStore product)
    {
        // Sử dụng ExternalHttpClient
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>("api/Product");
        return res.content;
    }
    public async Task<ProductStore[]> DeleteProduct(int id)
    {
        // Sử dụng ExternalHttpClient
        var res = await _httpStore.GetFromJsonAsync<HttpResponse<ProductStore[]>>("api/Product");
        return res.content;
    }
}
