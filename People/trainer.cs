using pokeTourney.Model.Interfaces;
using pokeTourney.Model.Pokemon;

namespace pokeTourney.Model.People
{
//implementa IParticipantBadge (credencial oficial) e IViewerPermit (ver combates).

    public class Trainer : Person, IParticipantBadge, IViewerPermit
    {
        // IParticipantBadge 
        public int Id { get; set; }

        // IViewerPermit
        public int seatNumber { get; set; }

        // Trainer data 
        public string Gym { get; set; }
        public List<pokemonEntity> pokemonTeam { get; private set; } = new();
        public List<string> medalsAchieved { get; private set; } = new();

        public Trainer(string name, int age, string gym, int id, int seatNumber)
            : base(name, age)
        {
            Gym        = gym;
            Id         = id;
            seatNumber = seatNumber;
        }

//agrega un Pokémon al equipo (máximo 3)
        public bool AddPokemon(PokemonEntity pokemon)
        {
            if (pokemonTeam.Count >= 3)
                return false;

            pokemonTeam.Add(pokemon);
            return true;
        }

        public void AddMedal(string medal) => medalsAchieved.Add(medal);

        public string GetBadgeInfo()  =>
            $"Credencial #{Id} — Entrenador: {Name} | Gimnasio: {Gym}";

        public string GetPermitInfo() =>
            $"Permiso de espectador — Asiento: {seatNumber} | Titular: {Name}";

        public override string GetDescription() =>
            $"Entrenador {Name}, del gimnasio {Gym}. " +
            $"Equipo: {pokemonTeam.Count} Pokémon. Medallas: {medalsAchieved.Count}.";
    }
}