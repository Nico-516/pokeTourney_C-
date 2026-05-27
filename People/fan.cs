using pokeTourney.Model.Interfaces;

namespace pokeTourney.Model.People
{
// Fan.Solo observa combates
//Implementa IViewerPermit 
    public class Fan : Person, IViewerPermit
    {
        public int seatNumber { get; set;}
        public string FavoriteTeam { get; set;}

        public Fan(string name, int age, int seatNumber, string favoriteTeam = "")
            : base(name, age)
        {
            seatNumber = seatNumber;
            FavoriteTeam = favoriteTeam;
        }

        public string GetPermitInfo() =>
            $"Entrada de espectador — Asiento: {seatNumber} | Fan: {Name}";

        public override string GetDescription() =>
            $"Fan {Name}. Asiento: {seatNumber}. " +
            (string.IsNullOrEmpty(FavoriteTeam) ? "" : $"Hincha de: {FavoriteTeam}.");
    }
}
