using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum Action
    {
        thraw,
        drink,
        onplayer,
        onenemy
    }
    public static partial class Controller
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Entity> Entities = new List<Entity>();
        public static readonly List<Spell> Spells = new List<Spell>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Effect> Effects = new List<Effect>();

        public static void PopulateWorld()
        {
            PopulateItems();
            PopulateEntities();
            PopulateQuests();
            PopulateLocations();
            PopulateSpells();
            PopulateEffects();
        }

        public static Item ItemParse(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                    return item;
            }

            return null;
        }
        public static Enemy EnemyParse(int id)
        {
            foreach (Enemy enemy in Entities)
            {
                if (enemy.ID ==  id)
                    return enemy;
            }

            return null;
        }
        public static Entity EntityParse(int id)
        {
            foreach (Entity entity in Entities)
            {
                if (entity.ID == id)
                    return entity;
            }

            return null;
        }
        public static Quest QuestParse(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                    return quest;
            }

            return null;
        }
        public static Location LocationParse(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                    return location;
            }

            return null;
        }
        public static Spell SpellParse(int id)
        {
            foreach (Spell spell in Spells)
            {
                if (spell.ID == id)
                    return spell;
            }

            return null;
        }
        public static Effect EffectParse(int id)
        {
            foreach (Effect effect in Effects)
            {
                if (effect.ID == id)
                    return effect;
            }

            return null;
        }

        public static void StartBattle()
        {
            if (Ply.CurEnemy != null)
                Ply.InBattle = true;
            else
                Ply.InBattle = false;
        }
        public static void DoBattle(Weapon CurWeapon, Potion CurPotion, Spell CurSpell, Engine.Action action)
        {           
            if (CurWeapon != null)
            {
                Ply.PlayerAction(CurWeapon);
            }
            else if (CurPotion != null)
            {
                Ply.PlayerAction(CurPotion, action);
            }
            else if (CurSpell != null)
            {
                Ply.PlayerAction(CurSpell, action);
            }
            else Ply.PlayerAction();
            EffectsTickPlayer();

            if (Ply.CurEnemy != null && Ply.InBattle)
            {
                if (Ply.CurEnemy.HP <= 0)
                {
                    Ply.CheckForVictory();
                }
                else
                {
                    EffectsTickEnemy();
                    Ply.CurEnemy.EnemyTurn();
                }
            }
        }

        private static void EffectsTickPlayer()
        {
            foreach (EffectsCollection ec in Ply.Effects)
            {
                if(ec.Effect.Type == EffectType.buff || ec.Effect.Type == EffectType.debuff)
                {
                    if (!ec.AppliedOnPlayer)
                    {
                        ec.Duration++;
                        ec.BuffPlayer();
                    }
                }
                ec.TickPlayer();
                if (ec.Stacks <= 0)
                {
                    ec.MarkForDelete = true;
                }
            }

            Ply.Effects = Ply.Effects.Where(x => x.MarkForDelete == false).Select(x => x).ToList();
        }
        private static void EffectsTickEnemy()
        {
            if (Ply.CurEnemy != null)
            {
                foreach (EffectsCollection ec in Ply.CurEnemy.Effects)
                {
                    if (ec.Effect.Type == EffectType.buff || ec.Effect.Type == EffectType.debuff)
                    {
                        if (!ec.AppliedOnEnemy) ec.BuffEnemy();
                    }
                    ec.TickEnemy();
                    if (ec.Stacks <= 0)
                    {
                        ec.MarkForDelete = true;
                    }
                }

                Ply.CurEnemy.Effects = Ply.CurEnemy.Effects.Where(x => x.MarkForDelete == false).Select(x => x).ToList();
            }
        }
        internal static void NotifyNewLocation()
        {
            EffectsTickPlayer();
        }

        
    }
}
