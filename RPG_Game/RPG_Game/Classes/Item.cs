using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Classes
{
    public class Item
    {
        private string name;
        private int price;

        public Item()
        {
            this.Name = "";
            this.Price = 0;
        }

        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
    }
}
