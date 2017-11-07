using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.World;

namespace Engine.System.Collections
{
    public class QuestCollection
    {
        public Quest Quest { get; set; }
        public bool IsComplete { get; set; }

        public QuestCollection(Quest quest)
        {
            Quest = quest;
            IsComplete = false;
        }
    }
}
