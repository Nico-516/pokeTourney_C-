using System;

namespace View
{
    public static class MenuView
    {
        public static void RenderWelcome()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("  ════════════════════════════════════════════");
            Console.WriteLine("       Bienvenido a PokeTourney Simulation    ");
            Console.WriteLine("  ════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Seleccionar una opción:");
            Console.ResetColor();
            Console.WriteLine("    1.  Torneo simulado         (Auto-run)");
            Console.WriteLine("    2.  Torneo manual           (Elegir ganadores)");
            Console.WriteLine("    3.  Ver listas              (Pokémon, Gimnasios, Entrenadores)");
            Console.WriteLine("    4.  Salir");
            Console.WriteLine();
        }

        public static void RenderListsMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ── Ver listas ─");
            Console.ResetColor();
            Console.WriteLine("    1.  Pokémon   (IDs 1-100 & Stats)");
            Console.WriteLine("    2.  Gimnasios");
            Console.WriteLine("    3.  Entrenadores");
            Console.WriteLine("    4.  Volver al menú principal");
            Console.WriteLine();
        }

        public static void RenderGoodbye()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("  ¡Hasta la próxima, entrenador!");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}