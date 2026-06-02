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
        Console.WriteLine("Error: Input cannot be empty or only spaces. Please try again.\n");
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
        Console.WriteLine($"Error: Please enter a valid integer between {min} and {max}.\n");
      }
    }

    public static bool ReadYesNo(string prompt)
    {
      while (true)
      {
        Console.Write(prompt + " (y/n): ");
        string? input = Console.ReadLine()?.Trim().ToLower();
        if (input == "y" || input == "yes")
        {
          return true;
        }
        if (input == "n" || input == "no")
        {
          return false;
        }
        Console.WriteLine("Error: Please enter 'y' or 'n'.\n");
      }
    }
  }
}
