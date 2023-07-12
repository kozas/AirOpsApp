using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;
using AirOpsLibrary.Enums;
using AirOpsLibrary.DataAccess;
using System.Security.Claims;

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
        [HttpGet("{id}")]
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

        // PUT api/Aircraft/5/loadout
        [HttpPut("{id}/loadout")]
        public IActionResult Put(int id, [FromBody] LoadoutModel loadout)
        {
            throw new NotImplementedException();
        }

        // PUT api/Aircraft/5/location
        [HttpPut("{id}/location")]
        public IActionResult Put(int id, [FromBody] LocationModel location)
        {
            throw new NotImplementedException();
        }

        // PUT api/Aircraft/5/pilot
        [HttpPut("{id}/pilot")]
        public IActionResult Put(int id, [FromBody] PilotModel pilot)
        {
            throw new NotImplementedException();
        }

        // PUT api/Aircraft/5/squadron
        [HttpPut("{id}/squadron")]
        public IActionResult Put(int id, [FromBody] SquadronModel squadron)
        {
            throw new NotImplementedException();
        }

        // PUT api/Aircraft/5/status
        [HttpPut("{id}/status")]
        public IActionResult Put(int id, [FromBody] AircraftStatus status)
        {
            throw new NotImplementedException();
        }

        // DELETE api/Aircraft/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
