using Persistense.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PlayerDto
    {
        // ----------------------------------------------------------------------------------------------------
        // Public fields / properties
        // ----------------------------------------------------------------------------------------------------
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Id { get; set; }

        // ----------------------------------------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------------------------------------
        public PlayerDto() { }

        public PlayerDto(Player player)
        {
            UserName = player.UserName;
            FirstName = player.FirstName;
            LastName = player.LastName;
            Color = player.Color;
            Id = player.Id;
        }
    }
}
