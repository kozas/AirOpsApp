﻿using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;
using AirOpsLibrary.DataAccess;

namespace AirOpsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadronsController : ControllerBase
    {
        private readonly ISquadronData data;

        public SquadronsController(ISquadronData data)
        {
            this.data = data;
        }

        // GET: api/Squadrons
        [HttpGet]
        public async Task<ActionResult<List<SquadronModel>>> Get()
        {
            var output = await data.GetAll();

            return Ok(output);
        }

        // GET api/Squadrons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SquadronModel>> Get(int squadronId)
        {
            var output = await data.GetById(squadronId);

            return Ok(output);
        }

        // POST api/Squadrons
        [HttpPost]
        public async Task<ActionResult<SquadronModel>> Post([FromBody] SquadronModel squadron)
        {
            var output = await data.Create(squadron.Designation, squadron.Nickname, (int) squadron.Role);

            return Ok(output);
        }

        // PUT api/Squadrons/5/
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] SquadronModel squadron)
        {
            await data.Update(
                squadron.Id, 
                squadron.CommandingOfficerId, 
                squadron.ExecutiveOfficerId, 
                squadron.Designation,
                squadron.Nickname,
                squadron.RadioCallSign,
                squadron.Motto,
                (int) squadron.Role);

            return Ok();
        }

        // PUT api/Squadrons/5/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await data.Delete(id);

            return Ok();
        }
    }
}
