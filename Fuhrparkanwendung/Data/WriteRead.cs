using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung.Data
{
    class WriteRead
    {
        public string ValidateInput(int QNumber, string input, string kennzeichen, int typ)
        {
            string path = @"C:\Users\Public\FuhrparkanwendungFia72";
            String id = "";
            if (QNumber == 3)
            {
                List<String> Fehler = DateValidate(input);
                if (Fehler.Count != 0)
                {
                    foreach (string Falsch in Fehler)
                    {
                        Console.WriteLine(Falsch);
                    }
                    return null;
                }
                Console.WriteLine("Fehler Count = " + Convert.ToString(Fehler.Count));
            }

            if (QNumber == 5)
            {
                
                String[] inputArr = input.Split('/');
                WriteReadParkhausParkplatz Parkplatz = new WriteReadParkhausParkplatz(path + "\\" + "parkhaus.csv", path + "\\" + "parkplatz.csv");
                if (inputArr.Length == 1)
                {
                    id = Parkplatz.BucheParkplatz(kennzeichen, typ, inputArr[0]);
                    if(id == null)
                    {
                        Console.WriteLine("Ihr Parkhaus ist voll!!!");
                        return null;
                        
                    }
                }
                else
                {
                    id = Parkplatz.BucheParkplatz(kennzeichen, typ, inputArr[0], inputArr[1]);
                    if (id == null)
                    {
                        Console.WriteLine("Parkplatz ist besetzt oder das Fahrzeug entspricht nicht dem Parkpaltztyp, bitte einen Anderen Platz auswählen");
                        return null;
                    }
                }
            }

            return id;
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

        public List<String> Antworten ( String[] Fragen, int FahrzeugTyp )
        {
            List<String> Parameter = new List<String>();

            int count = 0;
            string Kennzeichen = null;

            for (int i = 0; i < Fragen.Length; i++)
            {

                Console.WriteLine(Fragen[i]);
                String Antwort = Console.ReadLine();

                if (count > 2)
                {
                    Kennzeichen = Parameter[2];
                }

                if (count == 5)
                {
                    string id = ValidateInput(count, Antwort, Kennzeichen, FahrzeugTyp);
                    Parameter.Add(id);
                    Console.Clear();
                    count++;
                }
                else if (ValidateInput(count, Antwort, Kennzeichen, FahrzeugTyp) == "")
                {
                    Parameter.Add(Antwort);
                    Console.Clear();
                    count++;
                }
                else
                {
                    i--;
                }
            }

            return Parameter;
        }


    }
}
