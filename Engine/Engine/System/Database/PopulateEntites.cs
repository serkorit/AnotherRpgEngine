using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        private static void PopulateEntities()
        {
            #region Rat
            Enemy enemy = new Enemy("Крыса", "Выглядит голодной.", enemy_rat, 0, 2, 5, 7, 0, 5, 10);
            enemy.LootTable.Add(new LootCollection(ItemParse(weapon_wooden_sword), 35));
            enemy.LootTable.Add(new LootCollection(ItemParse(misc_rat_tail), 100));
            enemy.LootTable.Add(new LootCollection(ItemParse(misc_secret_key), 5));
            enemy.EnemyTurn += () => { enemy.Abilities["default"].Ability.Invoke(); };

            Entities.Add(enemy);
            #endregion

            #region Big snake
            enemy = new Enemy("Большая змея", "Явно нестандартный размер.", enemy_big_snake, 2, 4, 7, 15, 0, 10, 15);
            enemy.LootTable.Add(new LootCollection(ItemParse(weapon_iron_sword), 20));
            enemy.LootTable.Add(new LootCollection(ItemParse(potion_lesser_hp_pot), 40));
            enemy.LootTable.Add(new LootCollection(ItemParse(potion_lesser_hp_pot), 20));
            enemy.LootTable.Add(new LootCollection(ItemParse(potion_medium_hp_pot), 10));
            enemy.EnemyTurn += () => { enemy.Abilities["default"].Ability.Invoke(); };

            Entities.Add(enemy);
            #endregion

            #region Spider worker
            enemy = new Enemy("Паук-трутень", "Вот бы и нам таких старательных.", enemy_spider_worker, 1, 3, 6, 15, 0, 7, 12);
            enemy.LootTable.Add(new LootCollection(ItemParse(weapon_stell_dagger), 15));
            enemy.LootTable.Add(new LootCollection(ItemParse(potion_fire_pot), 20));
            enemy.LootTable.Add(new LootCollection(ItemParse(potion_lesser_hp_pot), 20));
            enemy.LootTable.Add(new LootCollection(ItemParse(misc_spider_leg), 100));
            enemy.LootTable.Add(new LootCollection(ItemParse(misc_spider_leg), 100));
            enemy.LootTable.Add(new LootCollection(ItemParse(misc_spider_leg), 50));
            enemy.Abilities.Add("attack1", new EnAbilitiesCollection(
                () =>
                {
                    int damage = 4;
                    Ply.Msg(enemy.Name + " харкает в тебя.\nТы получаешь " + damage + " единиц урона.");
                    Ply.HP -= damage;
                    
                    
                    return;
                }, 2,1));
            enemy.EnemyTurn += () =>
            {
                AbilityCategory category;
                if(enemy.Abilities["attack1"].ActiveCooldown == 0)
                {
                    int Weight = RandomNumberGenerator.Generate(0, 1);
                    if (Weight == 0)
                    {
                        enemy.Abilities["default"].Ability.Invoke();
                        return;
                    }
                    else
                    {
                        enemy.Abilities["attack1"].Ability.Invoke();
                        enemy.Abilities["attack1"].ActiveCooldown += enemy.Abilities["attack1"].Cooldown;
                        return;
                    }
                }
                enemy.Abilities["default"].Ability.Invoke();
                foreach(var en in enemy.Abilities)
                {
                    if (en.Value.ActiveCooldown > 0) en.Value.ActiveCooldown--;
                }
            };

            Entities.Add(enemy);
            #endregion
        }

    }
}
