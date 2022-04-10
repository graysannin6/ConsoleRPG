using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public class Dragon : Monster
    {
        private int rgp;
        public Dragon() : base() { }

        public Dragon(string name, int hp, int ap, int rxp) : base(name,hp,ap,rxp)
        {
            int random = RNG.GetInstance().Next(1000, 10000);
            this.rgp = random;
        }
        public int RGP { get => rgp; set => rgp = value; }
    }
}
