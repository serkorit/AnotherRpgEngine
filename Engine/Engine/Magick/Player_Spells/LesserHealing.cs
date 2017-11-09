using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LesserHealing : Spell
    {
        private int Restore;
        public LesserHealing(int id, string name, string desc, int manacost, SpellType type)
            : base(id, name, desc, manacost, type)
        {
            Restore = 2;
        }

        public override void CastOnPlayer()
        {
            int restored;
            
            if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
            else restored = Ply.MaxHP - Ply.HP;

            Ply.Msg("Ты взываешь к силам света. Ты восстановил " + restored);
            Ply.HP += restored;
            Ply.Mana -= Manacost;
        }

        public override void CastOnEnemy()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.Msg("Ты взываешь к силам света воимя " + Ply.CurEnemy.Name + " . " + Ply.CurEnemy.Name + " восстанавливает " + Restore + " здоровья");
                Ply.CurEnemy.HP += Restore;
                Ply.Mana -= Manacost;
            }
        }
    }
}
