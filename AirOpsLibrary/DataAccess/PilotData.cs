using AirOpsLibrary.DataAccess.Interfaces;
using AirOpsLibrary.Models;

namespace AirOpsLibrary.DataAccess;

public class PilotData : IPilotData
{
    private readonly ISqlDataAccess sql;

    public PilotData(ISqlDataAccess sql)
    {
        this.sql = sql;
    }

    public Task<List<PilotModel>> GetAll()
    {
        return sql.LoadData<PilotModel, dynamic>("dbo.spPilots_GetAll",
            new { },
            "Default");
    }

    public async Task<PilotModel?> GetById(int pilotId)
    {
        var result = await sql.LoadData<PilotModel, dynamic>("dbo.spPilots_Lookup",
            new { id = pilotId },
            "Default");

        return result.FirstOrDefault();
    }

    public async Task<PilotModel?> Create(string firstName, string lastName, string callSign)
    {
        var result = await sql.LoadData<PilotModel, dynamic>("dbo.spPilots_Insert",
            new { FirstName = firstName, LastName = lastName, CallSign = callSign },
            "Default");

        return result.FirstOrDefault();
    }

    public Task UpdateInformation(int pilotId, string firstName, string lastName, string callSign)
    {
        return sql.SaveData<dynamic>("dbo.spPilots_Update",
            new { id = pilotId, FirstName = firstName, LastName = lastName, CallSign = callSign },
            "Default");
    }

    public Task UpdateCompetency(int pilotId, int competency)
    {
        return sql.SaveData<dynamic>("dbo.spPilots_UpdateCompetency",
            new { id = pilotId, Competency = competency },
            "Default");
    }

    public Task UpdateSorties(int pilotId, int sortieCount, DateTime lastSortie)
    {
        return sql.SaveData<dynamic>("dbo.spAircraft_UpdatePilot",
            new { id = pilotId, SortieCount = sortieCount, LastSortie = lastSortie },
            "Default");
    }

    public Task Delete(int pilotId)
    {
        return sql.SaveData<dynamic>("dbo.spPilots_Delete",
            new { id = pilotId },
            "Default");
    }
}
