namespace pokeTourney.Model.Interfaces
{

// Permiso para ver combates 
    public interface IViewerPermit
    {
        int SeatNumber { get; set; }

        string GetPermitInfo();
    }
}
