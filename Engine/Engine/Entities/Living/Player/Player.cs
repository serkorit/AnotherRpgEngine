using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.World;

namespace Engine.Entities
{
    public class Player : Entity
    {

        public Player(int hp, int stamina, int mana, int gold, int exp)
            :base(hp,stamina,mana,gold,exp)
        {

        }

        protected override void OnPropetryChanged(string propName)
        {
            
            base.OnPropetryChanged(propName);
        }
    }
}
