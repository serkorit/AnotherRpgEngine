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
        public WeaponType Type { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Durability { get; set; }

        public Weapon(int id, string name, string desc, int mindmg, int maxdmg
            , int durability, WeaponType type) : base(id,name,desc)
        {
            MinDamage = mindmg;
            MaxDamage = maxdmg;
            Durability = durability;
            Type = type;
        }

        public Weapon(Weapon weapon) : base(weapon.ID, weapon.Name, weapon.Desc)
        {
            MinDamage = weapon.MinDamage;
            MaxDamage = weapon.MaxDamage;
            Durability = weapon.Durability;
            Type = weapon.Type;
        }
    }

}
