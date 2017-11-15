using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LesserHealing : Spell
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        public int ID { get; set; }
        public int UniqieID { get; set; }
        public int Manacost { get; set; }

        public SpellType Type { get; set; }

        private int Restore;
        public LesserHealing(int id, string name, string desc, int manacost, SpellType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Manacost = manacost;
            Type = type;
            Restore = 2;
        }

        public void CastOnPlayer()
        {
            int restored;

            if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
            else restored = Ply.MaxHP - Ply.HP;

            Ply.HP += restored;
            Ply.Mana -= Manacost;
        }

        public void CastOnEnemy()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.CurEnemy.HP += Restore;
                Ply.Mana -= Manacost;
            }
        }
    }
}
