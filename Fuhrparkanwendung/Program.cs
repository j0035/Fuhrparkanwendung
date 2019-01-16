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
            //test neu = new test();
            //Action test = () => neu.function();
            //MenueItem foo = new MenueItem("Test", test);
            //foo.execute();
            //Console.ReadKey();

            FileHandler file = new FileHandler();

            string[] t_set = { "Hallo", "Welt", "ich", "bin", "der", "Helmut" };

            file.Save("./Data/Test/test.csv", t_set, true, true);
        }
    }

    //internal class test
    //{
    //    public void function()
    //    {
    //        Console.WriteLine("Hello World");
    //    }
    //}
    
}
