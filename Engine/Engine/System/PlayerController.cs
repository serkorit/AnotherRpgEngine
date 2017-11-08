using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Ply
    {
        public static Player Player = new Player(10, 15, 20, 0, 0);
        static Location CurrentLocation = Player.CurrentLocation;

        public static void MoveTo(Location newLocation)
        {
            if (HasKeyForLocation(newLocation))
            {

            }
        }

        public static bool HasKeyForLocation(Location location)
        {
            if (location.Key == null)
                return true;
            return Player.Inventory.Exists(i => i.Item.ID == location.Key.ID);
        }

        public static bool HasThisQuest(Quest quest)
        {
            return Player.Quests.Exists(q => q.Quest.ID == quest.ID);
        }

        public static bool ThisQuestCompleted(Quest quest)
        {
            foreach (QuestCollection qc in Player.Quests)
            {
                if (qc.Quest.ID == quest.ID) return qc.IsComplete;
            }
            return false;
        }

        public static bool HasQuestItems(Quest quest)
        {
            foreach (QuestConditionsCollection qcc in quest.ItemsNeeded)
            {
                if (!Player.Inventory.Exists(i => i.Item.ID == qcc.Items.ID && i.Quanity >= qcc.Quanity)) return false;
            }

            return true;
        }

        public static void RemoveQuestItem(Quest quest)
        {
            foreach (QuestConditionsCollection qcc in quest.ItemsNeeded)
            {
                InventoryCollection item = Player.Inventory.SingleOrDefault(i => i.Item.ID == qcc.Items.ID);

                if (item != null) item.Quanity--;
                if (item.Quanity <= 0) Player.Inventory.Remove(item);
            }
        }

        public static void AddReward(Item addedItem)
        {
            if (addedItem is Misc || addedItem is Potion)
            {
                foreach (InventoryCollection i in Player.Inventory)
                {
                    if (i.Item.ID == addedItem.ID)
                    {
                        i.Quanity++;
                        return;
                    }
                }
            }
            if (addedItem is Weapon) Player.Inventory.Add(new InventoryCollection(new Weapon(addedItem as Weapon), 1));
            else Player.Inventory.Add(new InventoryCollection(addedItem, 1));

        }
    } 
}
