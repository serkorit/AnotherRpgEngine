using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public delegate void EnemyAbility();

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

        public int BonusDamage { get; set; }
        public int BonusArmor { get; set; }

        public List<LootCollection> LootTable { get; set; }
        public Dictionary<string, EnAbilitiesCollection> Abilities { get; set; }
        public List<EffectsCollection> Effects { get; set; }
        public void AddEffect(EffectsCollection effect)
        {
            if (Effects.Count == 0)
            {
                Effects.Add(effect);
                return;
            }
            foreach (EffectsCollection ef in Effects)
            {
                if (ef.Effect.ID == effect.Effect.ID)
                {
                    ef.AddStack();
                    return;
                }
            }
            Effects.Add(effect);
        }
        public void RemoveEffect(EffectsCollection effect)
        {
            Effects.Remove(effect);
        }

        public Enemy(string name, string desc, int id, int mindmg,
            int maxdmg, int hp, int stamina, int mana, int gold, int exp)
            : base(name, desc, id, mindmg, maxdmg, hp, stamina, mana, gold, exp)
        {
            LootTable = new List<LootCollection>();
            Abilities = new Dictionary<string, EnAbilitiesCollection>();
            Effects = new List<EffectsCollection>();

            Abilities.Add("default", new EnAbilitiesCollection(
                () =>
                {
                    int enemyDamage = RandomNumberGenerator.Generate(MinDamage + Ply.CurEnemy.BonusDamage, MaxDamage + Ply.CurEnemy.BonusDamage);
                    Ply.Msg(Ply.CurEnemy.Name + " наносит тебе " + enemyDamage + " единиц урона.");
                    Ply.HP -= enemyDamage;

                    return;
                }, 0,0));
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
            Abilities = enemy.Abilities;
            EnemyTurn = enemy.EnemyTurn;
            Effects = enemy.Effects;

        }

        public EnemyAbility EnemyTurn { get; set; }
    
    }
}
