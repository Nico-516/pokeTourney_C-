using System; 
using System.Text.Json.Serialization;
using Model.Interfaces;

namespace Model
{
  public class Tourney : IEntity
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }
    public string _name { get; set; }
    public List<Trainer> _trainers { get; set; }
    public List<Round> _rounds { get; set; }
    public DateTime _creationDate { get; set; }

    public Tourney(string names)
    {
      this._name = names;
      this._trainers = new List<Trainer>();
      this._rounds = new List<Round>();
      this._creationDate = DateTime.Now;
    }

    public Tourney() 
    { 
        _name = string.Empty;
        _trainers = new List<Trainer>(); 
        _rounds = new List<Round>(); 
    }
  }
}