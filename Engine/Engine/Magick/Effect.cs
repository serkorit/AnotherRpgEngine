using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum EffectType
    {
        buff,
        debuff,
        tick
    }
    public delegate void EffectTrigger();
    public class Effect
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int ID { get; set; }
        public int UniqieID { get; private set; }
        public EffectType Type { get; set; }

        public EffectTrigger OnPlayer;
        public EffectTrigger OnEnemy;

        public Effect(string name, string desc, int id, EffectType type)
        {
            Name = name;
            Desc = desc;
            ID = id;
            UniqieID = IDGenerator.GenerateNewID();
            Type = type;
        }

        public void Tick()
        {
            OnPlayer();
            if (Ply.CurEnemy != null) OnEnemy();
        }
    }
}
