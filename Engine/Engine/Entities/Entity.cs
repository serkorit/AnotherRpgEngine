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
        public List<EffectsCollection> Effects {get;set;}
        public void AddEffect(EffectsCollection effect)
        {
            if(Effects.Count == 0)
            {
                Effects.Add(effect);
                return;
            }
            foreach (EffectsCollection ef in Effects)
            {
                if (ef.Effect.ID == effect.Effect.ID)
                {
                    ef.AddStack();
                    return;
                }
            }
            Effects.Add(effect);
        }
        public void RemoveEffect(EffectsCollection effect)
        {
            Effects.Remove(effect);
        }

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
            Effects = new List<EffectsCollection>();
        }

        //Player Constructor
        public Entity(int hp, int stamina, int mana, int gold, int exp)
        {
            MaxHP = hp; HP = MaxHP;
            MaxMana = mana; Mana = MaxMana;
            MaxStamina = stamina; Stamina = MaxStamina;
            Gold = gold;
            Exp = exp;
            Effects = new List<EffectsCollection>();
        }

        //...
        public Entity()
        {
            UniqueID = IDGenerator.GenerateNewID();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetryChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
