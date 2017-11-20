using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum AbilityCategory
    {
        attack,
        defend,
        heal,
        effect
    }
    public class EnAbilitiesCollection
    {
        public EnemyAbility Ability;
        public AbilityCategory Category;
        public int Cooldown;
        public int ActiveCooldown;

        public EnAbilitiesCollection(EnemyAbility ability, int cooldown, int defaultcooldown)
        {
            Ability = ability;
            Cooldown = cooldown;
            ActiveCooldown = defaultcooldown;
        }
    }
}
