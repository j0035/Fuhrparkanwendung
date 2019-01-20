using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    class Motorrad : Fahrzeug
    {
        public int Hubraum { get; set; }

        public Motorrad(string Hersteller, string Modell, string Kennzeichen, DateTime Erstzulassung, double Anschaffungspreis, string Stellplatz, int Hubraum)
            :base(Hersteller, Modell, Kennzeichen, Erstzulassung, Anschaffungspreis, Stellplatz)
        {
            this.Hubraum = Hubraum;

        }

        public override double Steuerschuld()
        {
            return (this.Hubraum + 99) / 100 * 20;
        }

        public override string GetDatenString()
        {
            return String.Format(this.Kennzeichen + ',' + this.Hersteller + ',' + this.Modell + ',' + this.Erstzulassung + ',' + this.Anschaffungspreis + ',' + this.Stellplatz + ',' + this.Hubraum);
        }
    }
}
