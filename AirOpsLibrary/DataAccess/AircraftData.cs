using AirOpsLibrary.DataAccess.Interfaces;
using AirOpsLibrary.Models;

namespace AirOpsLibrary.DataAccess;

public class AircraftData : IAircraftData
{
    private readonly ISqlDataAccess sql;

    public AircraftData(ISqlDataAccess sql)
    {
        this.sql = sql;
    }

    public Task<List<AircraftModel>> GetAll()
    {
        return sql.LoadData<AircraftModel, dynamic>("dbo.spAircraft_GetAll",
            new { },
            "Default");
    }

    public async Task<AircraftModel?> GetById(int aircraftId)
    {
        var result = await sql.LoadData<AircraftModel, dynamic>("dbo.spAircraft_Lookup",
            new { AircraftId = aircraftId },
            "Default");

        return result.FirstOrDefault();
    }

    public async Task<AircraftModel?> Create(int modex, int aircraftTypeId, int squadronId)
    {
        var result = await sql.LoadData<AircraftModel, dynamic>("dbo.spAircraft_Insert",
            new { Modex = modex, AircraftTypeId = aircraftTypeId, SquadronId = squadronId },
            "Default");

        return result.FirstOrDefault();
    }

    public Task UpdateLoadout(int aircraftId, int loadoutId)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_UpdateLoadout",
            new { AircraftId = aircraftId, LoadoutId = loadoutId },
            "Default");
    }

    public Task UpdateLocation(int aircraftId, int locationId)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_UpdateLocation",
            new { AircraftId = aircraftId, LocationId = locationId },
            "Default");
    }

    public Task UpdatePilot(int aircraftId, int pilotId)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_UpdatePilot",
            new { AircraftId = aircraftId, PilotId = pilotId },
            "Default");
    }

    public Task UpdateSquadron(int aircraftId, int squadronId)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_UpdateSquadron",
            new { AircraftId = aircraftId, SquadronId = squadronId },
            "Default");
    }

    public Task UpdateStatus(int aircraftId, int statusId)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_UpdateStatus",
            new { AircraftId = aircraftId, StatusId = statusId },
            "Default");
    }

    public Task Delete(int aircraftId)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_Delete",
            new { AircraftId = aircraftId },
            "Default");
    }
}

