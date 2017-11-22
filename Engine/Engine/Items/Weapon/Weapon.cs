using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum WeaponType
    {
        sword,
        greatsword,
        dagger,
        axe,
        spear
    }

    public class Weapon : Item
    {
        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public WeaponType Type { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Durability { get; set; }
        public int StaminaCost { get; set; }

        public Weapon(int id, string name, string desc, int mindmg, int maxdmg
            , int durability, int staminacost, WeaponType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            MinDamage = mindmg;
            MaxDamage = maxdmg;
            Durability = durability;
            Type = type;
            StaminaCost = staminacost;
        }

        public Weapon(Weapon weapon)
        {
            Name = weapon.Name;
            Desc = weapon.Desc;
            ID = weapon.ID;
            UniqueID = IDGenerator.GenerateNewID();
            MinDamage = weapon.MinDamage;
            MaxDamage = weapon.MaxDamage;
            Durability = weapon.Durability;
            Type = weapon.Type;
            StaminaCost = weapon.StaminaCost;
        }
    }

}
