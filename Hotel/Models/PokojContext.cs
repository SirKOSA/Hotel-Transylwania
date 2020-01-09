using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel;

namespace Hotel.Models
{
    public class PokojContext : DbContext
    {
        public PokojContext(DbContextOptions<PokojContext> options) : base(options)
        {

        }
        public DbSet<Hotel.Pokoj> Pokoj { get; set; }
    }
}
