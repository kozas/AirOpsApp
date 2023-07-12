namespace AirOpsLibrary.Models;

public class LoadoutModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AircraftTypeModel AircraftType { get; set; }
    public List<Armament>? Armaments { get; set; }
}
