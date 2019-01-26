using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Data
{
    class WriteRead
    {
        public Boolean ValidateInput(int QNumber, string input)
        {
            if (QNumber == 3)
            {
                List<String> Fehler = DateValidate(input);
                if (Fehler.Count != 0)
                {
                    foreach (string Falsch in Fehler)
                    {
                        Console.WriteLine(Falsch);
                    }
                    return false;
                }

                Console.WriteLine("Fehler Count = " + Convert.ToString(Fehler.Count));
            }

            return true;
        }

        public List<String> DateValidate(string input)
        {
            string[] Datum = input.Split('.');
            List<String> Fehler = new List<string>();
            if (Convert.ToInt32(Datum[1]) < 1 || Convert.ToInt32(Datum[1]) > 12)
            {
                Fehler.Add("Der Monat muss zwischen 1 und 12 liegen!");
            }
            if (Convert.ToInt32(Datum[0]) < 1 || ((Convert.ToInt32(Datum[0]) > 31 && Convert.ToInt32(Datum[1]) % 2 == 1) || (Convert.ToInt32(Datum[0]) > 30 && Convert.ToInt32(Datum[1]) % 2 == 0) && Convert.ToInt32(Datum[1]) < 7) || ((Convert.ToInt32(Datum[0]) > 31 && Convert.ToInt32(Datum[1]) % 2 == 0) || (Convert.ToInt32(Datum[0]) > 30 && Convert.ToInt32(Datum[1]) % 2 == 1) && Convert.ToInt32(Datum[1]) > 7) || (Convert.ToInt32(Datum[0]) > 29 && Convert.ToInt32(Datum[1]) == 2))
            {
                Fehler.Add("Der Tag exsistiert im " + Datum[1] + ". Monat nicht");
            }
            if (Datum[2].Length != 4)
            {
                Fehler.Add("Die Jahresangabe entspricht nicht dem Format (JJJJ)");
            }
            return Fehler;
        }
    }
}
