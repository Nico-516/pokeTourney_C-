using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace Controller.JsonGetters
{
  public static class GetGyms
  {
    public static List<Gym> GetGymsFromJSON()
    {
      string[] pathsToTry = new[]
      {
        "GymLibrary.json",
        "Controller/JsonGetters/GymLibrary.json",
        "../GymLibrary.json",
        "../Controller/JsonGetters/GymLibrary.json",
        "../../Controller/JsonGetters/GymLibrary.json",
        "../../../Controller/JsonGetters/GymLibrary.json",
        "../../../../Controller/JsonGetters/GymLibrary.json",
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
          "Could not find GymLibrary.json in any of the expected locations."
        );
      }

      string jsonString = File.ReadAllText(jsonPath);

      List<Gym>? gyms = JsonSerializer.Deserialize<List<Gym>>(jsonString);

      return gyms ?? new List<Gym>();
    }
  }
}
