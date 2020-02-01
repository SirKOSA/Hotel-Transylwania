using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HotelContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HotelContext>>()))
            {
                // Look for any
                if (context.Standard.Any())
                {
                    return;   // DB has been seeded
                }

                context.Standard.AddRange(
                    new Standard
                    {
                        CenaStandardu = 100.00f
                    },

                    new Standard
                    {
                        CenaStandardu = 300.00f
                    }
                );

                context.Klient.AddRange(
                    new Klient
                    {
                        Imie = "Maciej",
                        Nazwisko = "Kosinski"
                    },

                    new Klient
                    {
                        Imie = "Przemysław",
                        Nazwisko = "Wilczynski"
                    },

                    new Klient
                    {
                        Imie = "Maciej",
                        Nazwisko = "Słaby"
                    },

                    new Klient
                    {
                        Imie = "Jakub",
                        Nazwisko = "Sonta"
                    }
                );

                context.Pokoj.AddRange(
                    new Pokoj
                    {
                        Liczba_miejsc = 1,
                        Standard_pokoju = 1,
                        Wolny = true
                    },

                    new Pokoj
                    {
                        Liczba_miejsc = 3,
                        Standard_pokoju = 1,
                        Wolny = true
                    },

                    new Pokoj
                    {
                        Liczba_miejsc = 1,
                        Standard_pokoju = 2,
                        Wolny = true
                    }
                );

                context.Rezerwacja.AddRange(
                    new Rezerwacja
                    {
                        id_klient = 1,
                        nr_pokoju = 3,
                        Data_Rozpoczecia_Rezerwacji = DateTime.Now,
                        Data_Zakonczenia_Rezerwacji = DateTime.Now.AddDays(1),
                        Cena = 300f

                    },

                    new Rezerwacja
                    {
                        id_klient = 3,
                        nr_pokoju = 1,
                        Data_Rozpoczecia_Rezerwacji = DateTime.Now,
                        Data_Zakonczenia_Rezerwacji = DateTime.Now.AddDays(4),
                        Cena = 400f

                    }
                );

                context.SaveChanges();
            }
        }
    }
}
