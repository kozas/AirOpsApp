using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;

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
        public IActionResult Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/Aircraft/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        //// PUT api/Aircraft/5/update-status
        //[HttpPut("{id}/update-status")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
            //throw new NotImplementedException();
        //}

        // DELETE api/Aircraft/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
