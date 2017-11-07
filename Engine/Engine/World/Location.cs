using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public int UniqueID { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }

        public Item Key { get; set; }

        public List<Location> NearestLocations { get; set; }
        public List<Quest> QuestsHere { get; set; }
        public List<Enemy> EnemiesHere { get; set; }

        public Location(int id, string name, string desc)
        {
            ID = id;
            Name = name;
            Desc = desc;
            UniqueID = IDGenerator.GenerateNewID();
            Key = null;
            NearestLocations = new List<Location>();
            QuestsHere = new List<Quest>();
            EnemiesHere = new List<Enemy>();
        }

    }
}
