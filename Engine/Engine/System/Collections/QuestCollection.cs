using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class QuestCollection : INotifyPropertyChanged
    {
        public Quest Quest { get; set { Quest = value; OnPropetryChanged(nameof(Quest)); } }
        public bool IsComplete { get; set { IsComplete = value; OnPropetryChanged(nameof(IsComplete)); } }

        public QuestCollection(Quest quest)
        {
            Quest = quest;
            IsComplete = false;
        }
    }
}
