using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuhrparkanwendung.Data;
using Fuhrparkanwendung.Functional;
using System.Reflection;

namespace Fuhrparkanwendung
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Public\FuhrparkanwendungFia72";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            };
            WriteReadPkw cars = new WriteReadPkw(path + "\\" + "cars.csv");
            WriteReadLkw trucks = new WriteReadLkw(path + "\\" + "trucks.csv");
            WriteReadMotorrad bikes = new WriteReadMotorrad(path + "\\" + "bikes.csv");
            WriteReadParkhausParkplatz plaetze = new WriteReadParkhausParkplatz(path + "\\" + "parkhaus.csv", path + "\\" + "parkplatz.csv");
            Suche Search = new Suche(path);
            Action carsShow = () => cars.Show();
            Action carAdd = () => cars.AddNewDataSet();
            Action truckAdd = () => trucks.AddNewDataSet();
            Action truckShow = () => trucks.Show();
            Action bikeAdd = () => bikes.AddNewDataSet();
            Action bikeShow = () => bikes.Show();
            Action find = () => Search.ShowSearchDialog();

            MenueItem PkwShow = new MenueItem("Alle Autos", carsShow);
            MenueItem PkwAdd = new MenueItem("Auto Hinzufügen", carAdd);
            MenueItem LkwAdd = new MenueItem("Lkw Hinzufügen", truckAdd);
            MenueItem LkwShow = new MenueItem("Alle Lkw", truckShow);
            MenueItem BikeAdd = new MenueItem("Motorrad Hinzufügen", bikeAdd);
            MenueItem BikeShow = new MenueItem("Alle Bikes", bikeShow);
            MenueItem SearchAction = new MenueItem("Suche", find);

            Action Gesamt = () => Console.WriteLine(cars.Steuerschuld() + trucks.Steuerschuld() + bikes.Steuerschuld());

            MenueItem SteuerschuldGesamt = new MenueItem("Gesamte Steuerschuld", Gesamt);




            List<MenueItem> Mlist = new List<MenueItem>();

            Mlist.Add(PkwAdd);
            Mlist.Add(PkwShow);
            Mlist.Add(LkwAdd);
            Mlist.Add(LkwShow);
            Mlist.Add(BikeAdd);
            Mlist.Add(BikeShow);
            Mlist.Add(SteuerschuldGesamt);
            Mlist.Add(SearchAction);

            Menue menue = new Menue(Mlist);
            menue.runMenue();

        }
    }
}
