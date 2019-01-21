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
        List<Pkw> Pkws;
        List<Lkw> Lkws;
        List<Motorrad> Bikes;
        List<Parkplatz> ParkPlatzList;
        List<Parkhaus> ParkHausList;

        public WriteReadParkhausParkplatz(string filePathParkhaus, string filePathParkplatz, List<Pkw> Pkws, List<Lkw> Lkws, List<Motorrad> Bikes)
        {
            this.Pkws = Pkws;
            this.Lkws = Lkws;
            this.Bikes = Bikes;
            LoadParkhausList(filePathParkhaus);
            LoadParkplatzList(filePathParkplatz);

        }

        private void LoadParkplatzList(string filePathParkplatz)
        {
            using (StreamReader reader = new StreamReader(filePathParkplatz))
            {
                String ln;

                while ((ln = reader.ReadLine()) != null)
                {
                    string[] ParkPlatz = ln.Split(',');
                    Boolean Besetzt = ParkPlatz[2] == "" ? false : true;
                    string Kennzeichen = Besetzt == false ? ParkPlatz[2] : null;
                    Parkplatz Platz = new Parkplatz( ParkPlatz[0], Convert.ToInt16(ParkPlatz[1]), Besetzt, Kennzeichen );
                    ParkPlatzList.Add(Platz);

                }
            }
        }

        private void LoadParkhausList(string filePathParkhaus)
        {
            using (StreamReader reader = new StreamReader(filePathParkhaus))
            {
                String ln;

                while ((ln = reader.ReadLine()) != null)
                {
                    string[] Adresse = ln.Split(',');
                    Parkhaus Haus = new Parkhaus(Adresse[0], 0, Adresse[1], Adresse[2], Adresse[3]);
                    ParkHausList.Add(Haus);

                }
            }
        }


    }
}
