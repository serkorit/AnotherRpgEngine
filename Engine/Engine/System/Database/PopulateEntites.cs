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
            Enemy Rat = new Enemy("Крыса", "Выглядит голодной.", enemy_rat, 0, 2, 5, 7, 0, 5, 10);
            Rat.LootTable.Add(new LootCollection(ItemParse(weapon_wooden_sword), 35));
            Rat.LootTable.Add(new LootCollection(ItemParse(misc_rat_tail), 100));
            Rat.LootTable.Add(new LootCollection(ItemParse(misc_secret_key), 5));

            Entities.Add(Rat);

            Enemy Snake = new Enemy("Большая змея", "Явно нестандартный размер.", enemy_big_snake, 2, 4, 7, 15, 0, 10, 15);
            Snake.LootTable.Add(new LootCollection(ItemParse(weapon_iron_sword), 20));
            Snake.LootTable.Add(new LootCollection(ItemParse(potion_lesser_hp_pot), 40));
            Snake.LootTable.Add(new LootCollection(ItemParse(potion_lesser_hp_pot), 20));
            Snake.LootTable.Add(new LootCollection(ItemParse(potion_medium_hp_pot), 10));

            Entities.Add(Snake);

            Enemy SpiderWorker = new Enemy("Паук-трутень", "Вот бы и нам таких старательных.", enemy_spider_worker, 1, 3, 6, 15, 0, 7, 12);
            SpiderWorker.LootTable.Add(new LootCollection(ItemParse(weapon_stell_dagger), 15));
            SpiderWorker.LootTable.Add(new LootCollection(ItemParse(potion_fire_pot), 20));
            SpiderWorker.LootTable.Add(new LootCollection(ItemParse(potion_lesser_hp_pot), 20));
            SpiderWorker.LootTable.Add(new LootCollection(ItemParse(misc_spider_leg), 100));
            SpiderWorker.LootTable.Add(new LootCollection(ItemParse(misc_spider_leg), 100));
            SpiderWorker.LootTable.Add(new LootCollection(ItemParse(misc_spider_leg), 50));

            Entities.Add(SpiderWorker);
        }

    }
}
