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
            Ply.Msg("Ты решил выпить " + this.Name + ". Твое горло горит. Ты получаешь " + Damage/2 + " единиц урона.");
            Ply.HP -= Damage/2;
            Ply.RemoveQuanity(this);
        }

        public override void Throw()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.Msg("Ты кидаешь " + this.Name + "." + Ply.CurEnemy.Name + " получает " + Damage + " единиц урона." );
                Ply.CurEnemy.HP -= Damage;
            }
            Ply.RemoveItem(this);
        }
    }
}
