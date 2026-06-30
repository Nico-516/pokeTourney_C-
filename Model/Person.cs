using System.Text.Json.Serialization;
using Model.Interfaces;

namespace Model
{
  public abstract class Person : IEntity
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }

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
