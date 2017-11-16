using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public delegate void OnPlayer();
    public delegate void OnEnemy();
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
        other,
        test_spell
    }

    public class Spell
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        public int ID { get; set; }
        public int UniqieID { get; set; }
        public int Manacost { get; set; }

        public SpellType Type { get; set; }
        public OnPlayer CastOnPlayer { get; set; }
        public OnEnemy CastOnEnemy { get; set; }

        public Spell(int id, string name, string desc, int manacost, SpellType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Manacost = manacost;
            Type = type;
            CastOnEnemy = Default;
            CastOnPlayer = Default;
        }

        public Spell(int id, string name, string desc, int manacost, 
            SpellType type, OnPlayer plfunc, OnEnemy enfunc)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Manacost = manacost;
            Type = type;
            CastOnEnemy = enfunc;
            CastOnPlayer = plfunc;
            CastOnPlayer += SubstractMana;
            CastOnEnemy += SubstractMana;
        }

        private void SubstractMana()
        {
            Ply.Mana -= Manacost;
        }
        private void Default()
        {
            Ply.Msg("Ты не можешь этого сделать.");
        }
    }
}
