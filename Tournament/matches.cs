using TorneoPokemon.Model.People;

namespace pokeTourney.Model.Tournament
{
// Tiene dos entrenadores, la arena, el día y el lugar. Es un combate individual dentro de una ronda del torneo
    public class matches
    {
        public Trainer trainer1  { get; set; }
        public Trainer trainer2  { get; set; }
        public string  arena     { get; set; }
        public string  location  { get; set; }
        public DateOnly day      { get; set; }
        public Trainer? winner   { get; private set; }
        public bool    isPlayed  { get; private set; } = false;

        public matches(Trainer trainer1, Trainer trainer2, string arena, string location, DateOnly day)
        {
            trainer1 = trainer1;
            trainer2 = trainer2;
            arena    = arena;
            location = location;
            day      = day;
        }

 // el ganador recibe una medalla de la ronda

        public void registerResult(Trainer winner, string medalName)
        {
            if (winner != trainer1 && winner != trainer2)
                throw new ArgumentException("El ganador debe ser uno de los dos entrenadores del combate.");

            this.winner = winner;
            isPlayed = true;
            winner.AddMedal(medalName);
        }

        public override string ToString() =>
            $"{trainer1.Name} vs {trainer2.Name} | {arena}, {location} | {day:dd/MM/yyyy}" +
            (isPlayed ? $" → Ganador: {winner!.Name}" : " (pendiente)");
    }
}
