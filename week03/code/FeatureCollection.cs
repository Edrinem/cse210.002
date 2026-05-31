using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; } = new();
}

public class Properties
{
    [JsonPropertyName("place")]
    public string Place { get; set; } = "";

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}