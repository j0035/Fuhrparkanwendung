using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuhrparkanwendung.Data;

namespace Fuhrparkanwendung.Functional
{
    class Pkw : Fahrzeug
    {
        public int Hubraum { get; set; }
        public int Leistung { get; set; }
        public int Schadstoffklasse { get; set; }

        public Pkw (string Hersteller, string Modell, string Kennzeichen, DateTime Erstzulassung, double Anschaffungspreis, string Stellplatz, int Hubraum, int Leistung, int Schadstoffklasse)
            :base(Hersteller, Modell, Kennzeichen, Erstzulassung, Anschaffungspreis, Stellplatz)
        {
            this.Hubraum = Hubraum;
            this.Leistung = Leistung;
            this.Schadstoffklasse = Schadstoffklasse;

        }

        public override double Steuerschuld()
        {
            return (this.Hubraum + 99) / 100 * 10 * (Schadstoffklasse + 1);
        }

        public override string GetDatenString()
        {
            return String.Format(this.Kennzeichen + ',' + this.Hersteller + ',' + this.Modell + ',' + this.Erstzulassung + ',' + this.Anschaffungspreis + ',' + this.Stellplatz + ',' + this.Hubraum + ',' + this.Leistung + ',' + this.Schadstoffklasse);
        }

        public override void StellPlatzBuchen(string path, string Haus)
        {
            WriteReadParkhausParkplatz platz = new WriteReadParkhausParkplatz(path + "\\" + "parkhaus.csv", path + "\\" + "parkplatz.csv");
            this.Stellplatz = platz.BucheParkplatz(this.Kennzeichen, 0, Haus);
        }
    }
}
