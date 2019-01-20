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
            test neu = new test();
            Action test = () => neu.function();
            MenueItem foo = new MenueItem("Test", test);
            //foo.execute();
            //Console.ReadKey();

            //FileHandler file = new FileHandler();

            //string[] t_set = { "Hallo", "Welt", "ich", "bin", "der", "Helmut" };

            //WriteCSVFile Text = new WriteCSVFile();

            //Text.GenerateData();

            //string path = @"C:\Users\Helmut Karsten\Desktop\scholl\Jahr  zwei\ANW-OOP\Fuhrparkanwendung\Files\testNeu.csv";

            //WriteReadPkw auto = new WriteReadPkw(path);
            //auto.Load();
            //auto.Show();

            String[] MText = { "Hallo", "Test", "Ja", "Nein", "Helmut", "Karsten", "Why", "Isolation", "kann", "eine", "Nation", "Toeten" };

            List<MenueItem> Mlist = new List<MenueItem>();

            Mlist.Add(foo);

            Menue menue = new Menue(MText, Mlist);
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
