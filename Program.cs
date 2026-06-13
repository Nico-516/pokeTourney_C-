using System;
using Controller;
using Model;
using View;
using Controller.Repository;


bool running = true;

IRepository<Pokemon> repoPokemons = new JsonRepository<Pokemon>("PokemonLibrary.json");
IRepository<Gym> repoGyms = new JsonRepository<Gym>("GymLibrary.json");
IRepository<Trainer> repoTrainers = new JsonRepository<Trainer>("DummyTrainerLibrary.json");
IRepository<string> repoRegions = new JsonRepository<string>("RegionLibrary.json");

while (running)
{
    MenuView.RenderWelcome();
    MenuView.RenderMainMenu();

    int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-4): ", 1, 4);
    Console.WriteLine();

    if (choice == 1)
    {
        Tourney tourney = CreateTourney.CreateNewTourneyWith16Trainers("SuperUltraTourney", repoTrainers, repoPokemons, repoGyms);
        ManageTourney.TourneyManager(tourney);
    }
    else if (choice == 2)
    {
        ManualTourneyOrganizer.CreateAndRunManualTourney(repoTrainers, repoPokemons, repoGyms, repoRegions);
    }
    else if (choice == 3)
    {
        ShowListsMenu(  repoPokemons, repoGyms, repoTrainers);
    }
    else
    {
        MenuView.RenderGoodbye();
        running = false;
    }
}

static void ShowListsMenu(IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<Trainer> repoTrainers)
{
    bool inLists = true;
    while (inLists)
    {
        MenuView.RenderListsMenu();
        int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-4): ", 1, 4);
        Console.WriteLine();

        if (choice == 1)
        {
            var pokemons = repoPokemons.LeerTodos();
            ListsView.RenderPokemons(pokemons);
        }
        else if (choice == 2)
        {
            var gyms = repoGyms.LeerTodos();
            ListsView.RenderGyms(gyms);
        }
        else if (choice == 3)
        {
            var trainers = repoTrainers.LeerTodos();
            ListsView.RenderTrainers(trainers);
        }
        else
        {
            inLists = false;
        }
    }
}
