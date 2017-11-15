using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class FirePotion : Potion
    {
        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AvaibleStacks { get; set; }
        public int Damage { get; set; }

        public FirePotion(int id, string name, string desc, int avaible, int damage)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            AvaibleStacks = avaible;
            Damage = damage;
        }

        public void Drink()
        {
            Ply.HP -= Damage/2;
            Ply.RemoveQuanity(this);
        }

        public void Throw()
        {
            if(Ply.CurEnemy != null)
            {
                Ply.CurEnemy.HP -= Damage;
            }
            Ply.RemoveItem(this);
        }
    }
}
