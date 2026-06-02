using System;
using Model;
using View;

namespace Controller.ManualTourney
{
  public static class ManualMatchManager
  {
    public static void ManageMatchManual(Match match) {
        MatchView.RenderMatchStart(match);         
        ManualMatchView.RenderMatchOptions(match);  

        int choice = InputValidator.ReadInteger("Selecciona el ganador (1 o 2): ", 1, 2);
        Trainer winner = choice == 1 ? match._trainer1 : match._trainer2;
        match._winner = winner;

        MatchView.RenderMatchResult(match);        
        
       }
    }
}
