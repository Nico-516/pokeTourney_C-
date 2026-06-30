using System.Collections.Generic;
using System.Text.Json.Serialization;
using Model.Interfaces;

namespace Model
{
  public class Pokemon : IMakeNoise, IEntity
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string _name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public List<string> _type { get; set; } = new List<string>();

    [JsonPropertyName("attackPoints")]
    public int _attackPoints { get; set; }

    [JsonPropertyName("speedPoints")]
    public int _speedPoints { get; set; }

    [JsonPropertyName("sizeCm")]
    public int _sizeCm { get; set; }

    [JsonPropertyName("weightGrams")]
    public int _weightGrams { get; set; }

    [JsonPropertyName("attacks")]
    public List<string> _attacks { get; set; } = new List<string>();

    [JsonPropertyName("defencePoints")]
    public int _defencePoints { get; set; }

    [JsonPropertyName("healthPoints")]
    public int _healthPoints { get; set; }

    [JsonPropertyName("noise")]
    public string _noise { get; set; } = string.Empty;

    public string MakeNoise()
    {
      return _noise;
    }

    public Pokemon(){
    }

    public Pokemon(Pokemon other)
    {
      Id = other.Id;
      _name = other._name;
      _type = new List<string>(other._type);
      _attackPoints = other._attackPoints;
      _speedPoints = other._speedPoints;
      _sizeCm = other._sizeCm;
      _weightGrams = other._weightGrams;
      _attacks = new List<string>(other._attacks);
      _defencePoints = other._defencePoints;
      _healthPoints = other._healthPoints;
      _noise = other._noise;
    }
  }
}
