using System;
using Controller;
using Controller.JsonGetters;
using Model;
using View;

bool running = true;
while (running)
{
    MenuView.RenderWelcome();
    MenuView.RenderMainMenu();

    int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-4): ", 1, 4);
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
    else if (choice == 3)
    {
        ShowListsMenu();
    }
    else
    {
        MenuView.RenderGoodbye();
        running = false;
    }
}

static void ShowListsMenu()
{
    bool inLists = true;
    while (inLists)
    {
        MenuView.RenderListsMenu();
        int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-4): ", 1, 4);
        Console.WriteLine();

        if (choice == 1)
        {
            var pokemons = GetPokemons.GetPokemonsFromJSON();
            ListsView.RenderPokemons(pokemons);
        }
        else if (choice == 2)
        {
            var gyms = GetGyms.GetGymsFromJSON();
            ListsView.RenderGyms(gyms);
        }
        else if (choice == 3)
        {
            var trainers = GetDummyTrainer.GetDummyTrainersFromJSON();
            ListsView.RenderTrainers(trainers);
        }
        else
        {
            inLists = false;
        }
    }
}
