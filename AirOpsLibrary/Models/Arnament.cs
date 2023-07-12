using AirOpsLibrary.Enums;

namespace AirOpsLibrary.Models;

public class Armament
{
    public int Id { get; set; }
    public string? Designation { get; set; }
    public string? Name { get; set; }
    public ArmamentType Type { get; set; }
    public int Weight { get; set; }
    public int PylonNumber { get;set; }
}

