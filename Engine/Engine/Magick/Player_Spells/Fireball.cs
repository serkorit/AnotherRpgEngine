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
            Ply.Msg("Ты направил палец на себя. Ты видишь яркую вспышку. Ты получаешь " + Damage + " единиц урона".);
            Ply.HP -= Damage;
            Ply.Mana -= Manacost;
        }

        public override void CastOnEnemy()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.Msg("Ты выпускаешь огненный шар в " + Ply.CurEnemy.Name + " . " + Ply.CurEnemy.Name + " получает " + Damage + " единиц урона.");
                Ply.CurEnemy.HP -= Damage;
                Ply.Mana = Manacost;
            }
        }
    }
}
