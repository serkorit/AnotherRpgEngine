using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Item
    {
        public int UniqueID { get; protected set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public Item(int id, string name, string desc)
        {
            ID = id;
            UniqueID = 0;
            Name = name;
            Desc = desc;
        }
    }
}
