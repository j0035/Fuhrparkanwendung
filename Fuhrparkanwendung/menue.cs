using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrparkanwendung
{
    class Menue
    {
        ConsoleKeyInfo cki;
        int currentItem;
        List<MenueItem> MenueItems;
        Boolean exit, enter = false;

        public Menue(List<MenueItem> MenueItems)
        {
            currentItem = 0;
            this.MenueItems = MenueItems;
        }

        public void runMenue()
        {
            WriteMenueText();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Selection();
                    menueIterator(cki);
                    if (exit)
                    {
                        break;
                    }
                    else if (enter)
                    {
                        enter = false;
                        Console.Clear();
                        MenueItems[currentItem].execute();
                        currentItem = 0;
                        Console.ReadKey();
                        Console.Clear();
                        enter = false;
                        WriteMenueText();
                        
                    }
                    else
                    {
                        Console.Clear();
                        WriteMenueText();
                    }
                }
            }
        }

        public void Selection()
        {
            cki = Console.ReadKey();
        }

        private void WriteMenueText()
        {
            ShowInfoOnBottom();
            for (int i = 0; i < MenueItems.Count; i++)
            {
                WriteSingleMenueItems(i);
            }


            //foreach (MenueItem Item in MenueItems)
            //{
            //    WriteSingleMenueItems(Item.Name);
            //}
        }

        private void WriteSingleMenueItems(int iterator)
        {
            if (iterator == currentItem)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }

            Console.WriteLine(MenueItems[iterator].Name);

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void menueIterator(ConsoleKeyInfo cki)
        {

            if (cki.Key == ConsoleKey.DownArrow)
            {
                currentItem++;
                checkForRimCase(1);
            }
            if (cki.Key == ConsoleKey.UpArrow)
            {
                currentItem--;
                checkForRimCase(0);
            }
            if (cki.Key == ConsoleKey.E)
            {
                exit = true;
            }
            if (cki.Key == ConsoleKey.Enter)
            {
                enter = true;
            }
        }

        private void checkForRimCase(int TopBottom)
        {
            if (TopBottom == 0 && CompairTwoItems(0, currentItem))
            {
                currentItem = this.MenueItems.Count - 1;
            }
            if (TopBottom == 1 && CompairTwoItems(currentItem, this.MenueItems.Count - 1))
            {
                currentItem = 0;
            }
        }

        private Boolean CompairTwoItems(int firstItem, int secondItem)
        {
            return firstItem > secondItem;
        }

        public void ShowInfoOnBottom() // diese funktionen sind kackendreist kopiert
        {
            string symbol = "Um dieses Menü zu verlassen drücken Sie E";
            int x = 0;
            int y = 49;
            ConsoleColor color = ConsoleColor.White;

            // Remember current state
            int memX = Console.CursorLeft;
            int memY = Console.CursorTop;
            ConsoleColor memColor = Console.ForegroundColor;

            ShowText(symbol, x, y, color);

            // Restore remembered state
            Console.CursorLeft = memX;
            Console.CursorTop = memY;
            Console.ForegroundColor = memColor;
        }

        private static void ShowText(string text, int x, int y, ConsoleColor color) // diese funktionen sind kackendreist kopiert
        {
            // Show symbol regarding its paramters
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
}