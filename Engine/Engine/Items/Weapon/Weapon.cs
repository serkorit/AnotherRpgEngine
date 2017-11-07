using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Items
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
    }
}
