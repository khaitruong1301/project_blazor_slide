using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }

    public double Price { get; set; } // Đổi từ decimal sang double hoặc int
    public string Description { get; set; }
    public string Size { get; set; }
    public List<string> Sizes { get; set; }
    public string ShortDescription { get; set; }
    
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]

    public int Quantity { get; set; }
    public bool Deleted { get; set; }
    public string Categories { get; set; }
    public string RelatedProducts { get; set; }
    public bool Feature { get; set; }
    public string Image { get; set; }
    public string ImgLink { get; set; }
}

public partial class ProductCardModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }

    public double Price { get; set; } // Đổi từ decimal sang double hoặc int
    public string Description { get; set; }
    public string Size { get; set; }
    public List<string> Sizes { get; set; }
    public string ShortDescription { get; set; }
    
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]

    public int Quantity { get; set; }
    public bool Deleted { get; set; }
    public string Categories { get; set; }
    public string RelatedProducts { get; set; }
    public bool Feature { get; set; }
    public string Image { get; set; }
    public string ImgLink { get; set; }
}
