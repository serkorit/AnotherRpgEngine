using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Fireball : Spell
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        public int ID { get; set; }
        public int UniqieID { get; set; }
        public int Manacost { get; set; }

        public SpellType Type { get; set; }

        private int Damage;
        public Fireball(int id, string name, string desc, int manacost, SpellType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Manacost = manacost;
            Type = type;
            Damage = 4;
        }

        public void CastOnPlayer()
        {
            Ply.HP -= Damage;
            Ply.Mana -= Manacost;
        }

        public void CastOnEnemy()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.CurEnemy.HP -= Damage;
                Ply.Mana = Manacost;
            }
        }
    }
}
