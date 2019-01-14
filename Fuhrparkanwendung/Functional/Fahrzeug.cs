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
        public float Anschaffungspreis {get; set; }

        public Fahrzeug(string Hersteller, string Modell, string Kennzeichen, DateTime Erstzulassung, float Anschaffungspreis)
        {
            this.Hersteller = Hersteller;
            this.Modell = Modell;
            this.Kennzeichen = Kennzeichen;
            this.Erstzulassung = Erstzulassung;
            this.Anschaffungspreis = Anschaffungspreis;

        }
    }
}
