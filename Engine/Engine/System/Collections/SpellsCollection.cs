using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
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
