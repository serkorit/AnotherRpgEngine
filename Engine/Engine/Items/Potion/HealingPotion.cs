using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HealingPotion : Potion
    {
        public int UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AvaibleStacks { get; set; }

        public int Restore { get; set; }
        private int restored;
        private int defaultStacks;

        public HealingPotion(int id, string name, string desc, int avaible, int restore)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqueID = IDGenerator.GenerateNewID();
            AvaibleStacks = avaible;
            Restore = restore;
            defaultStacks = AvaibleStacks;
        }

        public HealingPotion(HealingPotion potion)
        {
            Name = potion.Name;
            Desc = potion.Desc;
            ID = potion.ID;
            UniqueID = IDGenerator.GenerateNewID();
            AvaibleStacks = potion.AvaibleStacks;
            Restore = potion.Restore;
        }

        public void Drink()
        {
            Ply.Msg("Ты пьешь " + this.Name + "...");
            if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
            else restored = Ply.MaxHP - Ply.HP;

            Ply.Msg("Ты восстановил " + restored);
            Ply.HP += restored;
            Ply.RemoveQuanity(this);
        }

        public void Throw()
        {
            Ply.Msg("Ты кидаешь " + this.Name);
            if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
            else restored = Ply.MaxHP - Ply.HP;

            Ply.HP += restored / 2;
            Ply.Msg("Ты восстановил " + restored/2);
            if(Ply.CurEnemy != null)
            {
                Ply.CurEnemy.HP += restored / 2;
                Ply.Msg("Противник восстановил " + restored / 2);
            }
            

            Ply.RemoveItem(this);
        }

        public void RestoreStacks()
        {
            AvaibleStacks = defaultStacks;
        }
    }
}
