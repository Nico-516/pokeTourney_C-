using System;
using System.Collections.Generic;
using Model;
using Controller;

namespace Controller
{
  public static class ManualTourneyOrganizer
  {
    public static void CreateAndRunManualTourney()
    {
      Console.WriteLine("==================================================");
      Console.WriteLine("            CREACIÓN DE TORNEO MANUAL             ");
      Console.WriteLine("==================================================");
      Console.WriteLine();

      string tourneyName = InputValidator.ReadNonEmptyString("Ingrese el nombre del torneo: ");
      Console.WriteLine();

      
      List<Trainer> trainers = ManualTrainerCreator.Create16Trainers();

      
      Tourney tourney = new Tourney(tourneyName);
      tourney._trainers = trainers;
      tourney._rounds = CreateRound.CreateRounds(tourney);

      Console.WriteLine("==================================================");
      Console.WriteLine($"El torneo '{tourney._name}' está listo con 16 entrenadores!");
      Console.WriteLine("Presiona Enter para comenzar los combates del torneo manual...");
      Console.ReadLine();
      Console.WriteLine("\n");

      
      ManageTourney.TourneyManager(tourney, isManual: true);
    }
  }
}
