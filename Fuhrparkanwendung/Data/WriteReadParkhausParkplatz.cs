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
        String filePathParkhaus, filePathParkplatz;

        public WriteReadParkhausParkplatz(string filePathParkhaus, string filePathParkplatz)
        {
            LoadParkhausList(filePathParkhaus);
            LoadParkplatzList(filePathParkplatz);
            this.filePathParkhaus = filePathParkhaus;
            this.filePathParkplatz = filePathParkplatz;

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

        private void PersistParkhausAdresse (string filePathParkhaus)
        {

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(filePathParkhaus, false))
            {
                foreach (Parkhaus Haus in ParkHausList)
                {
                    file.WriteLine(Haus.GetParkhausString());
                }
            }
        }

        private List<String> AskForInputParkhaus()
        {
            String[] Fragen = {
                "Geben Sie den Parkhausnamen bzw. die Parkhaus ID ein",
                "Geben Sie die Straße und Nummer des Parkhauses ein",
                "Geben Sie die Postleitzahl ein",
                "Geben Sie den Ort ein"
            };

            List<String> Parameter = new List<String>();

            for (int i = 0; i < Fragen.Length; i++)
            {

                Console.WriteLine(Fragen[i]);
                String Antwort = Console.ReadLine();

               
                Parameter.Add(Antwort);
                Console.Clear();
            }

            return Parameter;
        }

        public void AddNewDataSetParkhaus()
        {
            List<String> newParkhaus = AskForInputParkhaus();

            Parkhaus Parkhaus = new Parkhaus(
                        newParkhaus[0],
                        newParkhaus[3],
                        newParkhaus[1],
                        newParkhaus[2]
                        );

            ParkHausList.Add(Parkhaus);
            AddNewDataSetParkplatz(newParkhaus[0]);
            SaveParkhaus();
        }

        public void SaveParkhaus()
        {
            PersistParkhausAdresse(filePathParkhaus);
        }

        //--------------------------------------------------------------------

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

        private void PersistParkPlatzAdresse(string filePathParkhaus)
        {

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(filePathParkhaus, false))
            {
                foreach (Parkplatz Platz in ParkPlatzList)
                {
                    file.WriteLine(Platz.GetParkplatzString());
                }
            }
        }

        public void SaveParkplatz()
        {
            PersistParkPlatzAdresse(filePathParkplatz);
        }

        private List<String> AskForInputParkplatz(string Parkhaus = null)
        {
            String[] Fragen = {
                "Geben Sie die ID des Parkhauses an",
                "Geben Sie die Anzahl von Pkw Parkplätzen an",
                "Geben Sie die Anzahl von Lkw Parkplätzen an",
                "Geben Sie die Anzahl von Motorrad Parkplätzen an"
            };

            List<String> Parameter = new List<String>();

            if (Parkhaus == null)
            {
                for (int i = 0; i < Fragen.Length; i++)
                {

                    Console.WriteLine(Fragen[i]);
                    String Antwort = Console.ReadLine();


                    Parameter.Add(Antwort);
                    Console.Clear();
                }
            }
            else
            {
                Parameter.Add(Parkhaus);
                for (int i = 1; i < Fragen.Length; i++)
                {

                    Console.WriteLine(Fragen[i]);
                    String Antwort = Console.ReadLine();


                    Parameter.Add(Antwort);
                    Console.Clear();
                }
            }
            

            return Parameter;

        }

        public void AddNewDataSetParkplatz(string Parkhaus = null)
        {
            List<String> newParkplatz = AskForInputParkplatz(Parkhaus);
            int[] type = { 0, 1, 2 };

            int Counter = 0;

            for (int k = 1; k < newParkplatz.Count; k++)
            {
                for (int i = 0; i < Convert.ToInt32(newParkplatz[k]); i++)
                {
                    Parkplatz Platz = new Parkplatz(
                    newParkplatz[0] + '/' + Convert.ToString(Counter),
                    type[k - 1]);
                    Counter++;
                    ParkPlatzList.Add(Platz);
                }
            }
            
            SaveParkplatz();
        }

        public string BucheParkplatz(string Kennzeichen, int typ, string Parkhaus, string OnePlatz = "")
        {
            foreach (Parkplatz Platz in ParkPlatzList)
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
            return "Achtung Parkplatz ist belegt";
        }

    }
}
