using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepository<Region> _repoRegions;
        private readonly IRepository<Tourney> _repoTourneys;

        public TournamentController(
            IRepository<Pokemon> repoPokemons,
            IRepository<Gym> repoGyms,
            IRepository<Trainer> repoTrainers,
            IRepository<Region> repoRegions,
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
                Console.Clear();
                MenuView.RenderWelcome();
                MenuView.RenderMainMenu();

                int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-6): ", 1, 6);
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Clear();
                    Tourney tourney = CreateTourney.CreateNewTourneyWith16Trainers("SuperUltraTourney", _repoTrainers, _repoPokemons, _repoGyms);
                    ManageTourney.TourneyManager(tourney);
                    _repoTourneys.Add(tourney);
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    Tourney tourney = ManualTourneyOrganizer.CreateAndRunManualTourney(_repoTrainers, _repoPokemons, _repoGyms, _repoRegions);
                    _repoTourneys.Add(tourney);
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 3)
                {
                    ShowListsMenu();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    ShowSavedTourneys();
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 5)
                {
                    ShowTrainerCrudMenu();
                }
                else if (choice == 6)
                {
                    Console.Clear();
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
                Console.Clear();
                MenuView.RenderListsMenu();
                int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-5): ", 1, 5);
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Clear();
                    var pokemons = _repoPokemons.GetAll();
                    ListsView.RenderPokemons(pokemons);
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    var gyms = _repoGyms.GetAll();
                    ListsView.RenderGyms(gyms);
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    var trainers = _repoTrainers.GetAll();
                    ListsView.RenderTrainers(trainers);
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    ShowSavedTourneys();
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 5)
                {
                    inLists = false;
                }
            }
        }

        private void ShowSavedTourneys()
        {
            var tourneys = _repoTourneys.GetAll();
            ListsView.RenderSavedTourneys(tourneys);
        }

        private void ShowTrainerCrudMenu()
        {
            bool inCrud = true;
            while (inCrud)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  ── Administrar Entrenadores ──");
                Console.ResetColor();
                Console.WriteLine("    1.  Agregar Entrenador");
                Console.WriteLine("    2.  Listar Entrenadores");
                Console.WriteLine("    3.  Editar Entrenador por ID");
                Console.WriteLine("    4.  Eliminar Entrenador por ID");
                Console.WriteLine("    5.  Volver al menú principal");
                Console.WriteLine();

                int choice = InputValidator.ReadInteger("  Seleccionar una opción (1-5): ", 1, 5);
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("  ── Agregar Nuevo Entrenador ──");
                    string name = InputValidator.ReadNonEmptyString("  Ingresar nombre: ");
                    int age = InputValidator.ReadInteger("  Ingresar edad: ", 5, 120);

                    var regions = _repoRegions.GetAll();
                    Console.WriteLine("\n  Regiones disponibles:");
                    for (int i = 0; i < regions.Count; i++)
                    {
                        Console.WriteLine($"    [{i + 1}] {regions[i].Name}");
                    }
                    int regionIndex = InputValidator.ReadInteger($"  Seleccionar región (1-{regions.Count}): ", 1, regions.Count);
                    string region = regions[regionIndex - 1].Name;

                    string voiceLine = InputValidator.ReadNonEmptyString("  Ingresar frase característica: ");

                    var gyms = _repoGyms.GetAll();
                    Console.WriteLine("\n  Gimnasios disponibles:");
                    for (int i = 0; i < gyms.Count; i++)
                    {
                        Console.WriteLine($"    [{i + 1}] {gyms[i]._name} (Líder: {gyms[i]._leader}, Ciudad: {gyms[i]._city})");
                    }
                    int gymIndex = InputValidator.ReadInteger($"  Seleccionar gimnasio (1-{gyms.Count}): ", 1, gyms.Count);
                    Gym selectedGym = gyms[gymIndex - 1];

                    var allPokemons = _repoPokemons.GetAll();
                    Console.Clear();
                    ListsView.RenderPokemons(allPokemons);
                    var team = new List<Pokemon>();
                    Console.WriteLine("\n  Seleccionar Pokémon para el equipo (hasta 6 Pokémon, ingresar ID del 1 al 100):");
                    while (team.Count < 6)
                    {
                        int pokeId = InputValidator.ReadInteger($"    Ingresar ID del Pokémon #{team.Count + 1}: ", 1, 100);
                        var selectedPoke = allPokemons.FirstOrDefault(p => p.Id == pokeId);
                        if (selectedPoke == null)
                        {
                            Console.WriteLine("    Error: Pokémon no encontrado.");
                            continue;
                        }
                        if (team.Any(p => p.Id == pokeId))
                        {
                            Console.WriteLine($"    Error: {selectedPoke._name} ya está en el equipo.");
                            continue;
                        }
                        team.Add(new Pokemon(selectedPoke));
                        Console.WriteLine($"    ¡{selectedPoke._name} agregado!");

                        if (team.Count < 6)
                        {
                            bool keepAdding = InputValidator.ReadYesNo("    ¿Quieres agregar otro Pokémon?");
                            if (!keepAdding) break;
                        }
                    }

                    Trainer newTrainer = new Trainer(name, age, region, voiceLine);
                    newTrainer._gym = selectedGym;
                    newTrainer._pokemonTeam = team;

                    _repoTrainers.Add(newTrainer);
                    Console.WriteLine($"\n  ¡Entrenador {newTrainer._name} agregado exitosamente con ID {newTrainer.Id}!");
                    Console.WriteLine();
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    var trainers = _repoTrainers.GetAll();
                    ListsView.RenderTrainers(trainers);
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("  ── Editar Entrenador ──");
                    var trainers = _repoTrainers.GetAll();
                    ListsView.RenderTrainers(trainers);
                    int id = InputValidator.ReadInteger("  Ingresar el ID del entrenador a editar: ", 1, 99999);
                    Trainer? trainer = _repoTrainers.GetById(id);
                    if (trainer == null)
                    {
                        Console.WriteLine("  Error: Entrenador no encontrado.");
                        Console.WriteLine();
                        Console.WriteLine("\n  Presiona Enter para continuar...");
                        Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"  Editando a {trainer._name} (ID: {trainer.Id})");
                    string name = InputValidator.ReadNonEmptyString($"  Ingresar nuevo nombre [{trainer._name}]: ");
                    int age = InputValidator.ReadInteger($"  Ingresar nueva edad [{trainer._age}]: ", 5, 120);

                    var regions = _repoRegions.GetAll();
                    Console.WriteLine("\n  Regiones disponibles:");
                    for (int i = 0; i < regions.Count; i++)
                    {
                        Console.WriteLine($"    [{i + 1}] {regions[i].Name}");
                    }
                    int regionIndex = InputValidator.ReadInteger($"  Seleccionar nueva región (actual: {trainer._region}): ", 1, regions.Count);
                    string region = regions[regionIndex - 1].Name;

                    string voiceLine = InputValidator.ReadNonEmptyString($"  Ingresar nueva frase [{trainer._voiceLine}]: ");

                    var gyms = _repoGyms.GetAll();
                    Console.WriteLine("\n  Gimnasios disponibles:");
                    for (int i = 0; i < gyms.Count; i++)
                    {
                        Console.WriteLine($"    [{i + 1}] {gyms[i]._name} (Líder: {gyms[i]._leader}, Ciudad: {gyms[i]._city})");
                    }
                    int gymIndex = InputValidator.ReadInteger($"  Seleccionar nuevo gimnasio (actual: {trainer._gym?._name ?? "Ninguno"}): ", 1, gyms.Count);
                    Gym selectedGym = gyms[gymIndex - 1];

                    var allPokemons = _repoPokemons.GetAll();
                    Console.Clear();
                    ListsView.RenderPokemons(allPokemons);
                    var team = new List<Pokemon>();
                    Console.WriteLine("\n  Seleccionar nuevo equipo de Pokémon (hasta 6 Pokémon):");
                    while (team.Count < 6)
                    {
                        int pokeId = InputValidator.ReadInteger($"    Ingresar ID del Pokémon #{team.Count + 1}: ", 1, 100);
                        var selectedPoke = allPokemons.FirstOrDefault(p => p.Id == pokeId);
                        if (selectedPoke == null)
                        {
                            Console.WriteLine("    Error: Pokémon no encontrado.");
                            continue;
                        }
                        if (team.Any(p => p.Id == pokeId))
                        {
                            Console.WriteLine($"    Error: {selectedPoke._name} ya está en el equipo.");
                            continue;
                        }
                        team.Add(new Pokemon(selectedPoke));
                        Console.WriteLine($"    ¡{selectedPoke._name} agregado!");

                        if (team.Count < 6)
                        {
                            bool keepAdding = InputValidator.ReadYesNo("    ¿Quieres agregar otro Pokémon?");
                            if (!keepAdding) break;
                        }
                    }

                    trainer._name = name;
                    trainer._age = age;
                    trainer._region = region;
                    trainer._voiceLine = voiceLine;
                    trainer._gym = selectedGym;
                    trainer._pokemonTeam = team;

                    _repoTrainers.Update(trainer);
                    Console.WriteLine($"\n  ¡Entrenador {trainer._name} (ID: {trainer.Id}) actualizado exitosamente!");
                    Console.WriteLine();
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("  ── Eliminar Entrenador ──");
                    var trainers = _repoTrainers.GetAll();
                    ListsView.RenderTrainers(trainers);
                    int id = InputValidator.ReadInteger("  Ingresar el ID del entrenador a eliminar: ", 1, 99999);
                    Trainer? trainer = _repoTrainers.GetById(id);
                    if (trainer == null)
                    {
                        Console.WriteLine("  Error: Entrenador no encontrado.");
                        Console.WriteLine();
                        Console.WriteLine("\n  Presiona Enter para continuar...");
                        Console.ReadLine();
                        continue;
                    }

                    bool confirm = InputValidator.ReadYesNo($"  ¿Está seguro de que desea eliminar a {trainer._name} (ID: {trainer.Id})?");
                    if (confirm)
                    {
                        _repoTrainers.Delete(id);
                        Console.WriteLine($"  ¡Entrenador {trainer._name} eliminado exitosamente!");
                    }
                    else
                    {
                        Console.WriteLine("  Operación cancelada.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else if (choice == 5)
                {
                    inCrud = false;
                }
            }
        }
    }
}
