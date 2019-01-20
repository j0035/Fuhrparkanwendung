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
        List<Parkplatz> Plaetze { get; set; }
        string Ort { get; set; } 
        string Adresse { get; set; }
        string Plz { get; set; }
        private int _anzMPlatz;
        private int _anzAPlatz { get; set; }
        private int _anzLPlatz { get; set; }

        public Parkhaus(string Parkhausname, int AnzahlParkplaetze, List<Parkplatz> Plaetze, string Ort, string Adresse, string Plz)
        {
            this.Parkhausname = Parkhausname;
            this.AnzahlParkplaetze = AnzahlParkplaetze;
            this.Plaetze = Plaetze;
            this.Ort = Ort;
            this.Adresse = Adresse;
            this.Plz = Plz;
        }

        public int AnzMPlatz
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

        public int AnzAPlatz
        {
            get { return _anzAPlatz; }
            set
            {
                int temp = 0;
                foreach (Parkplatz Platz in Plaetze)
                {
                    if (Platz.Typ == 0)
                    {
                        temp++;
                    }
                }

                _anzAPlatz = temp;
            }
        }

        public int AnzLPlatz
        {
            get { return _anzLPlatz; }
            set
            {
                int temp = 0;
                foreach (Parkplatz Platz in Plaetze)
                {
                    if (Platz.Typ == 1)
                    {
                        temp++;
                    }
                }

                _anzLPlatz = temp;
            }
        }
    }
}
