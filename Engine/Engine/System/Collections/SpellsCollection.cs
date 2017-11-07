using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Magick;

namespace Engine.System.Collections
{
    public class SpellsCollection
    {
        public Spell Spell { get; set; }

        public SpellsCollection(Spell spell)
        {
            Spell = spell;
        }
    }
}
