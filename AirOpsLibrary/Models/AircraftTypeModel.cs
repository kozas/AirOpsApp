using AirOpsLibrary.Enums;

namespace AirOpsLibrary.Models;

public class AircraftTypeModel
{
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Designation { get; set; }
    public string Nickname { get; set; }
    public AircraftRole Role { get; set; }
    public int Weight { get; set; }
}