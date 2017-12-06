using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Spellbook : Item
    {
        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<Spell> Spells { get; set; }
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
        public Spellbook(int id, string name, string desc)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            Spells = new List<Spell>();
        }
    }
}
