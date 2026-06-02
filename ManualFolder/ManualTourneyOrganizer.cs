using System;
using System.Collections.Generic;
using Model;
using Controller;

namespace ManualFolder
{
  public static class ManualTourneyOrganizer
  {
    public static void CreateAndRunManualTourney()
    {
      Console.WriteLine("==================================================");
      Console.WriteLine("          CREATE MANUAL TOURNAMENT                ");
      Console.WriteLine("==================================================");
      Console.WriteLine();

      string tourneyName = InputValidator.ReadNonEmptyString("Enter Tournament Name: ");
      Console.WriteLine();

      
      List<Trainer> trainers = ManualTrainerCreator.Create16Trainers();

      
      Tourney tourney = new Tourney(tourneyName);
      tourney._trainers = trainers;
      tourney._rounds = CreateRound.CreateRounds(tourney);

      Console.WriteLine("==================================================");
      Console.WriteLine($"Tourney '{tourney._name}' is ready with 16 trainers!");
      Console.WriteLine("Press any key to start the automated tournament matches...");
      Console.ReadKey();
      Console.WriteLine("\n");

      
      ManageTourney.TourneyManager(tourney);
    }
  }
}
