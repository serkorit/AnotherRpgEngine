using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class EnAbilitiesCollection
    {
        public EnemyAbility Ability;
        public int Cooldown;

        public EnAbilitiesCollection(EnemyAbility ability, int cooldown)
        {
            Ability = ability;
            Cooldown = cooldown;
        }
    }
}
