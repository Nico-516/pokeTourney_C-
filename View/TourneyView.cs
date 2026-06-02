using System;

namespace View
{
    public static class TourneyView
    {
        public static void RenderCreationHeader()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("  ════════════════════════════════════════════");
            Console.WriteLine("          CREACIÓN DE TORNEO MANUAL           ");
            Console.WriteLine("  ════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderTrainerSetupHeader()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ════════════════════════════════════════════");
            Console.WriteLine("      CONFIGURACIÓN MANUAL DE ENTRENADORES    ");
            Console.WriteLine("  ════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderTrainerCreating(int current, int total)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  ── Entrenador {current} de {total} ─");
            Console.ResetColor();
        }

        public static void RenderTrainerCreated(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" ¡'{name}' fue creado exitosamente!");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderDummiesGenerating(int count)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  Generando {count} entrenadores automáticos...");
            Console.ResetColor();
        }

        public static void RenderDummiesGenerated()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ¡Entrenadores generados exitosamente!");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderTourneyReady(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ¡El torneo '{name}' está listo con 16 entrenadores!");
            Console.WriteLine("  Presiona Enter para comenzar...");
            Console.ResetColor();
        }
    }
}