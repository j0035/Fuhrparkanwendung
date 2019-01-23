using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung.Data
{
    class WriteReadParkhausParkplatz
    {
        List<Parkplatz> ParkPlatzList = new List<Parkplatz>();
        List<Parkhaus> ParkHausList = new List<Parkhaus>();

        public WriteReadParkhausParkplatz(string filePathParkhaus, string filePathParkplatz)
        {
            LoadParkhausList(filePathParkhaus);
            LoadParkplatzList(filePathParkplatz);

        }

        private void LoadParkplatzList(string filePathParkplatz)
        {
            if (File.Exists(filePathParkplatz))
            {
                using (StreamReader reader = new StreamReader(filePathParkplatz))
                {
                    String ln;

                    while ((ln = reader.ReadLine()) != null)
                    {
                        string[] ParkPlatz = ln.Split(',');
                        Boolean Besetzt = ParkPlatz[2] == "" ? false : true;
                        string Kennzeichen = Besetzt == false ? ParkPlatz[2] : null;
                        Parkplatz Platz = new Parkplatz(ParkPlatz[0], Convert.ToInt16(ParkPlatz[1]), Besetzt, Kennzeichen);
                        this.ParkPlatzList.Add(Platz);

                    }
                }
            }
            
        }

        private void LoadParkhausList(string filePathParkhaus)
        {
            if (File.Exists(filePathParkhaus))
            {
                using (StreamReader reader = new StreamReader(filePathParkhaus))
                {
                    String ln;

                    while ((ln = reader.ReadLine()) != null)
                    {
                        string[] Adresse = ln.Split(',');
                        Parkhaus Haus = new Parkhaus(Adresse[0], Adresse[1], Adresse[2], Adresse[3]);
                        this.ParkHausList.Add(Haus);

                    }
                }
            }
        }

        public string BucheParkplatz(string Kennzeichen, int typ, string Parkhaus, string OnePlatz = "")
        {
            foreach(Parkplatz Platz in ParkPlatzList)
            {

                if (!Platz.Besetzt && Platz.Parkhaus() == Parkhaus && Platz.Typ == typ)
                {
                    Platz.Kennzeichen = Kennzeichen;
                    return Platz.Id;
                }
                else
                {
                    continue;
                }      
            }
            return "Achtung Parkplatz ist Voll";
        }

        private void PersistPkwArray(string Path)
        {

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Path, false))
            {
                foreach (Parkplatz Platz in ParkPlatzList)
                {
                    file.WriteLine(Platz.GetParkplatzString());
                }
            }
        }


    }
}
