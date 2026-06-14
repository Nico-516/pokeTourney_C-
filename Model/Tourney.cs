using System; 

namespace Model
{
  public class Tourney
  {
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
  }
}