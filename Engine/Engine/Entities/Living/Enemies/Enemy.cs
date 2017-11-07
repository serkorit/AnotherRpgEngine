using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public enum EnemyType
    {
        world,
        dungeon,
        miniboss,
        boss,
        boss_summoned
    }

    public class Enemy : Entity
    {


        public Enemy(string name, string desc, int id, int mindmg,
            int maxdmg, int hp, int stamina, int mana, int gold, int exp)
            : base(name, desc, id, mindmg, maxdmg, hp, stamina, mana, gold, exp)
        {

        }
    
    }
}
