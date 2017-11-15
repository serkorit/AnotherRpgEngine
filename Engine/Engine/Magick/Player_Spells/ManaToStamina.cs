using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ManaToStamina : Spell
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        public int ID { get; set; }
        public int UniqieID { get; set; }
        public int Manacost { get; set; }

        public SpellType Type { get; set; }

        public ManaToStamina(int id, string name, string desc, int manacost, SpellType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Manacost = manacost;
            Type = type;
        }

        public void CastOnPlayer()
        {
            int transfered = Ply.Mana;
            Ply.Stamina += transfered;
            Ply.Mana = 0;
            Ply.Msg("Ты присел подумать... Твоя энергия превращается в энергию? Ты восстановил " + transfered + " стамины.");
        }

        public void CastOnEnemy()
        {
            if (Ply.CurEnemy != null)
            {
                Ply.Msg("Жаль, что ты не псионик.");
            }
            
        }
    }
}
