using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_transylwania
{
    public class Pokoj
    {
        public Pokoj(int nr_pokoju, bool wolny)
        {
            Nr_Pokoju = nr_pokoju;
            Wolny = wolny;
        }

        public int Nr_Pokoju { get; set; }
        public bool Wolny { get; set; }
    }
}
