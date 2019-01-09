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
        string[] menueText = {};
        int menueLength;
        Boolean exit = false;

        public Menue(string[] menueText)
        {
            this.menueText = menueText;
            this.menueLength = this.menueText.Length;
            currentItem = 0;
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
            for (int i = 0; i < 4; i++)
            {
                WriteSingleMenueItems(i);
            }
        }

        private void WriteSingleMenueItems(int iterator)
        {
            if (iterator == currentItem)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }

            Console.WriteLine(menueText[iterator]);

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
            if (cki.Key == ConsoleKey.Enter && currentItem == 3)
            {
                exit = true;
            }
            if (cki.Key == ConsoleKey.Enter && currentItem == 0)
            {
                // PASS
            }
        }

        private void checkForRimCase(int TopBottom)
        {
            if (TopBottom == 0 && CompairTwoItems(0, currentItem))
            {
                currentItem = this.menueLength - 1;
            }
            if (TopBottom == 1 && CompairTwoItems(currentItem, this.menueLength - 1))
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