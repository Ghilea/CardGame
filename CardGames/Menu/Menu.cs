using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGames
{
    class Menu : MenuList
    {
        private MenuList[] list;

        //resetar bara raden
        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowHeight));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void SetUpMenuList(List<string> arrList)
        {
            list = new MenuList[arrList.Count];
            int i = 0;
            
            foreach (var l in arrList)
            {
                list[i] = new MenuList { MyMenuTitle = l, MyIndex = i};
                i++;
            }
        }

        public void MainMenu()
        {            
            bool InMenu = true;
            string leftArrow = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x25BA"));
            string rightArrow = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("\x25C4"));
            bool Start = false;

            //gömmer pekare
            Console.CursorVisible = false;

            int x = 5;
            int y = 13;

            while (InMenu)
            {

                //det menynamn som markeras får ändrad färg och symboler, annars är det normalt
                for (int i = 0; i < list.Length; i++)
                {
                    Console.SetCursorPosition(x, y + i);

                    if (i == MyIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.OutputEncoding = Encoding.Unicode;
                        Console.Write("{0} {1} {2}", leftArrow, list[i].MyMenuTitle, rightArrow);
                    }
                    else
                    {
                        Console.Write("  {0}  ", list[i].MyMenuTitle);
                    }

                    Console.ResetColor();
                }

                ConsoleKeyInfo button = Console.ReadKey();

                switch (button.Key)
                {
                    case ConsoleKey.DownArrow:

                        if (MyIndex == list.Length - 1) { MyIndex = 0; }
                        else { MyIndex++; }

                        break;
                    case ConsoleKey.UpArrow:

                        if (MyIndex <= 0) { MyIndex = list.Length - 1; }
                        else { MyIndex--; }
                        
                        break;
                    case ConsoleKey.Enter:
                        
                        switch (MyIndex)
                        {
                            case 0:
                                Start = false;
                                QuickPoker();
                                break;
                            case 1:
                                PlayerName();
                                break;
                            case 2:
                                //GetHighScore();
                                break;
                            case 3:
                                Exit();
                                break;
                        }
                        
                        break;
                }

                ClearCurrentConsoleLine();
            }

        }

        public void PlayerName()
        {

            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(40, 10);
            Console.WriteLine("Skriv in namn för spelare");

            Console.SetCursorPosition(40, 11);
            Console.Write("Namn: ");

            Players player = new Players();
            player.PlayerAlias = Console.ReadLine();
            player.PlayerPoints = 0;
            player.DrawPlayer();
            
        }

        //fixa points
      /*  private void SaveOnePlayerAlias()
        {
            var valueName = new Player { Name = PlayerAlias };

            using (var context = new Context())
            {
                context.DPlayer.Add(valueName);
                context.SaveChanges();

                var id = valueName.Id;
                var valueScore = new HighScore { Points = PlayerPoints, PlayerId = id };
                context.DHighScore.Add(valueScore);
                context.SaveChanges();
            }
        }*/

        //fixa highscore
        private void GetHighScore()
        {
            using (var context = new Context())
            {
                var items = context.DHighScore.OrderByDescending(u => u.Points).Take(1);
                var show = items.ToList(); // ToList forces execution

                Console.SetCursorPosition(40, 10);
                Console.Write("kjlkjdsldkdj TEST "+show);
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void QuickPoker()
        {
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.Clear();
            Console.Title = "Snabbpoker";

            PlayingCardGame pcg = new PlayingCardGame();
            pcg.Deal(/*PlayerAlias*/"Player 1", PlayingCard.SIDEUP.OPEN);
 
            //PokerMenu();
        }
    
       /* public void PokerMenu()
        {
            Console.SetCursorPosition(0, 0);

            //gömmer muspekaren
            Console.CursorVisible = false;

            while (InMenu)
            {
                for (int i = 0; i < QuickpokerMenu.Count; i++)
                {
                    if (i == menuList.IndexItem)
                    {

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.OutputEncoding = Encoding.Unicode;

                        Console.Write(" {0} {1} {2} ", leftArrow, QuickpokerMenu[i], rightArrow);

                    }
                    else
                    {
                        Console.Write("  {0} ", QuickpokerMenu[i]);
                    }

                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;

                }

                ConsoleKeyInfo button = Console.ReadKey();

                switch (button.Key)
                {
                    case ConsoleKey.RightArrow:
                        Console.Beep(264, 125);
                        if (menuList.IndexItem == QuickpokerMenu.Count - 1)
                        { menuList.IndexItem = 0; }
                        else
                        { menuList.IndexItem++; }

                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Beep(264, 125);
                        if (menuList.IndexItem <= 0)
                        { menuList.IndexItem = QuickpokerMenu.Count - 1; }
                        else
                        { menuList.IndexItem--; }

                        break;
                    case ConsoleKey.Enter:
                        Console.Beep(364, 125);
                        switch (menuList.IndexItem)
                        {
                            case 0:
                                QuickPoker();
                                break;
                            case 1:
                                SaveOnePlayerAlias();
                                menuList.IndexItem = 0;
                                Console.ResetColor();
                                Console.Clear();
                                MainMenu();
                                break;
                            case 2:
                                Exit();
                                break;
                        }

                        break;
                }

                ClearCurrentConsoleLine();
            }
        }*/

    }
}
