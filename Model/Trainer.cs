using System.Collections.Generic;
using System.Text.Json.Serialization;
using Model.Interfaces;

namespace Model
{
  public class Trainer : Person, IMakeNoise
  {
    [JsonPropertyName("region")]
    public string _region { get; set; } = string.Empty;

    [JsonPropertyName("gym")]
    public Gym? _gym { get; set; }

    [JsonPropertyName("team")]
    public List<Pokemon> _pokemonTeam { get; set; } = new List<Pokemon>();

    [JsonPropertyName("voiceLine")]
    public string _voiceLine { get; set; } = string.Empty;

    public Trainer() : base()
    {
    }

    public Trainer(string name, int age, string region, string voiceLine) : base(name, age)
    {
      this._region = region;
      this._pokemonTeam = new List<Pokemon>();
      this._voiceLine = voiceLine;
    }

    public string MakeNoise()
    {
      return _voiceLine;
    }
  }
}

