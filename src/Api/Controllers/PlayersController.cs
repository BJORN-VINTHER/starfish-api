using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistense;
using Persistense.Entities;
using System.Numerics;
using System.Reflection.Emit;

namespace Api.Controllers
{
    [Route("players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        // ----------------------------------------------------------------------------------------------------
        // Private fields / properties
        // ----------------------------------------------------------------------------------------------------
        private readonly IPlayerManager playerManager;

        // ----------------------------------------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------------------------------------
        public PlayersController(IPlayerManager playerManager)
        {
            this.playerManager = playerManager;
        }

        // ----------------------------------------------------------------------------------------------------
        // Public methods
        // ----------------------------------------------------------------------------------------------------
        [HttpPost()]
        public PlayerDto CreatePlayer(string userName, string firstName, string lastName)
        {
            return new Application.PlayerDto(playerManager.CreatePlayer(userName, firstName, lastName));
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

        [HttpGet()]
        public ActionResult<List<PlayerDto>> GetPlayers()
        {

            //return playerManager.GetPlayers().Select(p => new PlayerDto(p)).ToList();
            return playerManager.GetPlayers().ConvertAll(p => new PlayerDto(p));
        }

        //[HttpPut("{id}")]
        //public ActionResult UpdatePlayer(int id, [FromBody] Player input)
        //{
        //    Player? player = playerManager.UpdatePlayer(id, input);
        //    if (player == null)
        //    {
        //        return NotFound("Player with id " + id + " not found!");
        //    }
        //    return Ok();
        //}

        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, string userName, string firstName, string lastName)
        {
            Player? player = playerManager.UpdatePlayer(id, userName, firstName, lastName);
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
    }
}
