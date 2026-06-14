namespace Model
{
  public class Round
  {
    public string _name { get; set; }
    public List<Trainer> _trainers { get; set; }
    public List<Match> _matches { get; set; }

    public Round(string name)
    {
      this._name = name;
      this._trainers = new List<Trainer>();
      this._matches = new List<Match>();
    }
    public Round() 
    { 
        _name = string.Empty;
        _trainers = new List<Trainer>(); 
        _matches = new List<Match>(); 
    }
  }
}