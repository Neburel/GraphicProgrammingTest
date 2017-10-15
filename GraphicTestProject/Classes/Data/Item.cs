using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTestProject.Classes.Data
{
    class Item : Entity
    {
        // Attribute declaration
        private String itemName;
        private String itemDesc;

        // Getter & Setter
        protected String ItemName
        {
            get { return itemName;  }
            set { itemName = value; }
        }

        protected String ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }

        // Constructor
        public Item(int id, String name, String desc) :  base(id, Entity.Type.Item)
        {
            this.itemName = name;
            this.itemDesc = desc;
        }
    }
}
