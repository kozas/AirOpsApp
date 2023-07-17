using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;
using AirOpsLibrary.Enums;
using System.Security.Claims;
using AirOpsLibrary.DataAccess.Interfaces;

namespace AirOpsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotsController : ControllerBase
    {
        private readonly IPilotData data;
        private readonly ILogger<PilotsController> logger;

        public PilotsController(IPilotData data, ILogger<PilotsController> logger)
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

        // GET: api/Pilots
        [HttpGet]
        public async Task<ActionResult<List<PilotModel>>> Get()
        {
            logger.LogInformation("GET: {apiPath}", $"api/Pilots");

            try
            {
                var output = await data.GetAll();

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - GET: {apiPath}", $"api/Pilots");

                return BadRequest();  
            }
        }

        // GET api/Pilots/5
        [HttpGet("{pilotId}")]
        public async Task<ActionResult<PilotModel>> Get(int pilotId)
        {
            logger.LogInformation("GET: {apiPath}/{pilotId}", $"api/Pilots", pilotId);

            try
            {
                var output = await data.GetById(pilotId);

                return Ok(output);
            }
            catch (Exception ex)
            {
               logger.LogError(ex, "FAILED - GET: {apiPath}/{pilotId}", $"api/Pilots", pilotId);

               return BadRequest();
            }
        }

        // POST api/Pilots
        [HttpPost]
        public async Task<ActionResult<PilotModel>> Post([FromBody] PilotModel pilot)
        {
            logger.LogInformation("POST: {apiPath}", $"api/Pilots");

            try
            {
                var output = await data.Create(pilot.FirstName, pilot.LastName, pilot.CallSign);

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - POST: {apiPath}", $"api/Pilots");

                return BadRequest();
            }
        }

        // PUT api/Pilots/5
        [HttpPut("{pilotId}")]
        public async Task<IActionResult> Put(int pilotId, [FromBody] PilotModel pilot)
        {
            logger.LogInformation("PUT: {apiPath}/{pilotId}", $"api/Pilots", pilotId);

            try
            {
                await data.UpdateInformation(pilotId, pilot.FirstName, pilot.LastName, pilot.CallSign);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PUT: {apiPath}/{pilotId}", $"api/Pilots", pilotId);

                return BadRequest();
            }
        }

        // PUT api/Pilots/5/Competency
        [HttpPut("{pilotId}/Competency")]
        public async Task<IActionResult> Put(int pilotId, int competency)
        {
            logger.LogInformation("PUT: {apiPath}/{pilotId}/Competency", $"api/Pilots", pilotId);

            try
            {
                await data.UpdateCompetency(pilotId, competency);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PUT: {apiPath}/{pilotId}/Competency", $"api/Pilots", pilotId);

                return BadRequest();
            }
        }

        // PUT api/Pilots/5/Sorties
        [HttpPut("{pilotId}/Sorties")]
        public async Task<IActionResult> Put(int pilotId, int sortieCount, DateTime lastSortie )
        {
            logger.LogInformation("PUT: {apiPath}/{pilotId}/Sorties", $"api/Pilots", pilotId);

            try
            {
                await data.UpdateSorties(pilotId, sortieCount, lastSortie);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PUT: {apiPath}/{pilotId}/Sorties", $"api/Pilots", pilotId);

                return BadRequest();
            }
        }

        // DELETE api/Pilots/5
        [HttpDelete("{pilotId}")]
        public async Task<IActionResult> Delete(int pilotId)
        {
            logger.LogInformation("DELETE: {apiPath}/{pilotId}", $"api/Pilots", pilotId);

            try
            {
                await data.Delete(pilotId);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - DELETE: {apiPath}/{pilotId}", $"api/Pilots", pilotId);

                return BadRequest();
            }
        }
    }
}
