using AirOpsLibrary.Models;

namespace AirOpsLibrary.DataAccess.Interfaces
{
    public interface IPilotData
    {
        Task<PilotModel?> Create(string firstName, string lastName, string callSign);
        Task Delete(int pilotId);
        Task<List<PilotModel>> GetAll();
        Task<PilotModel?> GetById(int pilotId);
        Task UpdateInformation(int pilotId, string firstName, string lastName, string callSign);
        Task UpdateCompetency(int pilotId, int competency);
        Task UpdateSorties(int pilotId, int sortieCount, DateTime lastSortie);
    }
}