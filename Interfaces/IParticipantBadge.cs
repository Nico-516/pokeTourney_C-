namespace pokeTourney.Model.Interfaces
{
//Credencial de los entrenadores registrados en el torneo.
    public interface IParticipantBadge
    {
        int Id { get; set; }

        string GetBadgeInfo();
    }
}