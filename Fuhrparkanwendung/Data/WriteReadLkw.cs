using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung.Data
{
    class WriteReadLkw
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

        private void PersistLkwArray(string Path)
        {

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Path, true))
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
            Console.ReadKey();
        }
    }
}
