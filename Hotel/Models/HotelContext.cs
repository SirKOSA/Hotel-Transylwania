using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Models
{
    // Kontekst wszystkich tabel stanowiących część systemu zarządzania siecią hoteli
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) {}

        public DbSet<Hotel.Rezerwacja> Rezerwacja { get; set; }
        public DbSet<Hotel.Klient> Klient { get; set; }
        public DbSet<Hotel.Pokoj> Pokoj { get; set; }
        public DbSet<Hotel.Models.Standard> Standard { get; set; }
    }
}
