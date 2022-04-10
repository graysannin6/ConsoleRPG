using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public static class GameFactory
    {
       
        public static Monster CreateMonster()
        {
            int random = RNG.GetInstance().Next(0, 100);
            //10% of chance to meet a Dragon
            if(random <= 10)
            {
                return new Dragon("Dragon", 120, 40, 3);
            }
            else //30% of chance to meet a Ogre
            if (random > 10 && random <= 40)
            {
                return new Monster("Ogre", 80, 20, 2);
            }
            //60% of chance to meet a Goblin
            return new Monster("Goblin", 40, 10, 1);
        }
        public static Power CreateHealing()
        {
            return new Power("Magic Potion", 200, PowerType.Healing, 2);
        }
        public static Power CreateInvisible()
        {
            return new Power("Magic Cape", 300, PowerType.Invisible, 3);
        }
        public static Power CreateProtect()
        {
            return new Power("Wood Shield", 100, PowerType.Protect, 1);
        }
        public static Power CreateSleepy()
        {
            return new Power("Sleepy Dust", 600, PowerType.Sleepy, 6);
        }
        public static Weapon CreateRock()
        {
            return new Weapon("Big rock", 100, 20, 30);
        }
        public static Weapon CreateTorch()
        {
            return new Weapon("Torch", 300, 35, 45);
        }
        public static Weapon CreateSword()
        {
            return new Weapon("Magic Sword", 500, 50, 60);
        }
        public static Weapon CreateStick()
        {
            return new Weapon("Wood Stick", 0, 5, 15);
        }
      
    }
}
