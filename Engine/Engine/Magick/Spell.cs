using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum SpellType
    {
        fire,
        water,
        air,
        lightning,
        earth,

        psionic,
        light,
        dark,

        physics,
        other
    }
    public class Spell
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        public int ID { get; set; }
        public int UniqieID { get; set; }
        public int Manacost { get; set; }

        public SpellType Type { get; set; }

        public Spell(int id, string name, string desc, int manacost, SpellType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Manacost = manacost;
            Type = type;
        }

        public virtual void CastOnPlayer()
        {
            return;
        }
        public virtual void CastOnEnemy()
        {
            return;
        }
    }
}
