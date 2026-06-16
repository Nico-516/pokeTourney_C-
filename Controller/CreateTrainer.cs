using Model;
using Repository;

namespace Controller
{
  public static class CreateTrainer
  {
    private static Random rnd = new Random();

    public static List<Trainer> Create16DummyTrainers(IRepository<Trainer> repoTrainers, IRepository<Pokemon> repoPokemons, IRepository<Gym> repoGyms)
    {
      List<Trainer> selectedTrainers = new List<Trainer>();
      List<Trainer> dummyTrainers = repoTrainers.LeerTodos();

      do{
        int rndTrainerIndex = rnd.Next(dummyTrainers.Count);
        Trainer newTrainer = dummyTrainers[rndTrainerIndex];

        if (selectedTrainers.Contains(newTrainer)){
          continue;
        }

        newTrainer._pokemonTeam = GeneratePokemonTeam(repoPokemons);
        newTrainer._gym = AssignGym(repoGyms);

        selectedTrainers.Add(newTrainer);
        
      } while (selectedTrainers.Count < 16);
      
      return selectedTrainers;
    }

    public static List<Pokemon> GeneratePokemonTeam( IRepository<Pokemon> repoPokemons){
      List<Pokemon> pokemonTeam = new List<Pokemon>();
      List<Pokemon> allPokemon = repoPokemons.LeerTodos();

      do {
        int rndPokemonIndex = rnd.Next(allPokemon.Count);
        Pokemon newPokemon = allPokemon[rndPokemonIndex];

        if (pokemonTeam.Contains(newPokemon)){
          continue;
        }

        pokemonTeam.Add(newPokemon);
        
      } while (pokemonTeam.Count < 6);
      
      return pokemonTeam;
    }

    public static Gym AssignGym(IRepository<Gym> repoGyms){
      List<Gym> allGyms = repoGyms.LeerTodos();
      int rndGymIndex = rnd.Next(allGyms.Count);
      Gym newGym = allGyms[rndGymIndex];
      return newGym;
    }
  }
}