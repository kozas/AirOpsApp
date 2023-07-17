using AirOpsLibrary.DataAccess.Interfaces;
using AirOpsLibrary.Models;

namespace AirOpsLibrary.DataAccess;

public class SquadronData : ISquadronData
{
    private readonly ISqlDataAccess sql;

    public SquadronData(ISqlDataAccess sql)
    {
        this.sql = sql;
    }

    public Task<List<SquadronModel>> GetAll()
    {
        return sql.LoadData<SquadronModel, dynamic>("dbo.spSquadrons_GetAll",
            new { },
            "Default");
    }

    public async Task<SquadronModel?> GetById(int squadronId)
    {
        var result = await sql.LoadData<SquadronModel, dynamic>("dbo.spSquadrons_Lookup",
            new { id = squadronId },
            "Default");

        return result.FirstOrDefault();
    }

    public async Task<SquadronModel?> Create(
        string designation,
        string nickname,
        int roleId)
    {
        var result = await sql.LoadData<SquadronModel, dynamic>("dbo.spSquadrons_Insert",
            new { Designation = designation, Nickname = nickname, RoleId = roleId },
            "Default");

        return result.FirstOrDefault();
    }

    public Task Update(
        int squadronId,
        int? commandingOfficerId,
        int? executiveOfficerId,
        string? designation,
        string? nickname,
        string? radioCallSign,
        string? motto,
        int? roleId)
    {
        return sql.SaveData<dynamic>("dbo.spSquadrons_Update", new
        {
            id = squadronId,
            CommandingOfficerId = commandingOfficerId,
            ExecutiveOfficerId = executiveOfficerId,
            Designation = designation,
            Nickname = nickname,
            RadioCallSign = radioCallSign,
            Motto = motto,
            RoleId = roleId
        },
            "Default");
    }

    public Task Delete(int squadronId)
    {
        return sql.SaveData<dynamic>("dbo.spSquadrons_Delete",
            new { id = squadronId },
            "Default");
    }
}
