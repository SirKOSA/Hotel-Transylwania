using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_transylwania
{
    public class Rezerwacja
    {
        public Rezerwacja(int id_rezerwacji, Pokoj pokoj, Klient klient, Data data_Rozpoczecia_Rezerwacji, Data data_Zakonczenia_Rezerwacji)
        {
            Id_Rezerwacji = id_rezerwacji;
            Pokoj = pokoj;
            Klient = klient;
            Data_Rozpoczecia_Rezerwacji = data_Rozpoczecia_Rezerwacji;
            Data_Zakonczenia_Rezerwacji = data_Zakonczenia_Rezerwacji;
        }

        public int Id_Rezerwacji { get; set; }
        public Pokoj Pokoj { get; set; }
        public Klient Klient { get; set; }
        public Data Data_Rozpoczecia_Rezerwacji { get; set; }
        public Data Data_Zakonczenia_Rezerwacji { get; set; }
    }
}
