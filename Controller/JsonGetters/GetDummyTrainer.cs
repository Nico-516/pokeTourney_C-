using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace Controller.JsonGetters
{
  public static class GetDummyTrainer
  {
    public static List<Trainer> GetDummyTrainersFromJSON()
    {
      string[] pathsToTry = new[]
      {
        "DummyTrainerLibrary.json",
        "Controller/JsonGetters/DummyTrainerLibrary.json",
        "../DummyTrainerLibrary.json",
        "../Controller/JsonGetters/DummyTrainerLibrary.json",
        "../../Controller/JsonGetters/DummyTrainerLibrary.json",
        "../../../Controller/JsonGetters/DummyTrainerLibrary.json",
        "../../../../Controller/JsonGetters/DummyTrainerLibrary.json",
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
          "Could not find DummyTrainerLibrary.json in any of the expected locations."
        );
      }

      string jsonString = File.ReadAllText(jsonPath);

      List<Trainer>? dummyTrainers = JsonSerializer.Deserialize<List<Trainer>>(jsonString);

      return dummyTrainers ?? new List<Trainer>();
    }
  }
}
