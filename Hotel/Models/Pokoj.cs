using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    public class Pokoj
    {
        /*
        public Pokoj(int nr_pokoju, bool wolny)
        {
            Nr_Pokoju = nr_pokoju;
            Wolny = wolny;
        }
        */
        [Key]
        public int Nr_Pokoju { get; set; }
        public bool Wolny { get; set; }
    }
}
