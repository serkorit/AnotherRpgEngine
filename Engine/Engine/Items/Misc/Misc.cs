using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Items
{
    public enum MiscType
    {
        questitem,
        junk,
        key,
        material
    }

    public class Misc : Item
    {
        public MiscType Type { get; set; }

        public Misc(int id, string name, string desc, MiscType type)
            : base(id, name, desc)
        {
            Type = type;
        }
    }
}
