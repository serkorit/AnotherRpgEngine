using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public enum Chest_Type
    {
        wooden, // key not required
        iron, // key not required
        golden,
        secret,
        boss
    }

    public class Chest : Entity
    {
    }
}
