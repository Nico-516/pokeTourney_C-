using System;

namespace Controller
{
  public static class InputValidator
  {
    public static string ReadNonEmptyString(string prompt)
    {
      while (true)
      {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
          return input.Trim();
        }
        Console.WriteLine("Error: El input no puede estar vacío o contener solo espacios. Por favor, intenta de nuevo.\n");
      }
    }

    public static int ReadInteger(string prompt, int min, int max)
    {
      while (true)
      {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int result) && result >= min && result <= max)
        {
          return result;
        }
        Console.WriteLine($"Error: Ingrese un número válido entre {min} y {max}.\n");
      }
    }

    public static bool ReadYesNo(string prompt)
    {
      while (true)
      {
        Console.Write(prompt + " (s/n): ");
        string? input = Console.ReadLine()?.Trim().ToLower();
        if (input == "s" || input == "si")
        {
          return true;
        }
        if (input == "n" || input == "no")
        {
          return false;
        }
        Console.WriteLine("Error: Por favor, ingrese 's' o 'n'.\n");
      }
    }
  }
}
