namespace blazor_soan_slide.Store.Hub;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using blazor_soan_slide.ModelsOther;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

public class ProductHub : Hub
{
    private readonly HttpClient _httpStore;
    private readonly ProductStoreService _productStoreService;
    public ProductHub(IServiceProvider serviceProvider,ProductStoreService productStoreService)
    {
        //Sử dụng http client
        _httpStore = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("apiStore");
        //Sử dụng service xây dựng sẵn
        _productStoreService = productStoreService;
    }
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var errorMessage = exception != null ? exception.Message : "No error information.";
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}, Error: {errorMessage}");
    }
    public async Task AddProduct(ProductStoreModel product)
    {
        _productStoreService.CreateProduct(product);
    }
    public async Task GetAllProduct(string message)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
}
