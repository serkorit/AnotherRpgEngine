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

        private int defaultStacks;
        public FirePotion(int id, string name, string desc, int avaible, int damage)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            AvaibleStacks = avaible;
            Damage = damage;
            defaultStacks = AvaibleStacks;
        }

        public void Drink()
        {
            Ply.Msg("Ты решил выпить " + this.Name + ". Твое горло горит. Ты получаешь " + Damage/2 + " единиц урона.");
            Ply.HP -= Damage/2;
            Ply.RemoveQuanity(this);
        }

        public void Throw()
        {
            if (Ply.CurEnemy != null)
            {
                Ply.Msg("Ты кидаешь " + this.Name + "." + Ply.CurEnemy.Name + " получает " + Damage + " единиц урона.");
                Ply.CurEnemy.HP -= Damage;
            }
            else Ply.Msg("Ты кидаешь " + this.Name + "... Но тут никого нет...");
            Ply.RemoveItem(this);
        }

        public void RestoreStacks()
        {
            AvaibleStacks = defaultStacks;
        }
    }
}
