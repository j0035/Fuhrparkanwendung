using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    abstract class Parkhaus
    {
        string Parkhausname { get; set; }
        int AnzahlParkplaetze { get; set; }
        Parkplatz[] Plaetze { get; set; }
        string Ort { get; set; } 
        string Adresse { get; set; }
        string Plz { get; set; }
        int _anzMPlatz;
        int _anzAPlatz { get; set; }
        int _anzLPlatz { get; set; }

        public Parkhaus(string Parkhausname, int AnzahlParkplaetze, Parkplatz[] Plaetze, string Ort, string Adresse, string Plz)
        {
            this.Parkhausname = Parkhausname;
            this.AnzahlParkplaetze = AnzahlParkplaetze;
            this.Plaetze = Plaetze;
            this.Ort = Ort;
            this.Adresse = Adresse;
            this.Plz = Plz;
        }

        public int anzMPlatz
        {
            get { return _anzMPlatz; }
            set
            {
                int temp = 0;
                foreach (Parkplatz Platz in Plaetze) {
                    if (Platz.Typ == 2)
                    {
                        temp++;
                    }
                }

                _anzMPlatz = temp;
            }
        }
    }
}
