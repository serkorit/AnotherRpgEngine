using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int UniqueID { get; protected set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public Item(int id, string name, string desc)
        {
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            Name = name;
            Desc = desc;
        }

        public Item(Item weapon)
        {
            Name = weapon.Name;
            UniqueID = IDGenerator.GenerateNewID();
            Desc = weapon.Desc;
            ID = weapon.ID;
        }

        public Item()
        {

        }
    }
}
