using Model;
using Model.Interfaces;
using System.Collections.Generic;
using Controller.JsonGetters;

namespace Controller
{
  public static class CreateTrainer
  {
    private static Random rnd = new Random();

    public static List<Trainer> Create16DummyTrainers()
    {
      List<Trainer> selectedTrainers = new List<Trainer>();
      List<Trainer> dummyTrainers = GetDummyTrainer.GetDummyTrainersFromJSON();

      do{
        int rndTrainerIndex = rnd.Next(dummyTrainers.Count);
        Trainer newTrainer = dummyTrainers[rndTrainerIndex];

        if (selectedTrainers.Contains(newTrainer)){
          continue;
        }

        newTrainer._pokemonTeam = GeneratePokemonTeam();
        newTrainer._gym = AssignGym();

        selectedTrainers.Add(newTrainer);
        
      } while (selectedTrainers.Count < 16);
      
      return selectedTrainers;
    }

    public static List<Pokemon> GeneratePokemonTeam(){
      List<Pokemon> pokemonTeam = new List<Pokemon>();
      List<Pokemon> allPokemon = GetPokemons.GetPokemonsFromJSON();

      do {
        int rndPokemonIndex = rnd.Next(allPokemon.Count);
        Pokemon newPokemon = allPokemon[rndPokemonIndex];

        if (pokemonTeam.Contains(newPokemon)){
          continue;
        }

        pokemonTeam.Add(newPokemon);
        
      } while (pokemonTeam.Count < 6);
      
      return pokemonTeam;
    }

    public static Gym AssignGym(){
      List<Gym> allGyms = GetGyms.GetGymsFromJSON();
      int rndGymIndex = rnd.Next(allGyms.Count);
      Gym newGym = allGyms[rndGymIndex];
      return newGym;
    }
  }
}