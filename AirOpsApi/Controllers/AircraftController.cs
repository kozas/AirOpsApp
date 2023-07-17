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
        private readonly ILogger<AircraftController> logger;

        public AircraftController(IAircraftData data, ILogger<AircraftController> logger)
        {
            this.data = data;
            this.logger = logger;
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
            logger.LogInformation("GET: {apiPath}", $"api/Aircraft");

            try
            {
                var output = await data.GetAll();

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - GET: {apiPath}", $"api/Aircraft");

                return BadRequest();
            }
        }

        // GET api/Aircraft/5
        [HttpGet("{aircraftId}")]
        public async Task<ActionResult<AircraftModel>> Get(int aircraftId)
        {
            logger.LogInformation("GET: {apiPath}/{aircraftId}", $"api/Aircraft", aircraftId);

            try
            {
                var output = await data.GetById(aircraftId);

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - GET: {apiPath}/{aircraftId}", $"api/Aircraft", aircraftId);

                return BadRequest();
            }
        }

        // POST api/Aircraft
        [HttpPost]
        public async Task<ActionResult<AircraftModel>> Post([FromBody] AircraftModel aircraft)
        {
            logger.LogInformation("POST: {apiPath}", $"api/Aircraft");

            try
            {
                var output = await data.Create(aircraft.Modex, aircraft.AircraftTypeId, aircraft.SquadronId);

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - POST: {apiPath}", $"api/Aircraft");

                return BadRequest();
            }
        }

        // PATCH api/Aircraft/5/Loadout
        [HttpPatch("{aircraftId}/Loadout")]
        public async Task<IActionResult> Patch(int aircraftId, [FromBody] LoadoutModel loadout)
        {
            logger.LogInformation("PATCH: {apiPath}/{aircraftId}/Loadout", $"api/Aircraft", aircraftId);

            try
            {
                await data.UpdateLoadout(aircraftId, loadout.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PATCH: {apiPath}/{aircraftId}/Loadout", $"api/Aircraft", aircraftId);

                return BadRequest();
            }
        }

        // PATCH api/Aircraft/5/Location
        [HttpPatch("{id}/Location")]
        public async Task<IActionResult> Patch(int aircraftId, [FromBody] LocationModel location)
        {
            logger.LogInformation("PATCH: {apiPath}/{aircraftId}/Location", $"api/Aircraft", aircraftId);

            try
            {
                await data.UpdateLocation(aircraftId, location.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PATCH: {apiPath}/{aircraftId}/Location", $"api/Aircraft", aircraftId);

                return BadRequest();
            }
        }

        // PATCH api/Aircraft/5/Pilot
        [HttpPatch("{id}/Pilot")]
        public async Task<IActionResult> Patch(int aircraftId, [FromBody] PilotModel pilot)
        {
            logger.LogInformation("PATCH: {apiPath}/{aircraftId}/Pilot", $"api/Aircraft", aircraftId);

            try
            {
                await data.UpdatePilot(aircraftId, pilot.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PATCH: {apiPath}/{aircraftId}/Pilot", $"api/Aircraft", aircraftId);

                return BadRequest();
            }
        }

        // PATCH api/Aircraft/5/Squadron
        [HttpPatch("{aircraftId}/Squadron")]
        public async Task<ActionResult> Patch(int aircraftId, [FromBody] SquadronModel squadron)
        {
            logger.LogInformation("PATCH: {apiPath}/{aircraftId}/Squadron", $"api/Aircraft", aircraftId);

            try
            {
                await data.UpdateSquadron(aircraftId, squadron.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PATCH: {apiPath}/{aircraftId}/Squadron", $"api/Aircraft", aircraftId);

                return BadRequest();
            }
        }

        // PATCH api/Aircraft/5/Status
        [HttpPatch("{id}/Status")]
        public async Task<IActionResult> Patch(int aircraftId, [FromBody] AircraftStatus status)
        {
            logger.LogInformation("PATCH: {apiPath}/{aircraftId}/Status", $"api/Aircraft", aircraftId);

            try
            {
                await data.UpdateStatus(aircraftId, (int)status);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PATCH: {apiPath}/{aircraftId}/Status", $"api/Aircraft", aircraftId);

                return BadRequest();
            }
        }

        // DELETE api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("DELETE: {apiPath}", $"api/Aircraft");

            try
            {
                await data.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - DELETE: {apiPath}", $"api/Aircraft");

                return BadRequest();
            }
        }
    }
}
