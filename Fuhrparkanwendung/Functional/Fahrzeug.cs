using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    abstract class Fahrzeug
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public string Kennzeichen { get; set; }
        public DateTime Erstzulassung { get; set; }
        public double Anschaffungspreis {get; set; }
        public string Stellplatz { get; set; }

        public Fahrzeug(string Hersteller, string Modell, string Kennzeichen, DateTime Erstzulassung, double Anschaffungspreis, string Stellplatz)
        {
            this.Hersteller = Hersteller;
            this.Modell = Modell;
            this.Kennzeichen = Kennzeichen;
            this.Erstzulassung = Erstzulassung;
            this.Anschaffungspreis = Anschaffungspreis;
            this.Stellplatz = Stellplatz;

        }

        abstract public double Steuerschuld();

        abstract public string GetDatenString();

        abstract public void StellPlatzBuchen(string path, string Haus);

    }
}
