using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;
using AirOpsLibrary.Enums;

namespace AirOpsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        // GET: api/Aircraft
        [HttpGet]
        public ActionResult<IEnumerable<AircraftModel>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/Aircraft/5
        [HttpGet("{id}")]
        public ActionResult<AircraftModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/Aircraft
        [HttpPost]
        public IActionResult Post([FromBody] AircraftModel aircraft)
        {
            throw new NotImplementedException();
        }

        //// PUT api/Aircraft/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //    throw new NotImplementedException();
        //}

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
