using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public static class GameManager
    {
        public static List<Player> ListPlayers = new List<Player>();
        public static Player CurrentPlayer;
        public static bool gameOver = false;
        private static int BattleRounds = 0;
        private static int MaxRounds = 5;
        
        public static void StartGame(string name)
        {
            try
            {
                GameManager.ListPlayers = DataXML.Load("HighScores.xml");
            }catch(Exception e) {
                Console.WriteLine("Exception error : "+e.Message);
            }
            
            Player player = Search_Player(name);
            //Player is loaded from the file 
            if(player != null)
            {
                if (player.IsDead())
                {
                    CurrentPlayer = new Player(name, 100);
                }
                else
                {
                    CurrentPlayer = player;
                }
            }
            else   //Player is not found
            {
                CurrentPlayer = new Player(name, 100);
            }            
        }
        //-------------------------------------------------------------------------------
        public static Player Search_Player(string name)
        {
            foreach (Player player in ListPlayers)
            {
                if (String.Compare(player.Name, name, true) == 0)
                {
                    return player;
                }
            }
            return null;
        }
        //-----------------------------------------------------------------------------
        public static void GameOver()
        {
            gameOver = true;
            Console.WriteLine("Game Over !");
        }
        public static void SaveGame()
        {
            CurrentPlayer.Enemy = null;
            Player player = Search_Player(CurrentPlayer.Name);
            //Player is found
            if (player != null)
            {
                if (player.GP < CurrentPlayer.GP)
                {
                    ListPlayers.Remove(player);// remove the existing player with lower score
                    ListPlayers.Add(CurrentPlayer);//save the player of highest score in List
                }
            }
            else   //Player is not found
            {
                ListPlayers.Add(CurrentPlayer);//save the player in List
            }
            //Save the List in XML file
            DataXML.Save("HighScores.xml", GameManager.ListPlayers);
        }
        //--------------------------------------------------------------------------------------------
        public static void StartBattle()
        {
            Console.WriteLine("You are triying to kill the enemy " + GameManager.CurrentPlayer.Enemy.Name);
            GameManager.CurrentPlayer.Attack();//player attack*******
            BattleRounds++;

            System.Threading.Thread.Sleep(1000);//wait for one second

            if (GameManager.CurrentPlayer.Enemy != null &&
                GameManager.CurrentPlayer.Enemy.IsDead())
            {
                Message.Danger("\nYour enemy is dead !");
                BattleRounds = 0;
                GameManager.CurrentPlayer.Enemy = null;
                GameManager.Explore();
            }
            else
            {
                Message.Danger("\nYour enemy is not dead !");

                if (BattleRounds >= MaxRounds)
                {
                    Message.Danger("\nYou panic and run away ....");
                    GameManager.CurrentPlayer.Enemy = null;
                    BattleRounds = 0;
                    GameManager.Explore();
                }
                else
                {
                    //The enemy attack the player
                    if (GameManager.CurrentPlayer.Enemy != null)
                    {
                        GameManager.CurrentPlayer.Enemy.Attack();//monster attack*******
                        Message.Danger("\n" + GameManager.CurrentPlayer.Enemy.Name + " is attacking you ...");
                    }
                }
            }
        }      
        //------------------------------------------------------------------------------------------
        public static void Explore()
        {
            RNG dice = RNG.GetInstance();
            int random = dice.Next(0, 15);
            Console.WriteLine("\nYou are exploring ...");
            switch (random)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    Monster monster = GameFactory.CreateMonster();
                    Message.Danger(monster.Name + " approches ! Prepare for battle !");
                    monster.Target = GameManager.CurrentPlayer;
                    GameManager.CurrentPlayer.Enemy = monster;
                    break;

                case 4:
                    Power magic_potion = GameFactory.CreateHealing();
                    Message.Warning("\nYou collect a Magic Potion !");
                    GameManager.CurrentPlayer.AddPower(magic_potion);
                    break;

                case 5:
                    Message.Warning("\nYou collect a Magic Cape !");
                    Power magic_cape = GameFactory.CreateInvisible();
                    GameManager.CurrentPlayer.AddPower(magic_cape);
                    break;
                case 6:
                    Message.Warning("\nYou collect a Wood Shield !");
                    Power shield = GameFactory.CreateProtect();
                    GameManager.CurrentPlayer.AddPower(shield);
                    break;
                case 7:
                    Message.Warning("\nYou collect a Sleepy Dust !");
                    Power magic_powder = GameFactory.CreateSleepy();
                    GameManager.CurrentPlayer.AddPower(magic_powder);
                    break;
                case 8:
                    Message.Warning("\nYou find a Big Rock !");
                    Weapon rock = GameFactory.CreateRock();
                    GameManager.CurrentPlayer.UpdateWeapon(rock);
                    break;

                case 9:
                    Message.Warning("\nYou find a Torch !");
                    Weapon torch = GameFactory.CreateTorch();
                    GameManager.CurrentPlayer.UpdateWeapon(torch);
                    break;
               
                case 10:
                    Message.Warning("\nYou find a Magic Sword !");
                    Weapon sword = GameFactory.CreateSword();
                    GameManager.CurrentPlayer.UpdateWeapon(sword);
                    break;
                case 11:
                    //Number of Gold Pieces is Random between 20 and 99
                    int random_gp = RNG.GetInstance().Next(50, 500);
                    Message.Warning("\nYou collect " + random_gp + " Gold Pieces !");
                    GameManager.CurrentPlayer.GP += random_gp;
                    break;
                default://12, 13, 14
                    Console.WriteLine("\nYou are looking for gold pieces !");
                    break;
            }
        }
        
        
    }
}
