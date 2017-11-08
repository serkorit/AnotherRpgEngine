using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HealingPotion : Potion
    {
        public int Restore { get; set; }
        private int restored;

        public HealingPotion(int id, string name, string desc, int avaible, int restore)
            : base(id, name, desc, avaible)
        {
            Restore = restore;
        }

        public override void Drink()
        {
            if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
            else restored = Ply.MaxHP - Ply.HP;

            Ply.HP += restored;
            Ply.RemoveQuanity(this);
        }

        public override void Throw()
        {
            if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
            else restored = Ply.MaxHP - Ply.HP;

            Ply.HP += restored / 2;
            Ply.CurEnemy.HP += restored/ 2;

            Ply.RemoveItem(this);
        }
    }
}
