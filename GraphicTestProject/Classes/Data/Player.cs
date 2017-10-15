using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTestProject.Classes.Data
{
    class Player : Entity
    {
        // Attribute declaration
        private String playerName;
        private int hp;
        private int mp;
        private int xp;
        private Item[] inventory; //TODO: Anzahl beachten

        // Getter & Setter
        internal String PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        internal int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        internal int Mp
        {
            get { return mp; }
            set { mp = value; }
        }
        internal int Xp
        {
            get { return xp; }
            set { xp = value; }
        }

        // Inventory Methods
        protected Item getItemFromInventory(int index)
        {
            return inventory[index];
        }

        // Constructor
        public Player(int id, String name) : base(id, Type.Player)
        {
            this.playerName = name;
            this.hp = 100;
            this.mp = 100;
            this.xp = 0;
            this.inventory = new Item[0];
        }
    }
}
