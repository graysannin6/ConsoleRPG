using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public class Weapon: Item
    {
        private int min_Damage;
        private int max_Damage;

        public Weapon():base() { }

        public Weapon(string name, int price, int min, int max) : base(name, price) 
        {
            this.Min_Damage = min;
            this.Max_Damage = max;
        }

        public int Min_Damage { get => min_Damage; set => min_Damage = value; }
        public int Max_Damage { get => max_Damage; set => max_Damage = value; }
    }
}
