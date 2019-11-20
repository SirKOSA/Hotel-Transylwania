using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Hotel_transylwania
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("Klienci.json");
            var result = JsonConvert.DeserializeObject<Klienci>(json);
            Console.WriteLine("--Klienci--");
            foreach (Klient k in result.Klient)
            {
                Console.WriteLine(k.Id_Klient + "   " + k.Imie + "  " + k.Nazwisko);
            }

            var json2 = File.ReadAllText("Pokoje.json");
            var result2 = JsonConvert.DeserializeObject<Pokoje>(json2);
            Console.WriteLine("--Pokoje--");
            foreach (Pokoj k in result2.Pokoj)
            {
                Console.WriteLine("Nr pokoju: " + k.Nr_Pokoju + "   wolny: " + k.Wolny);
            }

            var json3 = File.ReadAllText("Rezerwacje.json");
            var result3 = JsonConvert.DeserializeObject<Rezerwacje>(json3);
            Console.WriteLine("--Rezerwacje--");
            foreach (Rezerwacja k in result3.Rezerwacja)
            {
                Console.WriteLine(k.Id_Rezerwacji + "   Nr pokoju: " + k.Pokoj.Nr_Pokoju + "  Klient: " + k.Klient.Imie + " " + k.Klient.Nazwisko);
                Console.WriteLine("Start: " + k.Data_Rozpoczecia_Rezerwacji.Dzien + '/' + k.Data_Rozpoczecia_Rezerwacji.Miesiac + '/' + k.Data_Rozpoczecia_Rezerwacji.Rok + "  Koniec: " + k.Data_Zakonczenia_Rezerwacji.Dzien + '/' + k.Data_Zakonczenia_Rezerwacji.Miesiac + '/' + k.Data_Zakonczenia_Rezerwacji.Rok);
            }
            Console.Read();
        }
    }
}
