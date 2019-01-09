using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung
{
    class Program
    {
        static void Main(string[] args)
        {
            test neu = new test();
            Action test = () => neu.function();
            MenueItem foo = new MenueItem("Test", test);
            foo.execute();
            Console.ReadKey();
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
