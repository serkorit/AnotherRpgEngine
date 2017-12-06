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
        private int _durability;
        internal string _name;

        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public WeaponType Type { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Durability { get { return _durability; } set { DurabilityCheck(value); } }
        public int StaminaCost { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }

        public string SellText { get { return Name + " цена: " + SellPrice; }
            set { } }
        public string BuyText { get { return Name + " цена: " + BuyPrice; }
            set {} }

        public Weapon(int id, string name, string desc, int mindmg, int maxdmg
            , int durability, int staminacost, WeaponType type, int sell, int buy)
        {
            _name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            MinDamage = mindmg;
            MaxDamage = maxdmg;
            Durability = durability;
            Type = type;
            StaminaCost = staminacost;
            SellPrice = sell;
            BuyPrice = buy;
            Name = _name + "(" + MinDamage + " - " + MaxDamage + "," + Durability + ")";
        }

        public Weapon(Weapon weapon)
        {
            _name = weapon._name;
            Desc = weapon.Desc;
            ID = weapon.ID;
            UniqueID = IDGenerator.GenerateNewID();
            MinDamage = weapon.MinDamage;
            MaxDamage = weapon.MaxDamage;
            Durability = weapon.Durability;
            Type = weapon.Type;
            StaminaCost = weapon.StaminaCost;
            SellPrice = weapon.SellPrice;
            BuyPrice = weapon.BuyPrice;
            Name = _name + "(" + MinDamage + " - " + MaxDamage + "," + Durability + ")";
        }

        private void DurabilityCheck(int n)
        {
            _durability = n;
            Name = _name + "(" + MinDamage + " - " + MaxDamage + "," + Durability + ")";
            if (_durability <= 0)
            {
                Ply.Msg("Оружие ломается...");
                Ply.RemoveItem(this);
            }
        }
    }

}
