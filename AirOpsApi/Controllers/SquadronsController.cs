using Microsoft.AspNetCore.Mvc;
using AirOpsLibrary.Models;
using AirOpsLibrary.DataAccess;

namespace AirOpsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadronsController : ControllerBase
    {
        private readonly ISquadronData data;
        private readonly ILogger<SquadronsController> logger;

        public SquadronsController(ISquadronData data, ILogger<SquadronsController> logger)
        {
            this.data = data;
            this.logger = logger;
        }

        // GET: api/Squadrons
        [HttpGet]
        public async Task<ActionResult<List<SquadronModel>>> Get()
        {
            logger.LogInformation("GET: {apiPath}", $"api/Squadrons");

            try
            {
                var output = await data.GetAll();

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - GET: {apiPath}", $"api/Squadrons");

                return BadRequest();
            }
        }

        // GET api/Squadrons/5
        [HttpGet("{squadronId}")]
        public async Task<ActionResult<SquadronModel>> Get(int squadronId)
        {
            logger.LogInformation("GET: {apiPath}/{squadronId}", $"api/Squadrons", squadronId);

            try
            {
                var output = await data.GetById(squadronId);

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - GET: {apiPath}/{squadronId}", $"api/Squadrons", squadronId);

                return BadRequest();
            }
        }

        // POST api/Squadrons
        [HttpPost]
        public async Task<ActionResult<SquadronModel>> Post([FromBody] SquadronModel squadron)
        {
            logger.LogInformation("POST: {apiPath} --- {squadron}", $"api/Squadrons", squadron);

            try
            {
                var output = await data.Create(squadron.Designation, squadron.Nickname, (int)squadron.Role);

                return Ok(output);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - POST: {apiPath} --- {squadron}", $"api/Squadrons", squadron);

                return BadRequest();
            }
        }

        // PUT api/Squadrons/5/
        [HttpPut("{squadronId}")]
        public async Task<IActionResult> Put(int squadronId, [FromBody] SquadronModel squadron)
        {
            logger.LogInformation("PUT: {apiPath}/{squadronId}", $"api/Squadrons", squadronId);

            try
            {
                await data.Update(
                        squadronId,
                        squadron.CommandingOfficerId,
                        squadron.ExecutiveOfficerId,
                        squadron.Designation,
                        squadron.Nickname,
                        squadron.RadioCallSign,
                        squadron.Motto,
                        (int)squadron.Role);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - PUT: {apiPath}/{squadronId}", $"api/Squadrons", squadronId);

                return BadRequest();
            }
        }

        // PUT api/Squadrons/5/
        [HttpDelete("{squadronId}")]
        public async Task<IActionResult> Delete(int squadronId)
        {
            logger.LogInformation("DELETE: {apiPath}", $"api/Squadrons");

            try
            {
                await data.Delete(squadronId);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FAILED - DELETE: {apiPath}", $"api/Squadrons");

                return BadRequest();
            }
        }
    }
}
