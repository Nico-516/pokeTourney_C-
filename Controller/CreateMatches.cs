using Model;
using Model.Interfaces;
using System.Collections.Generic;
using Controller.JsonGetters;

namespace Controller{
  
  public static class CreateMatches{
    
    public static List<Match> CreatetourneyMatches(Round round){
      
      List<Match> tourneyMatches = new List<Match>();

      List<Trainer> trainers = round._trainers;
      int matchNumber = 1;

      for (int i = 0; i < trainers.Count; i += 2){
        Match match = new Match($"Combate {matchNumber}, {trainers[i]._name} VS {trainers[i + 1]._name}", trainers[i], trainers[i + 1]);
        tourneyMatches.Add(match);
        matchNumber++;
      }
      
      return tourneyMatches;
    }
  }
}