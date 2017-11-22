using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class InventoryCollection
    {
        public Item Item;
        public int Quanity;

        public InventoryCollection(Item item, int quanity)
        {
            Item = item;
            Quanity = quanity;
        }

    }
}
