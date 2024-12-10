using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponse<Product>> GetProductByIdAsync(int? productId=0)
    {
        try
        {
            // Định nghĩa URL với tham số productId
            var url = $"https://apistore.cybersoft.edu.vn/api/Product/getbyid?id={productId}";

            // Gửi yêu cầu GET đến API
            var response = await _httpClient.GetAsync(url);

            // Kiểm tra nếu response không thành công, ném ngoại lệ
            response.EnsureSuccessStatusCode();

            // Đọc dữ liệu JSON trả về từ API
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Chuyển đổi JSON sang đối tượng Product
            var product = JsonSerializer.Deserialize<HttpResponse<Product>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return product ?? throw new Exception("Không thể chuyển đổi JSON sang đối tượng Product");
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"Lỗi HTTP: {httpEx.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi xảy ra: {ex.Message}");
            return null;
        }
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
