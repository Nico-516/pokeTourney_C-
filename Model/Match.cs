namespace Model
{
  public class Match
  {
    public string _name { get; set; }
    public Trainer _trainer1 { get; set; }
    public Trainer _trainer2 { get; set; }
    public Trainer? _winner { get; set; }

    public Match(string name, Trainer trainer1, Trainer trainer2)
    {
      this._name = name;
      this._trainer1 = trainer1;
      this._trainer2 = trainer2;
      this._winner = null;
    }
    public Match() 
    { 
        _name = string.Empty;
        _trainer1 = new Trainer();
        _trainer2 = new Trainer();
        _winner = null;
    }

  }
}