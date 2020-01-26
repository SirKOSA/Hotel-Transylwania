using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    // Tabela Klient
    public class Klient
    {

        public class Example : IExamplesProvider<Klient>
        {
            public Klient GetExamples()
            {
                return new Klient()
                {
                    Id_Klient = 1,
                    Imie = "Rafał",
                    Nazwisko = "Borkowski"
                };

            }
        }

        public class Create
        {
            public int Id_Klient { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            
            public class Example : IExamplesProvider<Create>
            {
                public Create GetExamples()
                {
                    return new Create()
                    {
                        Id_Klient = 1,
                        Imie = "Rafał",
                        Nazwisko = "Borkowski"
                    };
                    
                }
            }
        }

        [Key]
        public int Id_Klient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
