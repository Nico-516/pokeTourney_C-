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
IRepository<Tourney> repoTourneys = new JsonRepository<Tourney>("SavedTourneys.json");

while (running)
{
    MenuView.RenderWelcome();
    MenuView.RenderMainMenu();

    int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-5): ", 1, 5);
    Console.WriteLine();

    if (choice == 1)
    {
        Tourney tourney = CreateTourney.CreateNewTourneyWith16Trainers("SuperUltraTourney", repoTrainers, repoPokemons, repoGyms);
        ManageTourney.TourneyManager(tourney);
        List<Tourney> torneos = repoTourneys.LeerTodos();
        torneos.Add(tourney);
        repoTourneys.GuardarTodos(torneos);
    }
    else if (choice == 2)
{
    Tourney tourney = ManualTourneyOrganizer.CreateAndRunManualTourney(repoTrainers, repoPokemons, repoGyms, repoRegions);
    List<Tourney> torneos = repoTourneys.LeerTodos();
    torneos.Add(tourney);
    repoTourneys.GuardarTodos(torneos);
}
    else if (choice == 3)
    {
        ShowListsMenu(  repoPokemons, repoGyms, repoTrainers, repoTourneys);
    }
    else
    {
        MenuView.RenderGoodbye();
        running = false;
    }
}

static void ShowListsMenu(IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms, IRepository<Trainer> repoTrainers, IRepository<Tourney> repoTourneys)
{
    bool inLists = true;
    while (inLists)
    {
        MenuView.RenderListsMenu();
        int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-5): ", 1, 5);
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

        else if (choice == 4)
        {
            ShowSavedTourneys(repoTourneys);
        }
        else
        {
            inLists = false;
        }
    }
}

static void ShowSavedTourneys(IRepository<Tourney> repoTourneys)
{
    var tourneys = repoTourneys.LeerTodos();
    ListsView.RenderSavedTourneys(tourneys);
}