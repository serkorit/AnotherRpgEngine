using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class FirePotion : Potion
    {
        public int Damage { get; set; }

        public FirePotion(int id, string name, string desc, int avaible, int damage)
            : base(id, name, desc, avaible)
        {
            Damage = damage;
        }

        public override void Drink()
        {
            Ply.HP -= Damage/2;
            Ply.RemoveQuanity(this);
        }

        public override void Throw()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.CurEnemy.HP -= Damage;
            }
            Ply.RemoveItem(this);
        }
    }
}
