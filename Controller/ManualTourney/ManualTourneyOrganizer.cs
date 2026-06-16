using System;
using System.Collections.Generic;
using Model;
using Controller;
using View;
using Repository;

namespace Controller
{
  public static class ManualTourneyOrganizer
  {
    public static Tourney CreateAndRunManualTourney(IRepository<Trainer> repoTrainers, IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<string> repoRegions)
    {

      TourneyView.RenderCreationHeader();

      string tourneyName = InputValidator.ReadNonEmptyString("Ingrese el nombre del torneo: ");
      Console.WriteLine();

      
      List<Trainer> trainers = ManualTrainerCreator.Create16Trainers(repoTrainers, repoPokemons, repoGyms, repoRegions);

      
      Tourney tourney = new Tourney(tourneyName);
      tourney._trainers = trainers;
      tourney._rounds = CreateRound.CreateRounds(tourney);

      TourneyView.RenderTourneyReady(tourney._name);
      Console.ReadLine();
      Console.WriteLine("\n");

      
      ManageTourney.TourneyManager(tourney, isManual: true);
      return tourney;
    }
  }
}
