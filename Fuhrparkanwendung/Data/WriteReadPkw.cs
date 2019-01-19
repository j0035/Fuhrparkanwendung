using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung.Data
{
    class WriteReadPkw
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
                        Convert.ToDateTime(ArrPkw[3]), 
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

        private void PersistPkwArray(string Path)
        {
            String onePkw;
            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Path, true))
            {
                foreach (Pkw Wagen in AllePkw)
                {
                    onePkw = Wagen.Kennzeichen + ',' + Wagen.Hersteller + ',' + Wagen.Modell + ',' + Convert.ToString(Wagen.Erstzulassung) + ',' + Convert.ToString(Wagen.Anschaffungspreis) + ',' + Wagen.Stellplatz + ',' + Convert.ToString(Wagen.Hubraum) + ',' + Convert.ToString(Wagen.Leistung) + ',' + Convert.ToString(Wagen.Schadstoffklasse);
                    file.WriteLine(onePkw);
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
            foreach (Pkw wagen in AllePkw)
            { 
                Console.WriteLine(wagen.Kennzeichen + "\t" + wagen.Hersteller + "\t\t" + wagen.Modell + "\t" + wagen.Stellplatz);
            }
            Console.ReadKey();
        }
    }
}
