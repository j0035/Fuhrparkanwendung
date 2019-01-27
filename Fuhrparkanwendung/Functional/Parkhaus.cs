using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    class Parkhaus
    {
        public string Parkhausname { get; set; }
        int AnzahlParkplaetze { get; set; }
        public string Ort { get; set; } 
        public string Adresse { get; set; }
        public string Plz { get; set; }

        public Parkhaus(string Parkhausname, string Ort, string Adresse, string Plz)
        {
            this.Parkhausname = Parkhausname;
            this.Ort = Ort;
            this.Adresse = Adresse;
            this.Plz = Plz;
        }

        public String GetParkhausString()
        {
           return String.Format(this.Parkhausname + ',' + this.AnzahlParkplaetze + ',' + this.Ort + ',' + this.Adresse + ',' + this.Plz );
        }
    }
}
