using System.Globalization;
using System.Text.Json.Serialization;

namespace SearchWebApp.Models;

public class Camera
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    public override string ToString()
    {
        CultureInfo cultureInfo = new CultureInfo("en-US");
        return $"{Id} | {Name} | {Latitude.ToString("G", cultureInfo)} | {Longitude.ToString("G", cultureInfo)}";
    }
}
