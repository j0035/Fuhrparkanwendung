using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung.Data
{
    class WriteReadPkw : WriteRead
    {
        string filePath;
        List<Pkw> AllePkw = new List<Pkw>();

        public WriteReadPkw(string filePath)
        {
            this.filePath = filePath;
            LoadPkwArray(this.filePath);
        }

        private void LoadPkwArray(string Path)
        {

            if (File.Exists(Path)) {
                using (StreamReader reader = new StreamReader(Path))
                {
                    String ln;

                    while ((ln = reader.ReadLine()) != null)
                    {
                        String[] ArrPkw = ln.Split(',');
                        Pkw pkw = new Pkw(
                            ArrPkw[1],
                            ArrPkw[2],
                            ArrPkw[0],
                            DateTime.Parse(ArrPkw[3]),
                            Convert.ToDouble(ArrPkw[4]),
                            ArrPkw[5],
                            Convert.ToInt32(ArrPkw[6]),
                            Convert.ToInt32(ArrPkw[7]),
                            Convert.ToInt32(ArrPkw[8])
                            );

                        AllePkw.Add(pkw);
                    }
                }
            }

        }

        private void PersistPkwArray(string Path)
        {
            
            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Path, false))
            {
                foreach (Pkw Wagen in AllePkw)
                {
                    file.WriteLine(Wagen.GetDatenString());
                }
            }
        }

        public void Load()
        {
            LoadPkwArray(filePath);
        }

        public void Save()
        {
            PersistPkwArray(filePath);
        }

        public void Show()
        {
            foreach (Pkw Wagen in AllePkw)
            {
                Console.WriteLine(Wagen.GetDatenString());
            }
            
        }

        private List<String> AskForInput()
        {
            String[] Fragen = {
                "Geben Sie den Hersteller ein",
                "Geben Sie das Modell ein",
                "Geben Sie das Kennzeichen ein",
                "Geben Sie das Datum der Erstzulassung ein",
                "Geben Sie den Anschaffungspreis ein",
                "Geben Sie den Stellplatz ein (Format: 'Parkhaus/Parkpaltz' oder für eine Zufällig Parkplatz vergabe nur das Parkhaus angeben)",
                "Geben Sie den Hubraum ein",
                "Geben Sie die Leistung ein",
                "Geben Sie die Schadstoffklasse ein"
            };



            int FahrzeugTyp = 0;

            return Antworten(Fragen, FahrzeugTyp);
        }

        public void AddNewDataSet()
        {
            List<String> newPkw = AskForInput();

            Pkw Pkw = new Pkw(
                        newPkw[0],
                        newPkw[1],
                        newPkw[2],
                        DateTime.Parse(newPkw[3]),
                        Convert.ToDouble(newPkw[4]),
                        newPkw[5],
                        Convert.ToInt32(newPkw[6]),
                        Convert.ToInt32(newPkw[7]),
                        Convert.ToInt32(newPkw[8])
                        );

            AllePkw.Add(Pkw);
            Save();
        }

        public double Steuerschuld()
        {
            double Gesamtschuld = 0;
            foreach (Pkw Wagen in AllePkw)
            {
                Gesamtschuld += Wagen.Steuerschuld();
            }

            return Gesamtschuld;
        }

        public List<String> Finde( string Suchquery)
        {
            List<String> Wlist = new List<String>();
            foreach (Pkw Wagen in AllePkw)
            {
                if (Wagen.GetDatenString().Contains(Suchquery))
                {
                    Wlist.Add(Wagen.GetDatenString());
                }
            }
            return Wlist;
        }

        public void Ausbuchen(string Suchquery)
        {
            foreach (Pkw Wagen in AllePkw)
            {
                String[] Splitter = Wagen.GetDatenString().Split(',');
                if (Splitter.Contains(Suchquery))
                {
                    Wagen.Stellplatz = null;
                }
            }
        }

        //-----------------------------------------


    }
}
