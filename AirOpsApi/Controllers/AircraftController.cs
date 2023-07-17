using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;
using AirOpsLibrary.Enums;
using System.Security.Claims;
using AirOpsLibrary.DataAccess.Interfaces;

namespace AirOpsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftData data;

        public AircraftController(IAircraftData data)
        {
            this.data = data;
        }

        // Not currently used
        private int GetUserId()
        {
            var userIdText = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdText);
        }

        // GET: api/Aircraft
        [HttpGet]
        public async Task<ActionResult<List<AircraftModel>>> Get()
        {
            var output = await data.GetAll();

            return Ok(output);
        }

        // GET api/Aircraft/5
        [HttpGet("{aircraftId}")]
        public async Task<ActionResult<AircraftModel>> Get(int aircraftId)
        {
            var output = await data.GetById(aircraftId);

            return Ok(output);
        }

        // POST api/Aircraft
        [HttpPost]
        public async Task<ActionResult<AircraftModel>> Post([FromBody] AircraftModel aircraft)
        {
            var output = await data.Create(aircraft.Modex, aircraft.AircraftTypeId, aircraft.SquadronId);

            return Ok(output);
        }

        // PATCH api/Aircraft/5/Loadout
        [HttpPatch("{aircraftId}/Loadout")]
        public async Task<IActionResult> Patch(int aircraftId, [FromBody] LoadoutModel loadout)
        {
            await data.UpdateLoadout(aircraftId, loadout.Id);

            return Ok();
        }

        // PATCH api/Aircraft/5/Location
        [HttpPatch("{id}/Location")]
        public async Task<IActionResult> Patch(int id, [FromBody] LocationModel location)
        {
            await data.UpdateLocation(id, location.Id);

            return Ok();
        }

        // PATCH api/Aircraft/5/Pilot
        [HttpPatch("{id}/Pilot")]
        public async Task<IActionResult> Patch(int id, [FromBody] PilotModel pilot)
        {
            await data.UpdatePilot(id, pilot.Id);

            return Ok();
        }

        // PATCH api/Aircraft/5/Squadron
        [HttpPatch("{aircraftId}/Squadron")]
        public async Task<ActionResult> Patch(int aircraftId, [FromBody] SquadronModel squadron)
        {
            await data.UpdateSquadron(aircraftId, squadron.Id);

            return Ok();
        }

        // PATCH api/Aircraft/5/Status
        [HttpPatch("{id}/Status")]
        public async Task<IActionResult> Patch(int id, [FromBody] AircraftStatus status)
        {
            await data.UpdateStatus(id, (int) status);

            return Ok();
        }

        // DELETE api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await data.Delete(id);

            return Ok();
        }
    }
}
