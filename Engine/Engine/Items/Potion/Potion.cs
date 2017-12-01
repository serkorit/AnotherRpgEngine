using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public delegate void OnDrink();
    public delegate void OnThrow();

    public class Potion : Item
    {
        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AvaibleStacks { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
        public string SellText
        {
            get { return Name + " цена: " + SellPrice; }
            set { }
        }
        public string BuyText
        {
            get { return Name + " цена: " + BuyPrice; }
            set { }
        }

        private int defaultStacks;
        public OnDrink Drink;
        public OnThrow Throw;

        public Potion(int id, string name, string desc, int avaible, int sell, int buy)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            AvaibleStacks = avaible;
            defaultStacks = AvaibleStacks;
            SellPrice = sell;
            BuyPrice = buy;
        }
        public Potion(int id, string name, string desc, int avaible
            ,OnDrink dr, OnThrow th,int sell, int buy)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            AvaibleStacks = avaible;
            defaultStacks = AvaibleStacks;
            Drink = dr;
            Throw = th;
            Drink += RemoveQuanity;
            Throw += RemoveItem;
            SellPrice = sell;
            BuyPrice = buy;
        }

        private void RemoveQuanity()
        {
            Ply.RemoveQuanity(this);
        }

        private void RemoveItem()
        {
            Ply.RemoveItem(this);
        }

        public void RestoreStacks()
        {
            AvaibleStacks = defaultStacks;
        }
    }
}
