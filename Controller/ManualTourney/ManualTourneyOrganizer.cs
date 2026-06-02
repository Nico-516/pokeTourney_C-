using System;
using System.Collections.Generic;
using Model;
using Controller;
using View;

namespace Controller
{
  public static class ManualTourneyOrganizer
  {
    public static void CreateAndRunManualTourney()
    {

      TourneyView.RenderCreationHeader();

      string tourneyName = InputValidator.ReadNonEmptyString("Ingrese el nombre del torneo: ");
      Console.WriteLine();

      
      List<Trainer> trainers = ManualTrainerCreator.Create16Trainers();

      
      Tourney tourney = new Tourney(tourneyName);
      tourney._trainers = trainers;
      tourney._rounds = CreateRound.CreateRounds(tourney);

      TourneyView.RenderTourneyReady(tourney._name);
      Console.ReadLine();
      Console.WriteLine("\n");

      
      ManageTourney.TourneyManager(tourney, isManual: true);
    }
  }
}
