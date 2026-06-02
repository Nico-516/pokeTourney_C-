using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Controller.JsonGetters
{
  public static class GetRegions
  {
    public static List<string> GetRegionsFromJSON()
    {
      string[] pathsToTry = new[]
      {
        "RegionLibrary.json",
        "Controller/JsonGetters/RegionLibrary.json",
        "../RegionLibrary.json",
        "../Controller/JsonGetters/RegionLibrary.json",
        "../../Controller/JsonGetters/RegionLibrary.json",
        "../../../Controller/JsonGetters/RegionLibrary.json",
        "../../../../Controller/JsonGetters/RegionLibrary.json",
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
          "Could not find RegionLibrary.json in any of the expected locations."
        );
      }

      string jsonString = File.ReadAllText(jsonPath);

      List<string>? regions = JsonSerializer.Deserialize<List<string>>(jsonString);

      return regions ?? new List<string>();
    }
  }
}
