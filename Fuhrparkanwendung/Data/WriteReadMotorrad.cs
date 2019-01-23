using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Functional;


namespace Fuhrparkanwendung.Data
{
    class WriteReadMotorrad
    {
        string filePath;
        List<Motorrad> AlleBikes = new List<Motorrad>();

        public WriteReadMotorrad(string filePath)
        {
            this.filePath = filePath;
            LoadMotorradList(this.filePath);
        }

        private void LoadMotorradList(string Path)
        {
            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    String ln;

                    while ((ln = reader.ReadLine()) != null)
                    {
                        String[] ArrMotorrad = ln.Split(',');
                        Motorrad bike = new Motorrad(
                            ArrMotorrad[1],
                            ArrMotorrad[2],
                            ArrMotorrad[0],
                            DateTime.Parse(ArrMotorrad[3]),
                            Convert.ToDouble(ArrMotorrad[4]),
                            ArrMotorrad[5],
                            Convert.ToInt32(ArrMotorrad[6])
                            );

                        AlleBikes.Add(bike);
                    }
                }
            }
            
        }

        private void PersistMotorradList(string Path)
        {

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Path, true))
            {
                foreach (Motorrad Bike in AlleBikes)
                {
                    file.WriteLine(Bike.GetDatenString());
                }
            }
        }

        public void Load()
        {
            LoadMotorradList(filePath);
        }

        public void Save()
        {
            PersistMotorradList(filePath);
        }

        public void Show()
        {
            foreach ( Motorrad Bike in AlleBikes)
            {
                Console.WriteLine(Bike.GetDatenString());
            }
            Console.ReadKey();
        }

        private List<String> AskForInput()
        {
            String[] Fragen = {
                "Geben Sie den Hersteller ein",
                "Geben Sie das Modell ein",
                "Geben Sie das Kennzeichen ein",
                "Geben Sie das Datum der Erstzulassung ein",
                "Geben Sie den Anschaffungspreis ein",
                "Geben Sie den Stellplatz ein (Lassen Sie dieses Feld Leer um einen leeren Platz zugewiesen zu bekommen)",
                "Geben Sie den Hubraum ein"
            };

            List<String> Parameter = new List<String>();

            foreach (String Frage in Fragen)
            {
                Console.WriteLine(Frage);
                Parameter.Add(Console.ReadLine());
                Console.Clear();

            }

            return Parameter;
        }

        public void AddNewDataSet()
        {
            List<String> newBike = AskForInput();

            Motorrad Bike = new Motorrad(
                        newBike[0],
                        newBike[1],
                        newBike[2],
                        DateTime.Parse(newBike[3]),
                        Convert.ToDouble(newBike[4]),
                        newBike[5],
                        Convert.ToInt32(newBike[6])
                        );

            AlleBikes.Add(Bike);
        }

        public double Steuerschuld()
        {
            double Gesamtschuld = 0;
            foreach (Motorrad Wagen in AlleBikes)
            {
                Gesamtschuld += Wagen.Steuerschuld();
            }

            return Gesamtschuld;
        }

        public List<String> Finde(string Suchquery)
        {
            List<String> Wlist = new List<String>();
            foreach (Motorrad Wagen in AlleBikes)
            {
                
                if (Wagen.GetDatenString().Contains(Suchquery))
                {
                    Wlist.Add( Wagen.GetDatenString() );
                }
            }

            return Wlist;
        }

       
    }
}
