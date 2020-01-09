using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }
        public DbSet<Hotel.Rezerwacja> Rezerwacja { get; set; }
        public DbSet<Hotel.Klient> Klient { get; set; }
        public DbSet<Hotel.Pokoj> Pokoj { get; set; }

    }
}
