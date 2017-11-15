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
    public interface Spell
    {
        string Name { get; set; }
        string Desc { get; set; }

        int ID { get; set; }
        int UniqieID { get; set; }
        int Manacost { get; set; }

        SpellType Type { get; set; }

        void CastOnPlayer();
        void CastOnEnemy();
    }
}
