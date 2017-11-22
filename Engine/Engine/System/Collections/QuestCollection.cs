using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class QuestCollection
    { 
        public Quest Quest;
        public bool IsComplete;

        public QuestCollection(Quest quest)
        {
            Quest = quest;
            IsComplete = false;
        }
    }
}
