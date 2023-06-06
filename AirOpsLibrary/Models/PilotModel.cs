namespace AirOpsLibrary.Models;

public class PilotModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CallSign { get; set; }
    public int SquadronId { get; set; }
    public int AircraftSerial { get; set; }
    public int SortieCount { get; set; }
    public int Competency { get; set; }
    public DateTime LastSortie { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}