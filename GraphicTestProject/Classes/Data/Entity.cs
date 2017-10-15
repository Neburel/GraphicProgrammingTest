using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTestProject.Classes.Data
{
    abstract class Entity
    {
        protected int id;
        protected Type type;

        public Entity(int id, Type type)
        {
            this.id = id;
            this.type = type;
        }

        public enum Type
        {
            Player,
            Enemy,
            Chest,
            Item
        }
    }
}
