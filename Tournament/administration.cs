using pokeTourney.Model.People;
using pokeTourney.Model.Pokemon;

namespace pokeTourney.Model.Tournament
{
// Sistema de administración del torneo Pokémon: entrenadores, fans, rondas y combates.

    public class admnistration
    {
        public string name { get; set; }
        public string edition{ get; set; }
        public DateOnly startDate { get; set; }
        public Round Round1 { get; } = new(1, "Octavos de final");
        public Round Round2 { get; } = new(2, "Cuartos de final");
        public Round Round3 { get; } = new(3, "Semifinal");
        public Round Round4 { get; } = new(4, "Tercer puesto");
        public Round Round5 { get; } = new(5, "Gran Final");


        private readonly List<Trainer> _trainers = new();
        private readonly List<Fan>     _fans     = new();
        private int _nextTrainerId = 1;
        private int _nextSeatNumber = 1;

        public administration(string name, string edition, DateOnly startDate)
        {
            this.name      = name;
            this.edition   = edition;
            this.startDate = startDate;
        }

//registra un entrenador con equipo elegido manualmente

        public Trainer AddTrainer(string name, int age, string gym, List<pokemonProperties> team)
        {
            ValidateTeam(team);
            var trainer = new Trainer(name, age, gym, _nextTrainerId++, _nextSeatNumber++);
            team.ForEach(p => trainer.AddPokemon(p));
            _trainers.Add(trainer);
            return trainer;
        }

//registra un entrenador asignándole un equipo aleatorio 
        public Trainer AddTrainerWithRandomTeam(string name, int age, string gym)
        {
            var trainer = new Trainer(name, age, gym, _nextTrainerId++, _nextSeatNumber++);
            Gen1PokemonRepository.GetRandomTeam(3).ForEach(p => trainer.AddPokemon(p));
            _trainers.Add(trainer);
            return trainer;
        }

        public Fan AddFan(string name, int age, string favoriteTeam = "")
        {
            var fan = new Fan(name, age, _nextSeatNumber++, favoriteTeam);
            _fans.Add(fan);
            return fan;
        }

        public IReadOnlyList<Trainer> listTrainers() => _trainers.AsReadOnly();
        public IReadOnlyList<Fan>     listFans()      => _fans.AsReadOnly();

        public void listAllRounds()
        {
            foreach (var round in new[] { Round1, Round2, Round3, Round4 })
            {
                Console.WriteLine(round);
                round.Matches.ForEach(m => Console.WriteLine($"  {m}"));
            }
        }
        public Trainer? findTrainerByName(string name) =>
            _trainers.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public Trainer? findTrainerById(int id) =>
            _trainers.FirstOrDefault(t => t.Id == id);

        public List<Trainer> findTrainersByGym(string gym) =>
            _trainers.Where(t => t.Gym.Equals(gym, StringComparison.OrdinalIgnoreCase)).ToList();

 //programa un combate en la ronda indicada 

        public Match scheduleMatch(int roundNumber, Trainer t1, Trainer t2, string arena, string location, DateOnly day)
        {
            var round = GetRound(roundNumber);
            var match = new Match(t1, t2, arena, location, day);
            round.AddMatch(match);
            return match;
        }

 //simula un combate automático comparando la suma de puntos de ataque de los equipos de cada entrenador
        public Trainer simulateBattle(Match match)
        {
            if (match.IsPlayed)
                throw new InvalidOperationException("Este combate ya fue jugado.");

            int power1 = match.Trainer1.PokemonTeam.Sum(p => p.AttackPoints);
            int power2 = match.Trainer2.PokemonTeam.Sum(p => p.AttackPoints);

// en empate, gana el que tiene mayor velocidad total
            if (power1 == power2)
            {
                power1 = match.Trainer1.PokemonTeam.Sum(p => p.SpeedPoints);
                power2 = match.Trainer2.PokemonTeam.Sum(p => p.SpeedPoints);
            }

            var winner     = power1 >= power2 ? match.Trainer1 : match.Trainer2;
            var roundName  = GetRound(GetRoundNumber(match)).RoundName;
            match.RegisterResult(winner, $"Medalla {roundName}");
            return winner;
        }

        private Round GetRound(int number) => number switch
        {
            1 => Round1,
            2 => Round2,
            3 => Round3,
            4 => Round4,
            5 => Round5,
            _ => throw new ArgumentOutOfRangeException(nameof(number), "Las rondas van del 1 al 5.")
        };

        private int getRoundnumber(Match match)
        {
            if (Round1.Matches.Contains(match)) return 1;
            if (Round2.Matches.Contains(match)) return 2;
            if (Round3.Matches.Contains(match)) return 3;
            if (Round4.Matches.Contains(match)) return 4;
            if (Round5.Matches.Contains(match)) return 5;
            throw new ArgumentException("El combate no pertenece a ninguna ronda.");
        }

        private static void validateTeam(List<pokemonProperties> team)
        {
            if (team == null || team.Count == 0 || team.Count > 3)
                throw new ArgumentException("El equipo debe tener entre 1 y 3 Pokémon.");
        }
    }
}
