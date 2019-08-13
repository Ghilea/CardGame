using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class Players
    {
        public string PlayerName { get; set; }
        public int PlayerPoints { get; set; }

        public void DrawPlayer()
        {
            int x = 7;
            int y = 2;

            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowHeight));
            Console.SetCursorPosition(0, currentLineCursor);
  
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("{0}", PlayerName);
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("{0} poäng", PlayerPoints);
        }
    }
}