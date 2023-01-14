using Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PlayerDto
    {
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        //public int Id { get; set; }

        public PlayerDto()
        {

        }

        public PlayerDto(Player player)
        {
            FirstName = player.FirstName;
            LastName = player.LastName;
            UserName = player.UserName;
            //Id = player.Id;
        }
    }
}
