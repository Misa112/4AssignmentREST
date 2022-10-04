using _4AssignmentREST.Managers;
using _4AssignmentREST.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4AssignmentREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly FootballPlayersManager manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]        
        public ActionResult<IEnumerable<FootballPlayer>> GetAll()
        {
            IEnumerable<FootballPlayer> playerList = manager.GetAll();
            if (playerList.Count() == 0)
            {
                return NotFound();
            }
            return Ok(playerList);
        }

        // GET api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer? player = manager.GetById(id);
            if (player == null) return NotFound("No such player, id: " + id);
            return Ok(player);
        }

        // POST api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            try
            {
                FootballPlayer createdPlayer = manager.Add(value);
                return Created("api/footballPlayers/", createdPlayer);
            }
            catch (Exception ex)
            when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            FootballPlayer? updatedPlayer = manager.Update(id, value);
            if (updatedPlayer == null)
            {
                return NoContent();
            }
            return Ok(updatedPlayer);
        }

        // DELETE api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer? deletedPlayer = manager.Delete(id);
            if (deletedPlayer == null)
            {
                return NoContent();
            }
            return Ok(deletedPlayer);
        }
    }
}
