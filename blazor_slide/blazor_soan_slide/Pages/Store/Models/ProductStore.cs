namespace blazor_soan_slide.Models;
using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

public partial class ProductStore
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("alias")]
    public string Alias { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("feature")]
    public bool Feature { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("size")]
    public double[] Size { get; set; }

    [JsonPropertyName("shortDescription")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; }

    [JsonPropertyName("detaildetailedImages")]
    public string[] DetaildetailedImages { get; set; }

    [JsonPropertyName("image")]
    public Uri Image { get; set; }

    [JsonPropertyName("imgLink")]
    public string ImgLink { get; set; }

    [JsonPropertyName("categories")]
    public Category[] Categories { get; set; }

    [JsonPropertyName("relatedProducts")]
    public RelatedProduct[] RelatedProducts { get; set; }
}

public partial class Category
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("category")]
    public string CategoryCategory { get; set; }
}

public partial class RelatedProduct
{
    [JsonPropertyName("id")]
    public double Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("alias")]
    public string Alias { get; set; }

    [JsonPropertyName("feature")]
    public bool Feature { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("shortDescription")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("image")]
    public Uri Image { get; set; }

    [JsonPropertyName("imgLink")]
    public object ImgLink { get; set; }
}