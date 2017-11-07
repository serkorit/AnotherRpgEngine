using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Controller
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Entity> Entities = new List<Entity>();
        public static readonly List<Spell> Spells = new List<Spell>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Quest> Quests = new List<Quest>();

        public static void PopulateWorld()
        {

        }
    }
}
