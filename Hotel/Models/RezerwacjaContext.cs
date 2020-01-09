using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel;

namespace Hotel.Models
{
    public class RezerwacjaContext : DbContext
    {
        public RezerwacjaContext(DbContextOptions<RezerwacjaContext> options):base(options)
        {

        }
        public DbSet<Hotel.Rezerwacja> Rezerwacja { get; set; }
    }
}
