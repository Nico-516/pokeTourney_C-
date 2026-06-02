using Model;
using System;

namespace View
{
    public static class MatchView
    {
        public static void RenderMatchStart(Match match)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  ┌─ {match._trainer1._name}  VS  {match._trainer2._name} ─┐");
            Console.ResetColor();
        }

        public static void RenderFaint(string trainerName, string pokemonName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"    [K.O.]  {trainerName}'s {pokemonName} no puede más!");
            Console.ResetColor();
        }

        public static void RenderMatchResult(Match match)
        {
            if (match._winner == null) return;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  └─ ¡Ganador: {match._winner._name}!");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
