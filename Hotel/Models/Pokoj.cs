using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    // Tabela Pokoj
    public class Pokoj
    {
        [Key]
        public int Nr_Pokoju { get; set; }
        public bool Wolny { get; set; }
        public int Liczba_miejsc { get; set; }
        public int Standard_pokoju { get; set; }
    }
}
