﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuhrparkanwendung.Functional;

namespace Fuhrparkanwendung.Data
{
    class WriteCSVFile
    {
        public void Run()
        {
            string[] lines = { "First line", "Second line", "Third line" };
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Helmut Karsten\Desktop\scholl\Jahr  zwei\ANW-OOP\Fuhrparkanwendung\Files\file2.txt"))
            {
                foreach (string line in lines)
                {
                        file.WriteLine(line);
                }
            }

            // Example #4: Append new text to an existing file.
            // The using statement automatically flushes AND CLOSES the stream and calls 
            // IDisposable.Dispose on the stream object.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Helmut Karsten\Desktop\scholl\Jahr  zwei\ANW-OOP\Fuhrparkanwendung\Files\file2.txt", true))
            {
                file.WriteLine("Fourth line");
            }
        }


        public void GenerateData()
        {
            Tuple<String, String>[] Cars = {
                new Tuple<String, String>("BMW", "3er"),
                new Tuple<String, String>("BMW", "5er"),
                new Tuple<String, String>("BMW", "7er"),
                new Tuple<String, String>("Mercedes", "C-Klasse"),
                new Tuple<String, String>("Mercedes", "E-Klasse"),
                new Tuple<String, String>("Mercedes", "S-Klasse"),
                new Tuple<String, String>("VW", "Golf"),
                new Tuple<String, String>("VW", "Passat"),
                new Tuple<String, String>("VW", "T6"),
                new Tuple<String, String>("Tesla", "Model S"),
                new Tuple<String, String>("Tesla", "Model 3"),
                new Tuple<String, String>("Tesla", "Model X"),
                new Tuple<String, String>("Audi", "A5"),
                new Tuple<String, String>("Audi", "A6"),
                new Tuple<String, String>("Audi", "A8"),
                new Tuple<String, String>("Audi", "i3")
            };

            String Kennzeichen = "K-HK-";
            int Hubraum = 1000;
            int PS = 100;
            double Anschaffungspreis = 25000;
            int Stellplatz = 0;

            Random rnd = new Random();

            List<Pkw> pkw = new List<Pkw>();

            for (int i = 0; i<100;  i++)
            {
                int Carindex = rnd.Next(16);

                Pkw w = new Pkw(
                    Cars[Carindex].Item1,
                    Cars[Carindex].Item2,
                    Kennzeichen + Convert.ToString(rnd.Next(1, 10000)), 
                    new DateTime(rnd.Next(2015, 2019), rnd.Next(1, 13), rnd.Next(1, 25)),
                    Anschaffungspreis + rnd.Next(1, 20000),
                    "A" + Convert.ToString(Stellplatz),
                    Hubraum + rnd.Next(1, 1500),
                    PS + rnd.Next(1, 100),
                    rnd.Next(3)
                    );
                
                
                //String line =
                //Kennzeichen + Convert.ToString(rnd.Next(1, 10000)) + "," +
                //Cars[Carindex].Item1 + "," +
                //Cars[Carindex].Item2 + "," +
                //Convert.ToString(rnd.Next(2015,2019))+"-"+ Convert.ToString(rnd.Next(1,13)) +"-"+ Convert.ToString(rnd.Next(1, 25)) + "," +
                //Convert.ToString(Anschaffungspreis + rnd.Next(1, 20000)) + "," +
                //"A" + Convert.ToString(Stellplatz) + "," +
                //Convert.ToString(Hubraum + rnd.Next(1, 1500)) + "," +
                //Convert.ToString(PS + rnd.Next(1, 100)) + "," +
                //Convert.ToString(rnd.Next(3));

                Stellplatz++;

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Helmut Karsten\Desktop\scholl\Jahr  zwei\ANW-OOP\Fuhrparkanwendung\Files\testNeu.csv", true))
                {
                    file.WriteLine(w.GetDatenString());
                }
            }

        }
    }
}