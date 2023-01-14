using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace Api.Controllers
{
    [Route("players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private static List<Player> players = new List<Player>() {
            new Player
            {
                UserName = "Hansemand",
                FirstName = "Hans",
                LastName = "Jensen",
                Id = 10,
            },
            new Player
            {
                UserName = "Jensemand",
                FirstName = "Jens",
                LastName = "Hansen",
                Id = 20,
            }};

        [HttpPost()]
        public Player CreatePlayer(string uname, string fname, string lname)
        {
            Player player = new Player();
            player.FirstName = fname;
            player.LastName = lname;
            player.UserName = uname;
            player.Id = players.Count + 1;
            players.Add(player);
            return player;
        }

        [HttpGet("{id}")]
        public ActionResult<Player> GetPlayer(int id)
        {
            Player player = players.Find(p => p.Id == id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            return player;
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, [FromBody]Player player)
        {
            Player player2update = players.Find(p => p.Id == id);
            if (player2update == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            player2update.FirstName=player.FirstName;
            player2update.LastName=player.LastName;
            player2update.UserName=player.UserName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            Player player = players.Find(p => p.Id == id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            players.Remove(player);
            return Ok();
        }

        [HttpGet()]
        public ActionResult<List<Player>> GetAllPlayers()
        {
            return players;
        }
    }
}
