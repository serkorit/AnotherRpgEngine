using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Items;

namespace Engine.System.Collections
{
    public class LootCollection
    {
        public Item Item { get; set; }
        public int DropChance { get; set; }

        public LootCollection(Item item, int dropchance)
        {
            Item = item;
            DropChance = dropchance;
        }
    }
}
