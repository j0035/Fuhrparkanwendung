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
        string[] menueText = {};
        int menueLength;
        Boolean exit = false;

        public Menue(string[] menueText, List<MenueItem> MenueItems)
        {
            this.menueText = menueText;
            this.menueLength = this.menueText.Length;
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
                    else if (exit)
                    {
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
            //if (cki.Key == ConsoleKey.Enter && currentItem == MenueItems.Count - 1)
            //{
            //    exit = true;
            //}
            if (cki.Key == ConsoleKey.Enter)
            {
                MenueItems[currentItem].execute();
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

        public Boolean test()
        {
            Console.WriteLine("Hallo Welt");
            return true;
        }
    }
}