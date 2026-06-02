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
      
      Console.WriteLine($"El torneo '{pokemonTourney._name}' fue creado con {pokemonTourney._trainers.Count} entrenadores.");

      Test16Trainers(dummyTrainers);

      return pokemonTourney;
    }

    public static void Test16Trainers(List<Trainer> dummyTrainerList){
      if (dummyTrainerList == null){
        Console.WriteLine("No se generaron entrenadores.");
        return;
      }
      foreach (Trainer trainer in dummyTrainerList) {
        Console.WriteLine($"Entrenador: {trainer._name}, Id: {trainer._id}, Gimnasio: {trainer._gym?._name ?? "Sin Gimnasio"}, Pokemon: {string.Join(", ", trainer._pokemonTeam.Select(pokemon => pokemon._name))}");
      }
    }
  }
}