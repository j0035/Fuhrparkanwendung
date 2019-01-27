using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung.Data
{
    class WriteReadLkw : WriteRead
    {
        string filePath;
        List<Lkw> AlleLkw = new List<Lkw>();

        public WriteReadLkw(string filePath)
        {
            this.filePath = filePath;
            LoadLkwArray(this.filePath);
        }

        private void LoadLkwArray(string Path)
        {
            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    String ln;

                while ((ln = reader.ReadLine()) != null)
                    {
                        String[] ArrLkw = ln.Split(',');
                        Lkw Lkw = new Lkw(
                            ArrLkw[1],
                            ArrLkw[2],
                            ArrLkw[0],
                            DateTime.Parse(ArrLkw[3]),
                            Convert.ToDouble(ArrLkw[4]),
                            ArrLkw[5],
                            Convert.ToInt32(ArrLkw[6]),
                            Convert.ToInt32(ArrLkw[7])
                            );

                        AlleLkw.Add(Lkw);
                    }
                }
            }
        }

        private void PersistLkwArray(string Path)
        {

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Path, false))
            {
                foreach (Lkw Laster in AlleLkw)
                {
                    file.WriteLine(Laster.GetDatenString());
                }
            }
        }

        public void Load()
        {
            LoadLkwArray(filePath);
        }

        public void Save()
        {
            PersistLkwArray(filePath);
        }

        public void Show()
        {
            foreach (Lkw Laster in AlleLkw)
            {
                Console.WriteLine(Laster.GetDatenString());
            }
        }

        private List<String> AskForInput()
        {
            String[] Fragen = {
                "Geben Sie den Hersteller ein",
                "Geben Sie das Modell ein",
                "Geben Sie das Kennzeichen ein",
                "Geben Sie das Datum der Erstzulassung ein (TT.MM.JJJJ)",
                "Geben Sie den Anschaffungspreis ein (in Euro)",
                "Geben Sie den Stellplatz ein (Format: 'Parkhaus/Parkpaltz' oder für eine Zufällig Parkplatz vergabe nur das Parkhaus angeben)",
                "Geben Sie die Anzahl der Achsen ein",
                "Geben Sie die Zuladung ein (in Tonnen)",
            };

            int FahrzeugTyp = 1;

            return Antworten(Fragen, FahrzeugTyp);
        }

        public void AddNewDataSet()
        {
            List<String> newLkw = AskForInput();

            Lkw Lkw = new Lkw(
                        newLkw[0],
                        newLkw[1],
                        newLkw[2],
                        DateTime.Parse(newLkw[3]),
                        Convert.ToDouble(newLkw[4]),
                        newLkw[5],
                        Convert.ToInt32(newLkw[6]),
                        Convert.ToInt32(newLkw[7])
                        );

            AlleLkw.Add(Lkw);
            Save();
        }

        public double Steuerschuld()
        {
            double Gesamtschuld = 0;
            foreach (Lkw Wagen in AlleLkw)
            {
                Gesamtschuld += Wagen.Steuerschuld();
            }

            return Gesamtschuld;
        }

        public List<String> Finde(string Suchquery)
        {
            List<String> Wlist = new List<String>();
            foreach (Lkw Wagen in AlleLkw)
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
            foreach (Lkw Wagen in AlleLkw)
            {
                String[] Splitter = Wagen.GetDatenString().Split(',');
                if (Splitter.Contains(Suchquery))
                {
                    Wagen.Stellplatz = null;
                }
            }
        }
    }
}
