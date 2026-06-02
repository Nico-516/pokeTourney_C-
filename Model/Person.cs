using System.Text.Json.Serialization;

namespace Model
{
  public abstract class Person
  {
    [JsonPropertyName("name")]
    public string _name { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int _age { get; set; }

    protected Person()
    {
    }

    public Person(string name, int age)
    {
      this._name = name;
      this._age = age;
    }
  }
}