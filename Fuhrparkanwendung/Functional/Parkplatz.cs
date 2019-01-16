using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Functional
{
    abstract class Parkplatz
    {
        public string Id { get; set; }
        public bool Besetzt { get; set; }
        public int Typ { get; set; }
        public string _Kennzeichen { get; set; }
        
        public Parkplatz(string Id, int Typ, bool Besetzt = false)
        {
            this.Id = Id;
            this.Typ = Typ;
            this.Besetzt = Besetzt;
        }

        public string Kennzeichen
        {
            get { return _Kennzeichen; }
            set 
            {
                if (Besetzt)
                {
                    throw new InvalidOperationException("Parkplatz ist besetzt");
                }
                else
                {
                    _Kennzeichen = value;
                }
            }
        }
        
    }
}
