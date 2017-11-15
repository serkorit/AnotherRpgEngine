using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum EntityType
    {
        player,
        enemy,
        npc,
        obj
    }
    public abstract class Entity
    {
        

        public string Name { get; set; }
        public string Desc { get; set; }
        public int ID { get; protected set; }
        public int UniqueID { get; private set; }
        public EntityType Type { get; private set; }

        public int MinDamage;
        public int MaxDamage;
        public int HP;
        public int MaxHP;
        public int Mana;
        public int MaxMana;
        public int Stamina;
        public int MaxStamina;
        public int Gold;
        public int Exp;

        //Enemy constructor
        public Entity(string name, string desc, int id, int mindmg, 
            int maxdmg, int hp, int stamina, int mana, int gold, int exp)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            Type = EntityType.enemy;
            MinDamage = mindmg;
            MaxDamage = maxdmg;
            MaxHP = hp; HP = MaxHP;
            MaxMana = mana; Mana = MaxMana;
            MaxStamina = stamina; MaxStamina = Stamina;
            Gold = gold;
            Exp = exp;
        }

        //Player Constructor
        public Entity(int hp, int stamina, int mana, int gold, int exp)
        {
            MaxHP = hp; HP = MaxHP;
            MaxMana = mana; Mana = MaxMana;
            MaxStamina = stamina; Stamina = MaxStamina;
            Gold = gold;
            Exp = exp;
        }

        //...
        public Entity()
        {
            UniqueID = IDGenerator.GenerateNewID();
        }
       
    }
}
