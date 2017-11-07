using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel

namespace Engine
{
    public class QuestCollection : INotifyPropertyChanged
    {
        public Quest Quest
        {
            get { return Quest; }
            set
            {
                Quest = value;
                OnPropetryChanged(nameof(Quest));
            }
        }
        public bool IsComplete
        {
            get { return IsComplete; }
            set
            {
                IsComplete = value;
                OnPropetryChanged(nameof(IsComplete));
            }
        }

        public QuestCollection(Quest quest)
        {
            Quest = quest;
            IsComplete = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetryChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
