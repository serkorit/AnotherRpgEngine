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
            Spells.Add(new Fireball(spell_fireball, "Огненный шар", "Deal 6 damage", 15, SpellType.fire));
            Spells.Add(new LesserHealing(spell_lesser_healing, "Малое исцеление", "Restore 2 hp", 5, SpellType.light));
            Spells.Add(new ManaToStamina(spell_mana_to_stamina, "Круговорот энергии", "Transform all mana to stamina", 0, SpellType.psionic));
        }
    }
}
