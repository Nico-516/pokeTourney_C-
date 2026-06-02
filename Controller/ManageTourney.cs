using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using Controller.JsonGetters;

namespace Controller{
  
  public static class ManageTourney{
    
    public static void TourneyManager(Tourney tourney){
      
      for (int r = 0; r < tourney._rounds.Count; r++){
        Round round = tourney._rounds[r];
        
        // If this is not the first round, populate trainers and matches from previous round's winners
        if (r > 0) {
          List<Trainer> winners = new List<Trainer>();
          foreach (Match match in tourney._rounds[r - 1]._matches) {
            if (match._winner != null) {
              winners.Add(match._winner);
            }
          }
          round._trainers = winners;
          round._matches = CreateMatches.CreatetourneyMatches(round);
        }

        Console.WriteLine("==================================================");
        Console.WriteLine($"ROUND: {round._name}");
        Console.WriteLine("==================================================");
        Console.WriteLine();

        foreach (Match match in round._matches){
          ManageMatch.MatchManager(match);
        }

        // Check if we just completed the final round
        if (r == tourney._rounds.Count - 1 && round._matches.Count > 0) {
          Trainer? champion = round._matches[0]._winner;
          if (champion != null) {
            Console.WriteLine("🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆");
            Console.WriteLine($"TOURNAMENT CHAMPION: {champion._name} from {champion._region} region!");
            Console.WriteLine("🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆🏆");
            Console.WriteLine();
          }
        }
      }
    }
  }
}