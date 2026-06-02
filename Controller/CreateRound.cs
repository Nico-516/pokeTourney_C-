using Model;
using Model.Interfaces;
using System.Collections.Generic;
using Controller.JsonGetters;

namespace Controller{
  
  public static class CreateRound{
    
    public static List<Round> CreateRounds(Tourney tourney){

      List<Round> rounds = new List<Round>();
      
      Round roundOf16 = new Round("Octavos de Final");
      roundOf16._trainers = tourney._trainers;
      roundOf16._matches = CreateMatches.CreatetourneyMatches(roundOf16);
      rounds.Add(roundOf16);
      
      Round roundOf8 = new Round("Cuartos de Final");
      rounds.Add(roundOf8);
      
      Round roundOf4 = new Round("Semifinales");
      rounds.Add(roundOf4);
      
      Round roundOf2 = new Round("Final");
      rounds.Add(roundOf2);
      
      return rounds;
    }
  }
}