using System.Text.Json.Serialization;

namespace Model
{
  public class Gym
  {
    [JsonPropertyName("name")]
    public string _name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string _type { get; set; } = string.Empty;

    [JsonPropertyName("region")]
    public string _region { get; set; } = string.Empty;

    [JsonPropertyName("leader")]
    public string _leader { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string _city { get; set; } = string.Empty;

    public Gym()
    {
    }

    public Gym(string name, string type, string region, string leader, string city)
    {
      this._name = name;
      this._type = type;
      this._region = region;
      this._leader = leader;
      this._city = city;
    }
  }
}
