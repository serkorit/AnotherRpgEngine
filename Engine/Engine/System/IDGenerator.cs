using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Static class which generates new id for world database
    /// </summary>
    public static class IDGenerator
    {
        static int nextID = 0; // ID

        /// <summary>
        /// Generate new unique id
        /// </summary>
        /// <returns>new unique id</returns>
        public static int GenerateNewID()
        {
            nextID++;

            return nextID;
        }
    }
}