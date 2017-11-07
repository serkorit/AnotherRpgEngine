using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Magick;

namespace Engine.Items
{
    public class Spellbook : Item
    {
        public List<Spell> Spells { get; set; }
        public Spellbook(int id, string name, string desc)
            :base(id,name,desc)
        {
            Spells = new List<Spell>();
        }
    }
}
