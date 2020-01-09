using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    public class Rezerwacja
    {
        [Key]
        public int Id_Rezerwacji { get; set; }
        public Pokoj _Pokoj { get; set; }
        public Klient _Klient { get; set; }
        public DateTime Data_Rozpoczecia_Rezerwacji { get; set; }
        public DateTime Data_Zakonczenia_Rezerwacji { get; set; }
    }
}
