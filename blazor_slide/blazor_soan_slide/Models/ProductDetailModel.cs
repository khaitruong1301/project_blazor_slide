using System.Text.Json.Serialization;

public partial class ProductDetailModel
{
    public double Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public double Price { get; set; }
    public bool Feature { get; set; }
    public string Description { get; set; }
    public double[] Size { get; set; }
    public string ShortDescription { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public double Quantity { get; set; }
    public string[] DetaildetailedImages { get; set; }
    public string Image { get; set; }
    public string ImgLink { get; set; }
    public Category[] Categories { get; set; }
    public RelatedProduct[] RelatedProducts { get; set; }
}

public partial class Category
{
    public string Id { get; set; }
    public string CategoryCategory { get; set; }
}

public partial class RelatedProduct
{
    public double Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public bool Feature { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]

    public double Price { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string Image { get; set; }
    public object ImgLink { get; set; }
}