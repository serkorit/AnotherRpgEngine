using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public delegate void EnemyAbility(params object[] args);

    public enum EnemyType
    {
        world,
        dungeon,
        miniboss,
        boss,
        boss_summoned
    }

    public class Enemy : Entity
    {
        public List<LootCollection> LootTable { get; set; }
        public Dictionary<string, EnAbilitiesCollection> Abilities { get; set; }

        public Enemy(string name, string desc, int id, int mindmg,
            int maxdmg, int hp, int stamina, int mana, int gold, int exp)
            : base(name, desc, id, mindmg, maxdmg, hp, stamina, mana, gold, exp)
        {
            LootTable = new List<LootCollection>();
            Abilities = new Dictionary<string, EnAbilitiesCollection>();
        }

        public Enemy(Enemy enemy)
            :base()
        {
            Name = enemy.Name;
            Desc = enemy.Desc;
            ID = enemy.ID;
            MinDamage = enemy.MinDamage;
            MaxDamage = enemy.MaxDamage;
            HP = enemy.HP;
            Stamina = enemy.Stamina;
            Mana = enemy.Mana;
            Gold = enemy.Gold;
            Exp = enemy.Exp;
            LootTable = enemy.LootTable;
        }
    
    }
}
