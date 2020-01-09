using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel;

namespace Hotel.Models
{
    public class KlientContext : DbContext
    {
        public KlientContext(DbContextOptions<KlientContext> options) : base(options)
        {

        }
        public DbSet<Hotel.Klient> Klient { get; set; }
    }
}
