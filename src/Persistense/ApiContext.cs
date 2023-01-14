using Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistense
{
    public class ApiContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DataBaseName");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
