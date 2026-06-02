using System;
using Model;

namespace Controller.ManualTourney
{
  public static class ManualMatchManager
  {
    public static void ManageMatchManual(Match match)
    {
      Console.WriteLine("==================================================");
      Console.WriteLine($"COMBATE: {match._trainer1._name} VS {match._trainer2._name}");
      Console.WriteLine("==================================================");
      Console.WriteLine($"1. {match._trainer1._name} (Gimnasio: {match._trainer1._gym?._name ?? "Sin Gimnasio"})");
      Console.WriteLine($"2. {match._trainer2._name} (Gimnasio: {match._trainer2._gym?._name ?? "Sin Gimnasio"})");
      Console.WriteLine();

      int choice = InputValidator.ReadInteger("Selecciona el ganador (1 o 2): ", 1, 2);

      Trainer winner = choice == 1 ? match._trainer1 : match._trainer2;
      match._winner = winner;

      Console.WriteLine($"Resultado: {winner._name} ganó el combate!");
      Console.WriteLine();
    }
  }
}
