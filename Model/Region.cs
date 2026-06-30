using Model.Interfaces;
using System.Text.Json.Serialization;

namespace Model
{
    public class Region : IEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        public Region() { }
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
