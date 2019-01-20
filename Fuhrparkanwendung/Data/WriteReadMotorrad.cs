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
    }
}
