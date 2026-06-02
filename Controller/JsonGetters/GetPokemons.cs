using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace Controller.JsonGetters
{
  public static class GetPokemons
  {
    public static List<Pokemon> GetPokemonsFromJSON()
    {
      string[] pathsToTry = new[]
      {
        "PokemonLibrary.json",
        "Controller/JsonGetters/PokemonLibrary.json",
        "../PokemonLibrary.json",
        "../Controller/JsonGetters/PokemonLibrary.json",
        "../../Controller/JsonGetters/PokemonLibrary.json",
        "../../../Controller/JsonGetters/PokemonLibrary.json",
        "../../../../Controller/JsonGetters/PokemonLibrary.json",
      };

      string jsonPath = "";
      foreach (var path in pathsToTry)
      {
        if (File.Exists(path))
        {
          jsonPath = path;
          break;
        }
      }

      if (string.IsNullOrEmpty(jsonPath))
      {
        throw new FileNotFoundException(
          "Could not find PokemonLibrary.json in any of the expected locations."
        );
      }

      string jsonString = File.ReadAllText(jsonPath);

      List<Pokemon>? pokemons = JsonSerializer.Deserialize<List<Pokemon>>(jsonString);

      return pokemons ?? new List<Pokemon>();
    }
  }
}
