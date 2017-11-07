using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class Player : Entity, INotifyPropertyChanged
    {

        public Location CurrentLocation
        {
            get { return CurrentLocation; }
            set { CurrentLocation = value; OnPropetryChanged(nameof(CurrentLocation)); }
        }

        public List<InventoryCollection> Inventory { get; set; }
        public List<QuestCollection> Quests { get; set; }
        public List<SpellsCollection> Spells { get; set; }

        public int Level
        {
            get
            {
                return Exp / 50;
            }
        }
        public int NextLevel
        {
            get
            {
                return 50 * Level;
            }
        }


        public Player(int hp, int stamina, int mana, int gold, int exp)
            :base(hp,stamina,mana,gold,exp)
        {
            CurrentLocation = null;
            Inventory = new List<InventoryCollection>();
            Quests = new List<QuestCollection>();
            Spells = new List<SpellsCollection>();
        }

        public bool HasKeyForLocation(Location location)
        {
            if (location.Key == null)
                return true;
            return Inventory.Exists(i => i.Item.ID == location.Key.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            return Quests.Exists(q => q.Quest.ID == quest.ID);
        }

        public bool ThisQuestCompleted(Quest quest)
        {
            foreach(QuestCollection qc in Quests)
            {
                if (qc.Quest.ID == quest.ID) return qc.IsComplete;
            }
            return false;
        }

        public bool HasQuestItems(Quest quest)
        {
            foreach(QuestConditionsCollection qcc in quest.ItemsNeeded)
            {
                if (!Inventory.Exists(i => i.Item.ID == qcc.Items.ID && i.Quanity >= qcc.Quanity)) return false;
            }

            return true;
        }

        public void RemoveQuestItem(Quest quest)
        {
            foreach(QuestConditionsCollection qcc in quest.ItemsNeeded)
            {
                InventoryCollection item = Inventory.SingleOrDefault(i => i.Item.ID == qcc.Items.ID);

                if (item != null) item.Quanity--;
                if (item.Quanity <= 0) Inventory.Remove(item);
            }
        }

        public void AddReward(Item addedItem)
        {
            if(addedItem is Misc || addedItem is Potion)
            {
                foreach(InventoryCollection i in Inventory)
                {
                    if(i.Item.ID == addedItem.ID)
                    {
                        i.Quanity++;
                        return;
                    }
                }
            }
            if (addedItem is Weapon) Inventory.Add(new InventoryCollection(new Weapon(addedItem as Weapon), 1));
            else Inventory.Add(new InventoryCollection(addedItem, 1));

        }


    }
}
