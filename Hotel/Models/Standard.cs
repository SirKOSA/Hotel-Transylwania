using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Standard
    {   
        [Key]
        public int StandardPokoju { get; set; }
        public float CenaStandardu { get; set; }
    }
}
