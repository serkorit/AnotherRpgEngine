using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        private static void PopulateSpells()
        {
            Spells.Add(new Fireball(spell_fireball, "Fireball", "Deal 4 damage", 15, SpellType.fire));
            Spells.Add(new LesserHealing(spell_lesser_healing, "Lesser healing", "Restore 2 hp", 5, SpellType.light));
        }
    }
}
