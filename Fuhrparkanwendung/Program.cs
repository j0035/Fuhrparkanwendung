using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuhrparkanwendung.Data;

namespace Fuhrparkanwendung
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Helmut Karsten\Desktop\scholl\Jahr  zwei\ANW-OOP\Fuhrparkanwendung\Files\testNeu.csv";
            test neu = new test();
            Action test = () => neu.function();
            WriteReadPkw cars = new WriteReadPkw(path);
            Action bubu = () => cars.Show();
            MenueItem foo = new MenueItem("Test", test);
            MenueItem bar = new MenueItem("Alle Autos", bubu);
            //foo.execute();
            //Console.ReadKey();

            //FileHandler file = new FileHandler();

            //string[] t_set = { "Hallo", "Welt", "ich", "bin", "der", "Helmut" };

            //WriteCSVFile Text = new WriteCSVFile();

            //Text.GenerateData();

            

            //WriteReadPkw auto = new WriteReadPkw(path);
            //auto.Load();
            //auto.Show();

            List<MenueItem> Mlist = new List<MenueItem>();

            Mlist.Add(foo);
            Mlist.Add(bar);

            Menue menue = new Menue(Mlist);
            menue.runMenue();




        }
    }

    internal class test
    {
        public void function()
        {
            Console.WriteLine("Hello World");
        }
    }

}
