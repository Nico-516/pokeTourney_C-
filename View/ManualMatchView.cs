using Model;
using System;

namespace View
{
	public static class ManualMatchView
	{
		public static void RenderMatchOptions(Match match)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"    1.  {match._trainer1._name,-15}  (Gimnasio: {match._trainer1._gym?._name ?? "Sin Gimnasio"})");
			Console.WriteLine($"    2.  {match._trainer2._name,-15}  (Gimnasio: {match._trainer2._gym?._name ?? "Sin Gimnasio"})");
			Console.ResetColor();
			Console.WriteLine();
		}
	}
}