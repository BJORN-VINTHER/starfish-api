using Persistense;
using Persistense.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public interface IPlayerManager
    {
        public Player CreatePlayer(string userName, string firstName, string lastName);
        public Player? GetPlayer(int id);
        public Player? UpdatePlayer(int id, Player player);
        public Player? UpdatePlayer(int id, string userName, string firstName, string lastName);
        public Player? DeletePlayer(int id);
        public List<Player> GetPlayers();
    }

    public class PlayerManager : IPlayerManager
    {
        // ----------------------------------------------------------------------------------------------------
        // Private fields / properties
        // ----------------------------------------------------------------------------------------------------
        private readonly ApiContext apiContext;
        private readonly Random random = new Random();
        private readonly string[] colors = { "#FFFFFF" };

        // ----------------------------------------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------------------------------------
        public PlayerManager(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        // ----------------------------------------------------------------------------------------------------
        // Public methods
        // ----------------------------------------------------------------------------------------------------
        public Player CreatePlayer(string userName, string firstName, string lastName)
        {
            Player player = new Player(userName, firstName, lastName, NewColor(), NewId());
            apiContext.Players.Add(player);
            apiContext.SaveChanges();
            return player;
        }

        public Player? GetPlayer(int id)
        {
            return apiContext.Players.SingleOrDefault(p => p.Id == id);
        }

        public List<Player> GetPlayers()
        {
            return apiContext.Players.ToList();
        }

        public Player? UpdatePlayer(int id, Player input)
        {
            Player? player = GetPlayer(id);
            if (player == null)
            {
                return null;
            }
            player.UserName = input.UserName;
            player.FirstName = input.FirstName;
            player.LastName = input.LastName;
            apiContext.SaveChanges();
            return player;
        }

        public Player? UpdatePlayer(int id, string userName, string firstName, string lastName)
        {
            Player? player = GetPlayer(id);
            if (player == null)
            {
                return null;
            }
            player.UserName = userName;
            player.FirstName = firstName;
            player.LastName = lastName;
            apiContext.SaveChanges();
            return player;
        }

        public Player? DeletePlayer(int id)
        {
            Player? player = GetPlayer(id);
            if (player == null)
            {
                return null;
            }
            apiContext.Players.Remove(player);
            apiContext.SaveChanges();
            return player;
        }

        // ----------------------------------------------------------------------------------------------------
        // Private methods
        // ----------------------------------------------------------------------------------------------------
        private int NewId()
        {
            int count = 1;
            int id = Math.Abs(Guid.NewGuid().GetHashCode());
            while (GetPlayer(id) != null)
            {
                if (count++ > apiContext.Players.Count() + 1)
                {
                    throw new Exception("Could not create unique id!");
                }
                id = Math.Abs(Guid.NewGuid().GetHashCode());
            }
            return id;
        }

        private string NewColor()
        {
            return colors[random.Next(colors.Length)];
        }
    }
}
