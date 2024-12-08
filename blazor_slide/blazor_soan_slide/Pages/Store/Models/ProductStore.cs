namespace blazor_soan_slide.Models;
using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

public partial class ProductStore
{
    [JsonPropertyName("id")]
    public double Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("alias")]
    public string Alias { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("size")]
    public string Size { get; set; }

    [JsonPropertyName("sizes")]
    public double[] Sizes { get; set; }

    [JsonPropertyName("shortDescription")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("categories")]
    public string Categories { get; set; }

    [JsonPropertyName("relatedProducts")]
    public string RelatedProducts { get; set; }

    [JsonPropertyName("feature")]
    public bool Feature { get; set; }

    [JsonPropertyName("image")]
    public Uri Image { get; set; }

    [JsonPropertyName("imgLink")]
    public Uri ImgLink { get; set; }
}