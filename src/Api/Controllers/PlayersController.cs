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
        private readonly ApiContext apiContext;

        public PlayersController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        [HttpPost()]
        public PlayerDto CreatePlayer(string uname, string fname, string lname)
        {
            Player player = new Player();
            player.FirstName = fname;
            player.LastName = lname;
            player.UserName = uname;
            player.Id = apiContext.Players.Count() + 1;
            apiContext.Players.Add(player);
            apiContext.SaveChanges();
            return new PlayerDto(player);
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerDto> GetPlayer(int id)
        {
            Player? player = apiContext.Players.SingleOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            return new PlayerDto(player);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, [FromBody]Player player)
        {
            Player? player2update = apiContext.Players.SingleOrDefault(p => p.Id == id);
            if (player2update == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            player2update.FirstName=player.FirstName;
            player2update.LastName=player.LastName;
            player2update.UserName=player.UserName;
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            Player? player = apiContext.Players.SingleOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            apiContext.Players.Remove(player);
            apiContext.SaveChanges();
            return Ok();
        }

        [HttpGet()]
        public ActionResult<List<PlayerDto>> GetAllPlayers()
        {
            return apiContext.Players.Select(p => new PlayerDto(p)).ToList();
        }
    }
}
