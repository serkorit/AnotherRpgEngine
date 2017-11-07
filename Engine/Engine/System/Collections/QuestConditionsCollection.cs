﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Items;

namespace Engine.System.Collections
{
    public class QuestConditionsCollection
    {
        public Item Items { get; set; }
        public int Quanity { get; set; }

        public QuestConditionsCollection(Item items, int quanity)
        {
            Items = items;
            Quanity = quanity;
        }
    }
}
