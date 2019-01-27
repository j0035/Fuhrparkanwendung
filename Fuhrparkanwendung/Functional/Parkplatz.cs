using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    class Parkplatz
    {
        public string Id { get; set; }
        public bool Besetzt { get; set; }
        public int Typ { get; set; }
        public string _Kennzeichen { get; set; }
        private string ParkhausHier, PlatzHier;
        
        
        public Parkplatz(string Id, int Typ, bool Besetzt = false, string Kennzeichen = null)
        {
            this.Id = Id;
            this.Typ = Typ;
            this.Besetzt = Besetzt;
            this.Kennzeichen = Kennzeichen;
            String[] IdSplit = Id.Split('/');
            this.ParkhausHier = IdSplit[0];
            this.PlatzHier = IdSplit[1];
        }

        public string Kennzeichen
        {
            get { return _Kennzeichen; }
            set 
            {
                if (Besetzt && Kennzeichen != null)
                {
                    throw new InvalidOperationException("Parkplatz ist besetzt");
                }
                else
                {
                    _Kennzeichen = value;
                    Besetzt = _Kennzeichen != null; 
                }
            }
        }

        public void BucheStellplatz(string Kennzeichen)
        {
            this.Kennzeichen = Kennzeichen;
        }

        public string StellplatzEntbuchen ()
        {
            string ret = Kennzeichen;
            this.Kennzeichen = null;
            return ret;
        }

        public string GetParkplatzString()
        {
            return String.Format(this.Id + ',' + this.Typ + ','  + this.Kennzeichen);

        }

        public string Parkhaus()
        {
            return ParkhausHier;
        }

        public string Platz()
        {
            return PlatzHier;
        }

    }
}
