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
        public Spell Spell { get; set { Spell = value; OnPropetryChanged(nameof(Spell)); } }

        public SpellsCollection(Spell spell)
        {
            Spell = spell;
        }
    }
}
