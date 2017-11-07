using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class InventoryCollection : INotifyPropertyChanged
    {
        public Item Item
        {
            get { return Item; }
            set
            {
                Item = value;
                OnPropetryChanged(nameof(Item));
            }
        }
        public int Quanity
        {
            get { return Quanity; }
            set
            {
                Quanity = value;
                OnPropetryChanged(nameof(Quanity));
            }
        }

        public InventoryCollection(Item item, int quanity)
        {
            Item = item;
            Quanity = quanity;
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
