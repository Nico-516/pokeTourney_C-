using System;
using Controller;
using Model;

Console.WriteLine("==================================================");
Console.WriteLine("       Bienvenido a PokeTourney Simulation        ");
Console.WriteLine("==================================================");
Console.WriteLine();

Console.WriteLine("Seleccionar una opción:");
Console.WriteLine("1. Opción simulada (Auto-run tournament)");
Console.WriteLine("2. Opción no simulada - manual (Create trainers & choose winners)");
Console.WriteLine("3. Ver listas de entrenador - pokemon");
Console.WriteLine();

int choice = InputValidator.ReadInteger("Seleccionar una opción (1-3): ", 1, 3);
Console.WriteLine();

if (choice == 1)
{
  Tourney tourney = CreateTourney.CreateNewTourneyWith16Trainers("SuperUltraTourney");
  ManageTourney.TourneyManager(tourney);
}
else if (choice == 2)
{
  ManualTourneyOrganizer.CreateAndRunManualTourney();
}
else
{
  ShowListsMenu();
}

static void ShowListsMenu()
{
  while (true)
  {
    Console.WriteLine("--- VER LISTAS DE POKEMONS, GIMNASIOS Y ENTRENADORES ---");
    Console.WriteLine("1. Ver lista de pokemons (IDs 1-100 & Stats)");
    Console.WriteLine("2. Ver lista de gimnasios");
    Console.WriteLine("3. Ver lista de entrenadores");
    Console.WriteLine("4. Salir");
    Console.WriteLine();
    
    int choice = InputValidator.ReadInteger("Seleccionar una opción (1-4): ", 1, 4);
    Console.WriteLine();

    if (choice == 1)
    {
      var pokemons = Controller.JsonGetters.GetPokemons.GetPokemonsFromJSON();
      Console.WriteLine("--------------------------------------------------------------------------------");
      Console.WriteLine($"{"ID",-5} | {"Nombre",-15} | {"Vida",-5} | {"Ataque",-6} | {"Defensa",-7} | {"Tipo",-20}");
      Console.WriteLine("--------------------------------------------------------------------------------");
      foreach (var p in pokemons)
      {
        Console.WriteLine($"{p._id,-5} | {p._name,-15} | {p._healthPoints,-5} | {p._attackPoints,-6} | {p._defencePoints,-7} | {string.Join(", ", p._type),-20}");
      }
      Console.WriteLine("--------------------------------------------------------------------------------");
      Console.WriteLine();
    }
    else if (choice == 2)
    {
      var gyms = Controller.JsonGetters.GetGyms.GetGymsFromJSON();
      Console.WriteLine("--------------------------------------------------------------------------------");
      Console.WriteLine($"{"Nombre",-25} | {"Líder",-15} | {"Ciudad",-15} | {"Región",-15}");
      Console.WriteLine("--------------------------------------------------------------------------------");
      foreach (var g in gyms)
      {
        Console.WriteLine($"{g._name,-25} | {g._leader,-15} | {g._city,-15} | {g._region,-15}");
      }
      Console.WriteLine("--------------------------------------------------------------------------------");
      Console.WriteLine();
    }
    else if (choice == 3)
    {
      var trainers = Controller.JsonGetters.GetDummyTrainer.GetDummyTrainersFromJSON();
      Console.WriteLine("-------------------------------------------------------------------------------------------------");
      Console.WriteLine($"{"ID",-5} | {"Nombre",-15} | {"Edad",-5} | {"Región",-10} | {"Frase de voz",-50}");
      Console.WriteLine("-------------------------------------------------------------------------------------------------");
      foreach (var t in trainers)
      {
        Console.WriteLine($"{t._id,-5} | {t._name,-15} | {t._age,-5} | {t._region,-10} | {t._voiceLine,-50}");
      }
      Console.WriteLine("-------------------------------------------------------------------------------------------------");
      Console.WriteLine();
    }
    else
    {
      break;
    }
  }
}