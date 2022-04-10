using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public enum PowerType { Healing, Invisible, Protect, Sleepy }

    public class Power : Item
    {
        private int min_XP;
        private PowerType type;

        public Power():base() { }            
        
        public Power(string name, int price, PowerType type, int min_xp) : base(name, price) 
        {
            this.Type = type;
            Min_XP = min_xp;
            
        }

        public int Min_XP { get => min_XP; set => min_XP = value; }
        public PowerType Type { get => type; set => type = value; }
    }
}
