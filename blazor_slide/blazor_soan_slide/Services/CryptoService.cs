// Services/CryptoService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json.Serialization; // Thư viện để thêm query string vào URL

public class CryptoService
{
    private readonly HttpClient _httpClient;

    // Constructor, inject HttpClient vào service
    public CryptoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Phương thức gọi API và trả về danh sách các đồng crypto
    public async Task<List<CryptoData>> GetCryptoDataAsync()
    {
        // URL gốc của API
        var url = "https://api.coingecko.com/api/v3/coins/markets";

        // Các tham số query cần thiết cho API
        var parameters = new Dictionary<string, string>
        {
            { "vs_currency", "usd" },
            { "order", "market_cap_desc" },
            { "per_page", "50" },
            { "page", "1" },
            { "sparkline", "false" }
        };

        // Tạo URI hoàn chỉnh với query string
        var uri = QueryHelpers.AddQueryString(url, parameters);

        // Tạo yêu cầu HTTP và thêm header User-Agent
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.Headers.Add("User-Agent", "YourAppName/1.0"); // Thay YourAppName bằng tên app của bạn

        // Gửi yêu cầu và chờ phản hồi
        var response = await _httpClient.SendAsync(request);

        // Đảm bảo phản hồi thành công, nếu không sẽ ném ngoại lệ
        response.EnsureSuccessStatusCode();

        // Đọc và parse JSON trả về thành danh sách CryptoData
        return await response.Content.ReadFromJsonAsync<List<CryptoData>>();
    }
}

// Models/CryptoData.cs
// Đây là model đại diện cho từng đồng crypto từ API CoinGecko
public class CryptoData
{
    public string Id { get; set; }            // ID của đồng crypto
    public string Symbol { get; set; }         // Ký hiệu (symbol) của đồng crypto
    public string Name { get; set; }           // Tên đầy đủ của đồng crypto
    public string Image {get;set;}
    [JsonPropertyName("current_price")]
    public decimal CurrentPrice { get; set; }  // Giá hiện tại (USD)
}
