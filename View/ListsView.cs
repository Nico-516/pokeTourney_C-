using Model;
using System;
using System.Collections.Generic;

namespace View
{
	public static class ListsView
	{
		public static void RenderPokemons(List<Pokemon> pokemons)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.WriteLine($"  {"ID",-5} {"Nombre",-15} {"Vida",-5} {"Ataque",-7} {"Defensa",-8} {"Tipo",-20}");
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			foreach (var p in pokemons)
			{
				Console.WriteLine($"  {p.Id,-5} {p._name,-15} {p._healthPoints,-5} {p._attackPoints,-7} {p._defencePoints,-8} {string.Join(", ", p._type),-20}");
			}
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			Console.WriteLine();
		}

		public static void RenderGyms(List<Gym> gyms)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.WriteLine($"  {"Nombre",-25} {"Líder",-15} {"Ciudad",-15} {"Región",-15}");
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			foreach (var g in gyms)
			{
				Console.WriteLine($"  {g._name,-25} {g._leader,-15} {g._city,-15} {g._region,-15}");
			}
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			Console.WriteLine();
		}

		public static void RenderTrainers(List<Trainer> trainers)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────────────────────");
			Console.WriteLine($"  {"ID",-5} {"Nombre",-15} {"Edad",-5} {"Región",-12} {"Frase de voz",-50}");
			Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			foreach (var t in trainers)
			{
				Console.WriteLine($"  {t.Id,-5} {t._name,-15} {t._age,-5} {t._region,-12} {t._voiceLine,-50}");
			}
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			Console.WriteLine();
		}

		public static void RenderSavedTourneys(List<Tourney> tourneys)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.WriteLine($"  {"Nombre del torneo",-30} {"Fecha de creación",-25} {"Ganador",-20}");
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			foreach (var t in tourneys)
			{
				string winner = t._rounds.Count > 0 ? t._rounds[^1]._matches[0]._winner?._name ?? "N/A" : "N/A";
				Console.WriteLine($"  {t._name,-30} {t._creationDate.ToString("g"),-25} {winner,-20}");
			}
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────");
			Console.ResetColor();
			Console.WriteLine();
		}
	}
}