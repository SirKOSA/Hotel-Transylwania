using Swashbuckle.AspNetCore.Filters;
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

        public class Example : IExamplesProvider<Pokoj>
        {
            public Pokoj GetExamples()
            {
                return new Pokoj()
                {
                    Nr_Pokoju = 1,
                    Wolny = false,
                    Liczba_miejsc = 2,
                    Standard_pokoju = 5
                };

            }
        }

        public class Create
        {
            public int Nr_Pokoju { get; set; }
            public bool Wolny { get; set; }
            public int Liczba_miejsc { get; set; }
            public int Standard_pokoju { get; set; }

            public class Example : IExamplesProvider<Create>
            {
                public Create GetExamples()
                {
                    return new Create()
                    {
                        Nr_Pokoju = 1,
                        Wolny = false,
                        Liczba_miejsc = 2,
                        Standard_pokoju = 5
                    };

                }
            }
        }

        [Key]
        public int Nr_Pokoju { get; set; }
        public bool Wolny { get; set; }
        public int Liczba_miejsc { get; set; }
        public int Standard_pokoju { get; set; }
    }
}
