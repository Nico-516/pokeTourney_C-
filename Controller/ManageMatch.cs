using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Controller.JsonGetters;

namespace Controller{

  public static class ManageMatch{
    
    public static void MatchManager(Match match){ //Administrador del combate y simulacion del mismo
      Console.WriteLine($"--- Iniciando Combate: {match._trainer1._name} VS {match._trainer2._name} ---");
      Trainer winner = SimulateCombat(match._trainer1, match._trainer2);
      match._winner = winner;
      Console.WriteLine($"Ganador: {winner._name}!");
      Console.WriteLine();
    }

    public static Trainer SimulateCombat(Trainer trainer1, Trainer trainer2){
      List<Pokemon> team1 = trainer1._pokemonTeam.Select(p => new Pokemon(p)).ToList();
      List<Pokemon> team2 = trainer2._pokemonTeam.Select(p => new Pokemon(p)).ToList();

      int i = 0;
      int j = 0;

      while (i < team1.Count && j < team2.Count){ //Ciclo while para continuar el combate mientras ambos entrenadores tengan pokemon
        Pokemon p1 = team1[i];
        Pokemon p2 = team2[j];

        while (p1._healthPoints > 0 && p2._healthPoints > 0){ //Ciclo while para continuar el combate mientras ambos pokemon tengan vida
          int damageTo2 = Math.Max(1, p1._attackPoints - p2._defencePoints);
          p2._healthPoints -= damageTo2;

          if (p2._healthPoints <= 0){
            break;
          }

          int damageTo1 = Math.Max(1, p2._attackPoints - p1._defencePoints);
          p1._healthPoints -= damageTo1;
        }

        if (p1._healthPoints <= 0){
          Console.WriteLine($"  [K.O.]] {trainer1._name}'s {p1._name} ha sido Derrotado!");
          i++;
        }
        if (p2._healthPoints <= 0){
          Console.WriteLine($"  [K.O.]] {trainer2._name}'s {p2._name} ha sido Derrotado!");
          j++;
        }
      }

      if (i < team1.Count){ //Si quedan pokemon del equipo 1, gana el entrenador 1
        return trainer1;
      }
      else if (j < team2.Count){ //Si quedan pokemon del equipo 2, gana el entrenador 2
        return trainer2;
      }
      else{
        int totalAttack1 = SumAttackPower(trainer1._pokemonTeam);
        int totalAttack2 = SumAttackPower(trainer2._pokemonTeam);
        return totalAttack1 >= totalAttack2 ? trainer1 : trainer2; //Si empatan en pokemon, gana el que tenga mayor ataque acumulado
      }
    }

    public static int SumAttackPower(List<Pokemon> pokemons){
      int totalAttack = 0;
      foreach (Pokemon pokemon in pokemons) {
        totalAttack += pokemon._attackPoints;
      }
      return totalAttack;
    }
  }
}