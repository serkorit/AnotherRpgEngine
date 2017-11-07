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
        public int HP { get { return HP; } set { HP = value; OnPropetryChanged(nameof(HP)); } }
        public int MaxHP { get { return MaxHP; } set { MaxHP = value; OnPropetryChanged(nameof(MaxHP)); } }
        public int Mana { get { return Mana; } set { Mana = value; OnPropetryChanged(nameof(Mana)); } }
        public int MaxMana { get { return MaxMana; } set { MaxMana = value; OnPropetryChanged(nameof(MaxMana)); } }
        public int Stamina { get { return Stamina; } set { Stamina = value; OnPropetryChanged(nameof(Stamina)); } }
        public int MaxStamina { get { return MaxStamina; } set { MaxStamina = value; OnPropetryChanged(nameof(MaxStamina)); } }
        public int Gold { get { return Gold; } set { Gold = value; OnPropetryChanged(nameof(Gold)); } }
        public int Exp { get { return Exp; } set { Exp = value; OnPropetryChanged(nameof(Exp)); } }

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
        protected void OnPropetryChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
