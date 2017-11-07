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

    public class Enemy : IEntity
    {

    }
}
