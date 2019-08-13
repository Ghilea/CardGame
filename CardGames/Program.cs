using System;
using System.Collections.Generic;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> mainMenu = new List<string> { "Spela Snabbpoker", "Välj spelarnamn", "Visa hichscorelista", "Avsluta" };

            //init
            var menu = new Menu();
            menu.DrawMenuBox();
            menu.SetUpMenuList(mainMenu);

            //menu
            menu.MainMenu();

            Console.ReadKey();
        }
    }
}
