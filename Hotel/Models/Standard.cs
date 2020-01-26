using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Standard
    {
        public class Example : IExamplesProvider<Standard>
        {
            public Standard GetExamples()
            {
                return new Standard()
                {
                    StandardPokoju = 5,
                    CenaStandardu = 350.00F
                };

            }
        }

        public class Create
        {
            public int StandardPokoju { get; set; }
            public float CenaStandardu { get; set; }

            public class Example : IExamplesProvider<Create>
            {
                public Create GetExamples()
                {
                    return new Create()
                    {
                        StandardPokoju = 5,
                        CenaStandardu = 350.00F
                    };

                }
            }
        }

        [Key]
        public int StandardPokoju { get; set; }
        public float CenaStandardu { get; set; }
    }
}
