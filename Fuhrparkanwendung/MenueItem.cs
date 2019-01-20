using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung
{
    class MenueItem
    {
        public string Name;
        public Action executableFunction;

        public MenueItem(string Name, Action execute)
        {
            this.Name = Name;
            executeMenueFunction(execute);
        }

        public void executeMenueFunction(Action execute)
        {
            executableFunction = execute;
        }
        
        public void execute()
        {
            executableFunction();
        }
    }
}
