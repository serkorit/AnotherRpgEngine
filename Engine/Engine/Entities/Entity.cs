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
    public abstract class Entity : INotifyPropertyChanged
    {
        

        public string Name { get; set; }
        public string Desc { get; set; }
        public int ID { get; private set; }
        public int UniqueID { get; private set; }
        public EntityType Type { get; private set; }

        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Stamina { get; set; }
        public int MaxStamina { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }

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

        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropetryChanged(string propName)
        {
            return;
        }
    }
}
