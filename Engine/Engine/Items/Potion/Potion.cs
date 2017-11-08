using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Potion : Item
    {
        public int AvaibleStacks { get; set; }

        public Potion(int id, string name, string desc, int avaible)
            : base(id, name, desc)
        {
            AvaibleStacks = avaible;
        }

        public virtual void Drink()
        {
            Ply.RemoveItem(this);
        }

        public virtual void Throw()
        {
            Ply.RemoveItem(this);
        }
    }
}
