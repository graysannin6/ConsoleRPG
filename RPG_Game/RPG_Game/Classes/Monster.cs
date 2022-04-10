using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public class Monster: LivingEntity
    {
        private int ap;
        private int rxp;
        private Player target;

        public Monster():base() { }
        public Monster(string name, int hp, int ap, int rxp) : base(name, hp) 
        {
            this.AP = ap;
            this.RXP = rxp;
            this.Target = null;
        }

        public int AP { get => ap; set => ap = value; }
        public int RXP { get => rxp; set => rxp = value; }
        public Player Target { get => target; set => target = value; }

        public override void Attack() 
        {
            int random_damage = RNG.GetInstance().Next(0, this.AP);
            this.Target.ReceiveDamage(random_damage);
        }
    }
}
