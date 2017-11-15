using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
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
        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public MiscType Type { get; set; }

        public Misc(int id, string name, string desc, MiscType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            Type = type;
        }
    }
}
