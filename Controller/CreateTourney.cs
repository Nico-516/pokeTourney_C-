using Model;
using Model.Interfaces;
using System.Collections.Generic;
using Controller.JsonGetters;

namespace Controller{
  
  public static class CreateTourney{

    public static Tourney CreateNewTourneyWith16Trainers(string name){
      Tourney pokemonTourney = new Tourney(name);
      List<Trainer> dummyTrainers = CreateTrainer.Create16DummyTrainers();
      pokemonTourney._trainers = dummyTrainers;
      pokemonTourney._rounds = CreateRound.CreateRounds(pokemonTourney);
      
      Console.WriteLine($"Tourney '{pokemonTourney._name}' created with {pokemonTourney._trainers.Count} trainers.");

      Test16Trainers(dummyTrainers);

      return pokemonTourney;
    }

    public static void Test16Trainers(List<Trainer> dummyTrainerList){
      if (dummyTrainerList == null){
        Console.WriteLine("No trainers generated.");
        return;
      }
      foreach (Trainer trainer in dummyTrainerList) {
        Console.WriteLine($"Trainer: {trainer._name}, Id: {trainer._id}, Gym: {trainer._gym?._name ?? "No Gym"}, Pokemon: {string.Join(", ", trainer._pokemonTeam.Select(pokemon => pokemon._name))}");
      }
    }
  }
}