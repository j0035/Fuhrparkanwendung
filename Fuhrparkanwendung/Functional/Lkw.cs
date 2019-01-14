using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    abstract class Lkw : Fahrzeug
    {
        public int AnzahlAchsen { get; set; }
        public int Zuladung { get; set; }

        public Lkw(string Hersteller, string Modell, string Kennzeichen, DateTime Erstzulassung, double Anschaffungspreis, string Stellplatz, int AnzahlAchsen, int Zuladung)
            :base(Hersteller, Modell, Kennzeichen, Erstzulassung, Anschaffungspreis, Stellplatz)
        {
            this.AnzahlAchsen = AnzahlAchsen;
            this.Zuladung = Zuladung;
        }

        public override double Steuerschuld()
        {
            return this.Zuladung * 100;
        }
    }
}
