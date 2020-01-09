using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    public class Klient
    {
        /*
        public Klient(int id_klienta, string imie, string nazwisko)
        {
            Id_Klient = id_klienta;
            Imie = imie;
            Nazwisko = nazwisko;
        }
        */
        [Key]
        public int Id_Klient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
