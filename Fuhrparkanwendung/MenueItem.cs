using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung
{
    class MenueItem
    {
        string Name;
        Func<Boolean> executableFunction;

        public MenueItem(string Name, Func<Boolean> execute)
        {
            this.Name = Name;
            executeMenueFunction(execute);
        }

        public void executeMenueFunction(Func<Boolean> execute)
        {
            executableFunction = execute;
        }
        
        public void execute()
        {
            executableFunction();
        }
    }
}
