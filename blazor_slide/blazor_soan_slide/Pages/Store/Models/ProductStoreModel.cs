namespace blazor_soan_slide.ModelsOther;

using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

public partial class ProductStoreModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("shortDescription")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; }

    [JsonPropertyName("imgLink")]
    public string ImgLink { get; set; }
}




