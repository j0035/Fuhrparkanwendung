using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuhrparkanwendung.Data;

namespace Fuhrparkanwendung.Functional
{
    class Lkw : Fahrzeug
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

        public override string GetDatenString()
        {
            return String.Format(this.Kennzeichen + ',' + this.Hersteller + ',' + this.Modell + ',' + this.Erstzulassung + ',' + this.Anschaffungspreis + ',' + this.Stellplatz + ',' + this.AnzahlAchsen + ',' + this.Zuladung);
        }

        public override void StellPlatzBuchen(string path, string Haus)
        {
            WriteReadParkhausParkplatz platz = new WriteReadParkhausParkplatz(path + "\\" + "parkhaus.csv", path + "\\" + "parkplatz.csv");
            this.Stellplatz = platz.BucheParkplatz(this.Kennzeichen, 1, Haus);
        }
    }
}
