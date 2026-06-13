using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using View;

namespace Controller{
  
  public static class ManageTourney{
    
    public static void TourneyManager(Tourney tourney, bool isManual = false){
      
      for (int r = 0; r < tourney._rounds.Count; r++){
        Round round = tourney._rounds[r];
        
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

        RoundView.RenderRoundHeader(round);

        foreach (Match match in round._matches){
          if (isManual)
          {
            Controller.ManualTourney.ManualMatchManager.ManageMatchManual(match);
          }
          else
          {
            ManageMatch.MatchManager(match);
          }
        }

        RoundView.RenderRoundSummary(round);

        if (r == tourney._rounds.Count - 1 && round._matches.Count > 0) {
          Trainer? champion = round._matches[0]._winner;
          if (champion != null) {
            RoundView.RenderChampion(tourney);
          }
        }
      }
    }
  }
}