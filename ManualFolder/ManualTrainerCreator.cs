using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Controller;
using Controller.JsonGetters;

namespace ManualFolder
{
  public static class ManualTrainerCreator
  {
    private static Random rnd = new Random();

    public static List<Trainer> Create16Trainers()
    {
      List<Trainer> trainers = new List<Trainer>();
      
      Console.WriteLine("==================================================");
      Console.WriteLine("          MANUAL TRAINER CONFIGURATION            ");
      Console.WriteLine("==================================================");
      Console.WriteLine();
      
      int manualCount = InputValidator.ReadInteger("How many trainers do you want to create manually? (1-16): ", 1, 16);
      Console.WriteLine();

      for (int i = 1; i <= manualCount; i++)
      {
        Console.WriteLine($"--- Creating Trainer {i} of {manualCount} ---");
        Trainer trainer = CreateSingleTrainer(i);
        trainers.Add(trainer);
        Console.WriteLine($"Trainer '{trainer._name}' successfully created!\n");
      }

      if (manualCount < 16)
      {
        int remaining = 16 - manualCount;
        Console.WriteLine($"Auto-generating the remaining {remaining} trainers to complete the 16-trainer tourney...");
        
        List<Trainer> dummyTrainers = GetDummyTrainer.GetDummyTrainersFromJSON();
        List<Gym> gyms = GetGyms.GetGymsFromJSON();
        List<Pokemon> pokemons = GetPokemons.GetPokemonsFromJSON();

        int added = 0;
        while (added < remaining)
        {
          int rndIndex = rnd.Next(dummyTrainers.Count);
          Trainer dummy = dummyTrainers[rndIndex];

          
          if (trainers.Any(t => t._id == dummy._id || t._name == dummy._name))
          {
            continue;
          }

          
          dummy._gym = gyms[rnd.Next(gyms.Count)];
          
          List<Pokemon> team = new List<Pokemon>();
          while (team.Count < 6)
          {
            Pokemon p = pokemons[rnd.Next(pokemons.Count)];
            if (!team.Any(poke => poke._id == p._id))
            {
              team.Add(new Pokemon(p));
            }
          }
          dummy._pokemonTeam = team;

          trainers.Add(dummy);
          added++;
        }
        Console.WriteLine("Remaining trainers generated successfully!\n");
      }

      return trainers;
    }

    public static Trainer CreateSingleTrainer(int index)
    {
      string name = InputValidator.ReadNonEmptyString("Enter Trainer Name: ");
      int age = InputValidator.ReadInteger("Enter Trainer Age: ", 5, 120);

      
      List<string> regions = GetRegions.GetRegionsFromJSON();
      Console.WriteLine("\nAvailable Regions:");
      for (int i = 0; i < regions.Count; i++)
      {
        Console.WriteLine($"  [{i + 1}] {regions[i]}");
      }
      int regionIndex = InputValidator.ReadInteger($"Select Region (1-{regions.Count}): ", 1, regions.Count);
      string selectedRegion = regions[regionIndex - 1];

      string voiceLine = InputValidator.ReadNonEmptyString("Enter Trainer Voice Line: ");

      
      List<Gym> gyms = GetGyms.GetGymsFromJSON();
      Console.WriteLine("\nAvailable Gyms:");
      for (int i = 0; i < gyms.Count; i++)
      {
        Console.WriteLine($"  [{i + 1}] {gyms[i]._name} (Leader: {gyms[i]._leader}, City: {gyms[i]._city}, Region: {gyms[i]._region})");
      }
      int gymIndex = InputValidator.ReadInteger($"Select Gym (1-{gyms.Count}): ", 1, gyms.Count);
      Gym selectedGym = gyms[gymIndex - 1];

      
      List<Pokemon> allPokemons = GetPokemons.GetPokemonsFromJSON();
      List<Pokemon> team = new List<Pokemon>();
      Console.WriteLine("\nSelect your Pokémon team (up to 6 Pokémon). Enter Pokémon ID (1-100).");

      while (team.Count < 6)
      {
        int pokeId = InputValidator.ReadInteger($"Enter ID for Pokémon #{team.Count + 1}: ", 1, 100);
        Pokemon? selectedPoke = allPokemons.FirstOrDefault(p => p._id == pokeId);

        if (selectedPoke == null)
        {
          Console.WriteLine("Error: Pokémon with that ID not found in library. Try again.");
          continue;
        }

        if (team.Any(p => p._id == pokeId))
        {
          Console.WriteLine($"Error: {selectedPoke._name} is already in the team. Select a different Pokémon.");
          continue;
        }

        team.Add(new Pokemon(selectedPoke));
        Console.WriteLine($"Added {selectedPoke._name} to the team!");

        if (team.Count < 6)
        {
          bool keepAdding = InputValidator.ReadYesNo("Do you want to add another Pokémon?");
          if (!keepAdding)
          {
            break;
          }
        }
      }

      Trainer newTrainer = new Trainer(name, age, selectedRegion, voiceLine);
      newTrainer._id = 1000 + index;
      newTrainer._gym = selectedGym;
      newTrainer._pokemonTeam = team;

      return newTrainer;
    }
  }
}
