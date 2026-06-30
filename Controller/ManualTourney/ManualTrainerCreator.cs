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

    public static List<Trainer> Create16Trainers(IRepository<Trainer> repoTrainers, IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<Region> repoRegions){
      List<Trainer> trainers = new List<Trainer>();

      Console.Clear();
      TourneyView.RenderTrainerSetupHeader();


      int manualCount = InputValidator.ReadInteger("¿Cuántos entrenadores deseas crear manualmente? (1-16): ", 1, 16);
      Console.WriteLine();

      for (int i = 1; i <= manualCount; i++)
      {
        Console.Clear();
        TourneyView.RenderTrainerCreating(i, manualCount);
        Trainer trainer = CreateSingleTrainer(i, repoTrainers, repoPokemons, repoGyms, repoRegions);
        trainers.Add(trainer);
        TourneyView.RenderTrainerCreated(trainer._name);
      }

      if (manualCount < 16)
      {
        int remaining = 16 - manualCount;
        TourneyView.RenderDummiesGenerating(remaining);

        List<Trainer> dummyTrainers = repoTrainers.GetAll();
        List<Gym> gyms = repoGyms.GetAll();
        List<Pokemon> pokemons = repoPokemons.GetAll();

        int added = 0;
        while (added < remaining)
        {
          int rndIndex = rnd.Next(dummyTrainers.Count);
          Trainer dummy = dummyTrainers[rndIndex];

          
          if (trainers.Any(t => t.Id == dummy.Id || t._name == dummy._name))
          {
            continue;
          }

          
          dummy._gym = gyms[rnd.Next(gyms.Count)];
          
          List<Pokemon> team = new List<Pokemon>();
          while (team.Count < 6)
          {
            Pokemon p = pokemons[rnd.Next(pokemons.Count)];
            if (!team.Any(poke => poke.Id == p.Id))
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

    public static Trainer CreateSingleTrainer(int index, IRepository<Trainer> repoTrainers, IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<Region> repoRegions)
    {
      string name = InputValidator.ReadNonEmptyString("Ingresa el nombre del entrenador: ");
      int age = InputValidator.ReadInteger("Ingresa la edad del entrenador: ", 5, 120);

      
      List<Region> regions = repoRegions.GetAll();
      Console.WriteLine("\nRegiones disponibles:");
      for (int i = 0; i < regions.Count; i++)
      {
        Console.WriteLine($"  [{i + 1}] {regions[i].Name}");
      }
      int regionIndex = InputValidator.ReadInteger($"Selecciona una región (1-{regions.Count}): ", 1, regions.Count);
      string selectedRegion = regions[regionIndex - 1].Name;

      string voiceLine = InputValidator.ReadNonEmptyString("Ingresa la frase característica del entrenador: ");

      
      List<Gym> gyms = repoGyms.GetAll();
      Console.WriteLine("\nGimnasios disponibles:");
      for (int i = 0; i < gyms.Count; i++)
      {
        Console.WriteLine($"  [{i + 1}] {gyms[i]._name} (Líder: {gyms[i]._leader}, Ciudad: {gyms[i]._city}, Región: {gyms[i]._region})");
      }
      int gymIndex = InputValidator.ReadInteger($"Selecciona un gimnasio (1-{gyms.Count}): ", 1, gyms.Count);
      Gym selectedGym = gyms[gymIndex - 1];

      
      List<Pokemon> allPokemons = repoPokemons.GetAll();
      ListsView.RenderPokemons(allPokemons);
      List<Pokemon> team = new List<Pokemon>();
      Console.WriteLine("\nSelecciona los Pokémon para tu equipo (hasta 6 Pokémon). Ingresa el ID del Pokémon (1-100).");

      while (team.Count < 6)
      {
        int pokeId = InputValidator.ReadInteger($"Ingresa el ID del Pokémon #{team.Count + 1}: ", 1, 100);
        Pokemon? selectedPoke = allPokemons.FirstOrDefault(p => p.Id == pokeId);

        if (selectedPoke == null)
        {
          Console.WriteLine("Error: No se encontró ningún Pokémon con ese ID en la biblioteca. Inténtalo de nuevo.");
          continue;
        }

        if (team.Any(p => p.Id == pokeId))
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
      newTrainer.Id = 1000 + index;
      newTrainer._gym = selectedGym;
      newTrainer._pokemonTeam = team;

      return newTrainer;
    }
  }
}
