using Model;
using System;

namespace View
{
    public static class RoundView
    {
        public static void RenderRoundHeader(Round round)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"  ════════════════════════════════════════════");
            Console.WriteLine($"   {round._name.ToUpper()}");
            Console.WriteLine($"  ════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderRoundSummary(Round round)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  ── Resultados de {round._name} ─");
            foreach (var match in round._matches)
            {
                string winnerName = match._winner?._name ?? "Sin resultado";
                Console.WriteLine($"     {match._trainer1._name,12}  vs  {match._trainer2._name,-12}  →  {winnerName}");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderChampion(Tourney tourney)
        {
            Round finalRound = tourney._rounds[tourney._rounds.Count - 1];
            if (finalRound._matches.Count == 0) return;

            Trainer? champion = finalRound._matches[0]._winner;
            if (champion == null) return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"   CAMPEÓN: {champion._name.ToUpper()}");
            Console.WriteLine($"   Región:  {champion._region}");
            Console.ResetColor();

            if (!string.IsNullOrWhiteSpace(champion._voiceLine))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  \"{champion._voiceLine}\"");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
