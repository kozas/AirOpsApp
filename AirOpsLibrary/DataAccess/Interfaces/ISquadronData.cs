using AirOpsLibrary.Models;

namespace AirOpsLibrary.DataAccess
{
    public interface ISquadronData
    {
        Task<SquadronModel?> Create(string designation, string nickname, int roleId);
        Task Delete(int squadronId);
        Task<List<SquadronModel>> GetAll();
        Task<SquadronModel?> GetById(int squadronId);
        Task Update(int squadronId, int? commandingOfficerId, int? executiveOfficerId, string? designation, string? nickname, string? radioCallSign, string? motto, int? roleId);
    }
}