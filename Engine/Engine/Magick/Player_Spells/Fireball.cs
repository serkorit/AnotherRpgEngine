using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Fireball : Spell
    {
        int Damage;
        public Fireball(int id, string name, string desc, int manacost, SpellType type)
            : base(id, name, desc, manacost, type)
        {
            Damage = 4;
        }

        public override void CastOnPlayer()
        {
            Ply.HP -= Damage;
            Ply.Mana -= Manacost;
        }

        public override void CastOnEnemy()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.CurEnemy.HP -= Damage;
                Ply.Mana = Manacost;
            }
        }
    }
}
