using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game.Classes;
namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            string playerName;

            Console.WriteLine("Enter the name of your player: ");
            Console.WriteLine();
            playerName = Console.ReadLine();
            GameManager.StartGame(playerName);

            Console.WriteLine("---- FOREST ADVENTURE GAME ----");
            bool quit = false;
            do
            {
                Console.WriteLine(GameManager.CurrentPlayer.ToString());
                Console.WriteLine();
                Message.Success("Menu of Commands: L = Look Around | A = Attack | B = Buy Items | Q = Quit");
                Message.Success("Menu of Powers : H = Healing | I = Invisible | P = Protect | S = Sleepy");

                input = Console.ReadKey();
                Console.WriteLine();
                Execute(input.Key);
                if(input.Key == ConsoleKey.Q)
                {
                    if(GameManager.CurrentPlayer.Enemy == null)
                    {
                        quit = true;
                        Message.Danger("You are going to quit the game ! Press any key to close the window ...");
                    }
                    else
                    {
                        Message.Danger("You cannot quit the game ! There is an enemy in front of you !");
                    }
                    
                }
            } while (!quit && !GameManager.gameOver);

            GameManager.SaveGame();
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------
        
        public static void Execute(ConsoleKey key)
        {
            //------------------------  H = Heal Power  ------------------------------
            if (key == ConsoleKey.H)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.Healing);
            }
            //------------------------  I = Invisible Power------------------------------
            if (key == ConsoleKey.I)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.Invisible);
            }
            //------------------------  P = Protect Power------------------------------
            if (key == ConsoleKey.P)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.Protect);
            }
            //------------------------  S = Sleepy Power------------------------------
            if (key == ConsoleKey.S)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.Sleepy);
            }
            //------------------------  B = Buy Items------------------------------
            if (key == ConsoleKey.B)
            {
                Power healing = GameFactory.CreateHealing();
                Power invisible = GameFactory.CreateInvisible();
                Power protect = GameFactory.CreateProtect();
                Power sleepy = GameFactory.CreateSleepy();
                Message.Warning("Store Powers  : H = Healing "+healing.Price+" | I = Invisible "+invisible.Price+" | P = Protect "+protect.Price+ " | S = Sleepy "+ sleepy.Price);
                Weapon rock  = GameFactory.CreateRock();
                Weapon torch = GameFactory.CreateTorch();
                Weapon sword = GameFactory.CreateSword();
                Message.Warning("Store Weapons : R = Rock " + rock.Price + " | T = Torch " + torch.Price + " | M = Magic Sword " + sword.Price );

                ConsoleKeyInfo buyCommand = Console.ReadKey();
                switch (buyCommand.Key)
                {
                    case ConsoleKey.H: 
                        GameManager.CurrentPlayer.BuyItem(healing);
                        break;
                    case ConsoleKey.I:
                        GameManager.CurrentPlayer.BuyItem(invisible);
                        break;
                    case ConsoleKey.P:
                        GameManager.CurrentPlayer.BuyItem(protect);
                        break;
                    case ConsoleKey.S:
                        GameManager.CurrentPlayer.BuyItem(sleepy);
                        break;
                    case ConsoleKey.R:
                        GameManager.CurrentPlayer.BuyItem(rock);
                        break;
                    case ConsoleKey.T:
                        GameManager.CurrentPlayer.BuyItem(torch);
                        break;
                    case ConsoleKey.M:
                        GameManager.CurrentPlayer.BuyItem(sword);
                        break;
                    default:
                        Message.Danger("Wrong command !");
                        break;
                }
                
            }
            // -------------------------  L = Look Around  --------------------
            if (key == ConsoleKey.L)
            {
                if (GameManager.CurrentPlayer.Enemy == null)
                {
                    GameManager.Explore();
                }
                else
                {
                    Message.Danger("There is an enemy in front of you !");
                    GameManager.CurrentPlayer.Enemy.Attack();
                    Message.Danger("You are hit !");
                    if (GameManager.CurrentPlayer.IsDead())
                    {
                        GameManager.GameOver();
                    }
                }
            }
            //------------------------  A = Attack  ------------------------------
            if (key == ConsoleKey.A)
            {
                if (GameManager.CurrentPlayer.Enemy == null)
                {
                    Message.Danger("There is no enemy to attack !");
                }
                else
                {
                    GameManager.StartBattle();

                    if (GameManager.CurrentPlayer.Enemy != null && !GameManager.CurrentPlayer.Enemy.IsDead())
                    {
                        if (GameManager.CurrentPlayer.IsDead())
                        {
                            GameManager.GameOver();
                        }
                    }
                }
            }

        }


    }
}
