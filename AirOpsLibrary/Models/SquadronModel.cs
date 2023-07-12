using AirOpsLibrary.Enums;

namespace AirOpsLibrary.Models;

public class SquadronModel
{
    public int Id { get; set; }
    public int CommandingOfficerId { get; set; }
    public int ExecutiveOfficerId { get; set; }
    public string Designation { get; set; }
    public string Nickname { get; set; }
    public string RadioCallSign { get; set; }
    public string? Motto { get; set; }
    public AircraftRole Role { get; set; }
}