using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Controller;
using View;
using Repository;

namespace Controller
{
  public static class ManualTrainerCreator
  {
    private static Random rnd = new Random();

    public static List<Trainer> Create16Trainers(IRepository<Trainer> repoTrainers, IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<string> repoRegions){
      List<Trainer> trainers = new List<Trainer>();

      TourneyView.RenderTrainerSetupHeader();


      int manualCount = InputValidator.ReadInteger("¿Cuántos entrenadores deseas crear manualmente? (1-16): ", 1, 16);
      Console.WriteLine();

      for (int i = 1; i <= manualCount; i++)
      {
        TourneyView.RenderTrainerCreating(i, manualCount);
        Trainer trainer = CreateSingleTrainer(i, repoTrainers, repoPokemons, repoGyms, repoRegions);
        trainers.Add(trainer);
        TourneyView.RenderTrainerCreated(trainer._name);
      }

      if (manualCount < 16)
      {
        int remaining = 16 - manualCount;
        TourneyView.RenderDummiesGenerating(remaining);

        List<Trainer> dummyTrainers = repoTrainers.LeerTodos();
        List<Gym> gyms = repoGyms.LeerTodos();
        List<Pokemon> pokemons = repoPokemons.LeerTodos();

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
        TourneyView.RenderDummiesGenerated();
      }

      return trainers;
    }

    public static Trainer CreateSingleTrainer(int index, IRepository<Trainer> repoTrainers, IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<string> repoRegions)
    {
      string name = InputValidator.ReadNonEmptyString("Ingresa el nombre del entrenador: ");
      int age = InputValidator.ReadInteger("Ingresa la edad del entrenador: ", 5, 120);

      
      List<string> regions = repoRegions.LeerTodos();
      Console.WriteLine("\nRegiones disponibles:");
      for (int i = 0; i < regions.Count; i++)
      {
        Console.WriteLine($"  [{i + 1}] {regions[i]}");
      }
      int regionIndex = InputValidator.ReadInteger($"Selecciona una región (1-{regions.Count}): ", 1, regions.Count);
      string selectedRegion = regions[regionIndex - 1];

      string voiceLine = InputValidator.ReadNonEmptyString("Ingresa la frase característica del entrenador: ");

      
      List<Gym> gyms = repoGyms.LeerTodos();
      Console.WriteLine("\nGimnasios disponibles:");
      for (int i = 0; i < gyms.Count; i++)
      {
        Console.WriteLine($"  [{i + 1}] {gyms[i]._name} (Líder: {gyms[i]._leader}, Ciudad: {gyms[i]._city}, Región: {gyms[i]._region})");
      }
      int gymIndex = InputValidator.ReadInteger($"Selecciona un gimnasio (1-{gyms.Count}): ", 1, gyms.Count);
      Gym selectedGym = gyms[gymIndex - 1];

      
      List<Pokemon> allPokemons = repoPokemons.LeerTodos();
      List<Pokemon> team = new List<Pokemon>();
      Console.WriteLine("\nSelecciona los Pokémon para tu equipo (hasta 6 Pokémon). Ingresa el ID del Pokémon (1-100).");

      while (team.Count < 6)
      {
        int pokeId = InputValidator.ReadInteger($"Ingresa el ID del Pokémon #{team.Count + 1}: ", 1, 100);
        Pokemon? selectedPoke = allPokemons.FirstOrDefault(p => p._id == pokeId);

        if (selectedPoke == null)
        {
          Console.WriteLine("Error: No se encontró ningún Pokémon con ese ID en la biblioteca. Inténtalo de nuevo.");
          continue;
        }

        if (team.Any(p => p._id == pokeId))
        {
          Console.WriteLine($"Error: {selectedPoke._name} ya está en el equipo. Selecciona otro Pokémon.");
          continue;
        }

        team.Add(new Pokemon(selectedPoke));
        Console.WriteLine($"Se agrego a {selectedPoke._name} al equipo!");

        if (team.Count < 6)
        {
          bool keepAdding = InputValidator.ReadYesNo("¿Quieres agregar otro Pokémon?");
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
