using Api;
using Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public interface IPlayerManager
    {
        public Player CreatePlayer(string firstName, string lastName, string userName);
        public Player? GetPlayer(int id);
        public Player? UpdatePlayer(int id, Player player);
        public Player? DeletePlayer(int id);
        public List<Player> GetPlayers();
    }

    public class PlayerManager : IPlayerManager
    {
        private readonly ApiContext apiContext;

        public PlayerManager(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        private int CreateId()
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

        public Player CreatePlayer(string firstName, string lastName, string userName)
        {
            Player player = new Player();
            player.FirstName = firstName;
            player.LastName = lastName;
            player.UserName = userName;
            player.Id = CreateId();
            apiContext.Players.Add(player);
            apiContext.SaveChanges();
            return player;
        }

        public Player? GetPlayer(int id)
        {
            return apiContext.Players.SingleOrDefault(p => p.Id == id);
        }

        public Player? UpdatePlayer(int id, Player input)
        {
            Player? player = GetPlayer(id);
            if (player == null)
            {
                return null;
            }
            player.FirstName = input.FirstName;
            player.LastName = input.LastName;
            player.UserName = input.UserName;
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

        public List<Player> GetPlayers()
        {
            return apiContext.Players.ToList();
        }
    }
}
