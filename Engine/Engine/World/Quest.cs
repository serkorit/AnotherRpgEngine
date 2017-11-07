using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public int UniqueID { get; private set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int RewardGold { get; set; }
        public int RewardExp { get; set; }
        public List<Item> RewardItems { get; set; }

        public List<QuestConditionsCollection> ItemsNeeded { get; set; }

        public Quest(int id, string name, string desc, int exp, int gold)
        {
            ID = id;
            Name = name;
            Desc = desc;
            RewardGold = gold;
            RewardExp = exp;
            RewardItems = new List<Item>();
            ItemsNeeded = new List<QuestConditionsCollection>();
        }
    }
}
