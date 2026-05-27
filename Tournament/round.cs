namespace TorneoPokemon.Model.Tournament
{
//una ronda del torneo, compuesta por varios combates  
    public class round
    {
        public int roundNumber { get; set;}
        public string roundName { get; set; }
        public List<match> matches { get; private set; } = new();

        public round(int roundNumber, string roundName)
        {
            this.roundNumber = roundNumber;
            this.roundName   = roundName;
        }

        public void AddMatch(Match match) => matches.Add(match);

        public bool IsComplete() => matches.Count > 0 && matches.All(m => m.IsPlayed);

        /// <summary>Lista de entrenadores que ganaron en esta ronda.</summary>
        public List<string> GetWinners() =>
            matches.Where(m => m.IsPlayed && m.Winner != null)
                   .Select(m => m.Winner!.Name)
                   .ToList();

        public override string ToString() =>
            $"Ronda {roundNumber} — {roundName} | Combates: {matches.Count} | " +
            (IsComplete() ? "Finalizada" : "En curso");
    }
}
