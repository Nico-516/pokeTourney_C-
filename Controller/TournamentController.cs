using System;
using System.Collections.Generic;
using Repository;
using Model;
using View;

namespace Controller
{
    public class TournamentController
    {
        private readonly IRepository<Pokemon> _repoPokemons;
        private readonly IRepository<Gym> _repoGyms;
        private readonly IRepository<Trainer> _repoTrainers;
        private readonly IRepository<string> _repoRegions;
        private readonly IRepository<Tourney> _repoTourneys;

        public TournamentController(
            IRepository<Pokemon> repoPokemons,
            IRepository<Gym> repoGyms,
            IRepository<Trainer> repoTrainers,
            IRepository<string> repoRegions,
            IRepository<Tourney> repoTourneys)
        {
            _repoPokemons = repoPokemons;
            _repoGyms = repoGyms;
            _repoTrainers = repoTrainers;
            _repoRegions = repoRegions;
            _repoTourneys = repoTourneys;
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                MenuView.RenderWelcome();
                MenuView.RenderMainMenu();

                int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-5): ", 1, 5);
                Console.WriteLine();

                if (choice == 1)
                {
                    Tourney tourney = CreateTourney.CreateNewTourneyWith16Trainers("SuperUltraTourney", _repoTrainers, _repoPokemons, _repoGyms);
                    ManageTourney.TourneyManager(tourney);
                    List<Tourney> torneos = _repoTourneys.LeerTodos();
                    torneos.Add(tourney);
                    _repoTourneys.GuardarTodos(torneos);
                }
                else if (choice == 2)
                {
                    Tourney tourney = ManualTourneyOrganizer.CreateAndRunManualTourney(_repoTrainers, _repoPokemons, _repoGyms, _repoRegions);
                    List<Tourney> torneos = _repoTourneys.LeerTodos();
                    torneos.Add(tourney);
                    _repoTourneys.GuardarTodos(torneos);
                }
                else if (choice == 3)
                {
                    ShowListsMenu();
                }
                else if (choice == 4)
                {
                    ShowSavedTourneys();
                }
                else if (choice == 5)
                {
                    MenuView.RenderGoodbye();
                    running = false;
                }
            }
        }

        private void ShowListsMenu()
        {
            bool inLists = true;
            while (inLists)
            {
                MenuView.RenderListsMenu();
                int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-5): ", 1, 5);
                Console.WriteLine();

                if (choice == 1)
                {
                    var pokemons = _repoPokemons.LeerTodos();
                    ListsView.RenderPokemons(pokemons);
                }
                else if (choice == 2)
                {
                    var gyms = _repoGyms.LeerTodos();
                    ListsView.RenderGyms(gyms);
                }
                else if (choice == 3)
                {
                    var trainers = _repoTrainers.LeerTodos();
                    ListsView.RenderTrainers(trainers);
                }
                else if (choice == 4)
                {
                    ShowSavedTourneys();
                }
                else if (choice == 5)
                {
                    inLists = false;
                }
            }
        }

        private void ShowSavedTourneys()
        {
            var tourneys = _repoTourneys.LeerTodos();
            ListsView.RenderSavedTourneys(tourneys);
        }
    }
}
