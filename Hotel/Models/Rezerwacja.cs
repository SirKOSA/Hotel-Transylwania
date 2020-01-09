using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    public class Rezerwacja
    {
        /*
        public Rezerwacja(int id_rezerwacji, Pokoj pokoj, Klient klient, Data data_Rozpoczecia_Rezerwacji, Data data_Zakonczenia_Rezerwacji)
        {
            Id_Rezerwacji = id_rezerwacji;
            Pokoj = pokoj;
            Klient = klient;
            Data_Rozpoczecia_Rezerwacji = data_Rozpoczecia_Rezerwacji;
            Data_Zakonczenia_Rezerwacji = data_Zakonczenia_Rezerwacji;
        }
        */
        [Key]
        public int Id_Rezerwacji { get; set; }
        public Pokoj _Pokoj { get; set; }
        public Klient _Klient { get; set; }
        public DateTime Data_Rozpoczecia_Rezerwacji { get; set; }
        public DateTime Data_Zakonczenia_Rezerwacji { get; set; }
    }
}
