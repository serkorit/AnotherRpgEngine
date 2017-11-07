using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Ply
    {
        public static Player Player = new Player(10, 15, 20, 0, 0);
        static Location CurrentLocation = Player.CurrentLocation;

        public static void MoveTo(Location newLocation)
        {
            if (Player.HasKeyForLocation(newLocation))
            {

            }
        }
    } 
}
