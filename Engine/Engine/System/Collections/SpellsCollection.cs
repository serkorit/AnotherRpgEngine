using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class SpellsCollection : INotifyPropertyChanged
    {
        public Spell Spell
        {
            get { return Spell; }
            set
            {
                Spell = value;
                OnPropetryChanged(nameof(Spell));
            }
        }

        public SpellsCollection(Spell spell)
        {
            Spell = spell;
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
