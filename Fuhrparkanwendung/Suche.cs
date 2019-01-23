using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Data;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung
{
    class Suche
    {
        WriteReadLkw trucks;
        WriteReadPkw cars;
        WriteReadMotorrad bikes;
        WriteReadParkhausParkplatz plaetze;
        public Suche(string path)
        {
            this.cars = new WriteReadPkw(path + "\\" + "cars.csv");
            this.trucks = new WriteReadLkw(path + "\\" + "trucks.csv");
            this.bikes = new WriteReadMotorrad(path + "\\" + "bikes.csv");
            this.plaetze = new WriteReadParkhausParkplatz(path + "\\" + "parkhaus.csv", path + "\\" + "parkplatz.csv");
        }

        private List<String> SucheNach( string Suchstring )
        {
            List<String> Gefunden = new List<String>();
            Gefunden.AddRange(trucks.Finde(Suchstring));
            Gefunden.AddRange(cars.Finde(Suchstring));
            Gefunden.AddRange(bikes.Finde(Suchstring));

            return Gefunden;
        }  

        public void Finde(string Suche)
        {
            List<String> Suchergebnisse = SucheNach(Suche);

            if (Suchergebnisse.Count() >= 1)
            {
                foreach (string Ergebnis in Suchergebnisse)
                {
                    Console.WriteLine(Ergebnis);
                }
            }
            else
            {
                Console.WriteLine("Leider nichts Gefunden");
            }

        }

        public void ShowSearchDialog()
        {
            Console.WriteLine("Suche:");
            Finde(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
