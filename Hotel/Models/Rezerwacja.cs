using Swashbuckle.AspNetCore.Filters;
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
        
        public class Example : IExamplesProvider<Rezerwacja>
        {
            public Rezerwacja GetExamples()
            {
                return new Rezerwacja()
                {
                    Id_Rezerwacji = 1,
                    id_klient = 1,
                    nr_pokoju = 2,
                    Cena = 350.00F
                };

            }
        }

        public class Create
        {
            public int Id_Rezerwacji { get; set; }
            public int id_klient { get; set; }
            public int nr_pokoju { get; set; }
            public DateTime Data_Rozpoczecia_Rezerwacji { get; set; }
            public DateTime Data_Zakonczenia_Rezerwacji { get; set; }
            public double Cena { get; set; }

            public class Example : IExamplesProvider<Create>
            {
                public Create GetExamples()
                {
                    return new Create()
                    {
                        Id_Rezerwacji = 1,
                        id_klient = 1,
                        nr_pokoju = 2,
                        Cena = 350.00F
                    };

                }
            }
        }
        
        [Key]
        public int Id_Rezerwacji { get; set; }
        public int id_klient { get; set; }
        public int nr_pokoju { get; set; }
        public DateTime Data_Rozpoczecia_Rezerwacji { get; set; }
        public DateTime Data_Zakonczenia_Rezerwacji { get; set; }
        public double Cena { get; set;}
    }
}
