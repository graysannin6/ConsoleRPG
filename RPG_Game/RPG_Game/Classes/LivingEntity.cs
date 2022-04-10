using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public abstract class LivingEntity: ILivingEntity
    {
        private string name;
        private int hp;

        protected LivingEntity() { }
        protected LivingEntity(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        public string Name { get => name; set => name = value; }
        public int HP { get => hp; set => hp = value; }

        public bool IsDead()
        {
           return this.hp <= 0;
        }
        public virtual void ReceiveDamage(int damage) 
        {
            this.hp -= damage;
        }

        public abstract void Attack();
    }
}
