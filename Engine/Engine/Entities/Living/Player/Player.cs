using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Entity
    {

        public Location CurrentLocation { get; set; }

        public List<InventoryCollection> Inventory { get; set; }
        public List<QuestCollection> Quests { get; set; }
        public List<SpellsCollection> Spells { get; set; }

        public int Level { get { return ((Exp / 50)); } }
        public int NextLevel { get { return 50 * Level; } }


        public Player(int hp, int stamina, int mana, int gold, int exp)
            :base(hp,stamina,mana,gold,exp)
        {
            CurrentLocation = null;
            Inventory = new List<InventoryCollection>();
            Quests = new List<QuestCollection>();
            Spells = new List<SpellsCollection>();
        }

        protected override void OnPropetryChanged(string propName)
        {
            
            base.OnPropetryChanged(propName);
        }
    }
}
