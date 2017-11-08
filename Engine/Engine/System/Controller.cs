using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Entity> Entities = new List<Entity>();
        public static readonly List<Spell> Spells = new List<Spell>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Quest> Quests = new List<Quest>();

        public static void PopulateWorld()
        {
            PopulateEntities();
            PopulateItems();
            PopulateQuests();
        }

        public static Item ItemParse(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                    return item;
            }

            return null;
        }
        public static Enemy EnemyParse(int id)
        {
            foreach (Enemy enemy in Entities)
            {
                if (enemy.ID ==  id)
                    return enemy;
            }

            return null;
        }
        public static Entity EntityParse(int id)
        {
            foreach (Entity entity in Entities)
            {
                if (entity.ID == id)
                    return entity;
            }

            return null;
        }
        public static Quest QuestParse(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                    return quest;
            }

            return null;
        }
        public static Location LocationParse(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                    return location;
            }

            return null;
        }
        public static Spell SpellParse(int id)
        {
            foreach (Spell spell in Spells)
            {
                if (spell.ID == id)
                    return spell;
            }

            return null;
        }
    }
}
