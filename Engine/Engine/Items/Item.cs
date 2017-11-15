using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface Item
    {
        int UniqueID { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string Desc { get; set; }
    }
}
