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

        public PilotsController(IPilotData data)
        {
            this.data = data;
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
            var output = await data.GetAll();

            return Ok(output);
        }

        // GET api/Pilots/5
        [HttpGet("{pilotId}")]
        public async Task<ActionResult<PilotModel>> Get(int pilotId)
        {
            var output = await data.GetById(pilotId);

            return Ok(output);
        }

        // POST api/Pilots
        [HttpPost]
        public async Task<ActionResult<PilotModel>> Post([FromBody] PilotModel pilot)
        {
            var output = await data.Create(pilot.FirstName, pilot.LastName, pilot.CallSign);

            return Ok(output);
        }

        // PUT api/Pilots/5
        [HttpPut("{pilotId}")]
        public async Task<IActionResult> Put(int pilotId, [FromBody] PilotModel pilot)
        {
            await data.UpdateInformation(pilotId, pilot.FirstName, pilot.LastName, pilot.CallSign);

            return Ok();
        }

        // PUT api/Pilots/5/Competency
        [HttpPut("{pilotId}/Competency")]
        public async Task<IActionResult> Put(int pilotId, int competency)
        {
            await data.UpdateCompetency(pilotId, competency);

            return Ok();
        }

        // PUT api/Pilots/5/Sorties
        [HttpPut("{pilotId}/Sorties")]
        public async Task<IActionResult> Put(int pilotId, int sortieCount, DateTime lastSortie )
        {
            await data.UpdateSorties(pilotId, sortieCount, lastSortie);

            return Ok();
        }

        // DELETE api/Pilots/5
        [HttpDelete("{pilotId}")]
        public async Task<IActionResult> Delete(int pilotId)
        {
            await data.Delete(pilotId);

            return Ok();
        }
    }
}
