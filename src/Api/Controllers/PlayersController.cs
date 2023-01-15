using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistense;
using System.Numerics;
using System.Reflection.Emit;

namespace Api.Controllers
{
    [Route("players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerManager playerManager;

        public PlayersController(IPlayerManager playerManager)
        {
            this.playerManager = playerManager;
        }

        [HttpPost()]
        public PlayerDto CreatePlayer(string uname, string fname, string lname)
        {
            return new PlayerDto(playerManager.CreatePlayer(fname, lname, uname));
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerDto> GetPlayer(int id)
        {
            Player? player = playerManager.GetPlayer(id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            return new PlayerDto(player);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, [FromBody] Player input)
        {
            Player? player = playerManager.UpdatePlayer(id, input);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            Player? player = playerManager.DeletePlayer(id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            return Ok();
        }

        [HttpGet()]
        public ActionResult<List<PlayerDto>> GetPlayers()
        {

            //return playerManager.GetPlayers().Select(p => new PlayerDto(p)).ToList();
            return playerManager.GetPlayers().ConvertAll(p => new PlayerDto(p));
        }
    }
}
