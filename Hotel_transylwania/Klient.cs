using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_transylwania
{
    public class Klient
    {
        public Klient(int id_klienta, string imie, string nazwisko)
        {
            Id_Klient = id_klienta;
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public int Id_Klient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
