using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private readonly ILogger<WeatherForecastController> _logger;

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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            //players = new List<Player>();
            //players.Add(new Player
            //{
            //    UserName = "Hansemand",
            //    FirstName = "Hans",
            //    LastName = "Jensen",
            //    Id = 10,
            //});
            //players.Add(new Player
            //{
            //    UserName = "Jensemand",
            //    FirstName = "Jens",
            //    LastName = "Hansen",
            //    Id = 20,
            //});
        }

        [HttpGet("test")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("test/hejsa")]
        public List<AnotherForecast> GetAnother()
        {
            return Enumerable.Range(1, 5).Select(index => new AnotherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

        [HttpPost("test")]
        public string Eccho(string fname, string lname)
        {
            return fname + " " + lname;
        }

        [HttpPost("players")]
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

        [HttpGet("players/{id}")]
        public ActionResult<Player> GetPlayer(int id)
        {
            Player player = players.Find(p => p.Id == id);
            if (player == null)
            {
                return NotFound("Player with id " + id + " not found!");
            }
            return player;
        }
    }
}