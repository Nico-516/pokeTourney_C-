using System;
using Controller;
using Model;
using Repository;

IRepository<Pokemon> repoPokemons = new JsonRepository<Pokemon>("PokemonLibrary.json");
IRepository<Gym> repoGyms = new JsonRepository<Gym>("GymLibrary.json");
IRepository<Trainer> repoTrainers = new JsonRepository<Trainer>("DummyTrainerLibrary.json");
IRepository<string> repoRegions = new JsonRepository<string>("RegionLibrary.json");
IRepository<Tourney> repoTourneys = new JsonRepository<Tourney>("SavedTourneys.json");

TournamentController controller = new TournamentController(repoPokemons, repoGyms, repoTrainers, repoRegions, repoTourneys);
controller.Start();