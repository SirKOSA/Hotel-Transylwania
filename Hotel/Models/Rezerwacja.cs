using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    // Tabela Rezerwacja
    public class Rezerwacja
    {
        [Key]
        public int Id_Rezerwacji { get; set; }
        public int id_klient { get; set; }
        public int nr_pokoju { get; set; }
        public DateTime Data_Rozpoczecia_Rezerwacji { get; set; }
        public DateTime Data_Zakonczenia_Rezerwacji { get; set; }
    }
}
