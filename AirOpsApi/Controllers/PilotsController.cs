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
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PilotModel pilot)
        {
            await data.UpdateInformation(pilot.Id, pilot.FirstName, pilot.LastName, pilot.CallSign);

            return Ok();
        }

        // PUT api/Pilots/5/Competency
        [HttpPut("{id}/Competency")]
        public async Task<IActionResult> Put(int pilotId, int competency)
        {
            await data.UpdateCompetency(pilotId, competency);

            return Ok();
        }

        // PUT api/Pilots/5/Competency
        [HttpPut("{id}/Sorties")]
        public async Task<IActionResult> Put(int id, int sortieCount, DateTime lastSortie )
        {
            await data.UpdateSorties(id, sortieCount, lastSortie);

            return Ok();
        }

        // DELETE api/Pilots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await data.Delete(id);

            return Ok();
        }
    }
}
