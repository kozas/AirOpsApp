using AirOpsLibrary.Models;

namespace AirOpsLibrary.DataAccess
{
    public interface IAircraftData
    {
        Task<AircraftModel?> Create(int modex, int aircraftTypeId, int squadronId);
        Task Delete(int aircraftId);
        Task<List<AircraftModel>> GetAll();
        Task<AircraftModel?> GetById(int aircraftId);
        Task UpdateLoadout(int aircraftId, int loadoutId);
        Task UpdateLocation(int aircraftId, int locationId);
        Task UpdatePilot(int aircraftId, int pilotId);
        Task UpdateSquadron(int aircraftId, int squadronId);
        Task UpdateStatus(int aircraftId, int statusId);
    }
}