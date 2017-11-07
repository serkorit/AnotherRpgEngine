using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Items;

namespace Engine.System.Collections
{
    class QuestConditionsCollection
    {
        public List<Item> Items { get; set; }
        public List<int> Quanity { get; set; }

        public QuestConditionsCollection(List<Item> items, List<int> quanity)
        {
            Items = items;
            Quanity = quanity;
        }
    }
}
