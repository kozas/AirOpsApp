using AirOpsLibrary.Enums;

namespace AirOpsLibrary.Models;

public class AircraftModel
{
    public int Id { get; set; }
    public int Modex { get; set; }
    public int AircraftTypeId { get; set; }
    public int SquadronId { get; set; }
    public int PilotId { get; set; }
    public int LocationId { get; set; }
    public int LoadoutId { get; set; }
    public int FuelState { get; set; }
    public int Condition { get; set; }
    public int SortiesCount { get; set; }
    public int ServicesCount { get; set; }
    public AircraftStatus Status { get; set; }
    public DateTime LastSortie { get; set; }
    public DateTime LastService { get; set; }
}