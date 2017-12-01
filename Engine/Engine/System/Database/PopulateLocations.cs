using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        private static void PopulateLocations()
        {
            Location home = new Location(location_home, "Дом", "Это твой дом!");
            Location town = new Location(location_town, "Городок", "Такой же как и все остальные.");
            Location town_shop = new Location(location_town_shop, "Магазин", "Хочешь поторговать?");
            Location fred_house = new Location(location_fred_house, "Дом Фреда", "Ты его не знаешь.");
            Location aban_house = new Location(location_aban_house, "Заброшенный дом", "Удивительно, что он еще стоит.");
            Location forest = new Location(location_forest, "Лес", "Лес со \"Страшными\" существами.");
            Location fields = new Location(location_field, "Цветочное поле", "...");
            Location caves_enterence = new Location(location_caves01_entrance, "Пещера - Вход", "Ты видишь только темноту впереди.");
            Location caves_hallway = new Location(location_caves01_hallway, "Пещера - Развилка", "Ты слышишь странные звуки.");
            Location caves_spider_den  = new Location(location_caves01_spider_den, "Пещера - Паучье гнездо", "Паутина оккутывает тебя.");
            Location caves_dead_end = new Location(location_caves01_deadend, "Пещера - Тупик", "Ты видишь стену.");
            Location caves_spider_den_nest = new Location(location_caves01_spider_den_nest, "Пещера - гнездо королевы", "Я неуверен это камень или огромная лапа?");

            home.NearestLocations = new List<Location> { town };
            home.IsSafe = true;

            town.NearestLocations = new List<Location> { home, fred_house, forest, town_shop };

            town_shop.NearestLocations = new List<Location> { town };
            town_shop.IsShop = true;
            town_shop.ShopList = new List<Item> { ItemParse(weapon_wooden_sword), ItemParse(potion_lesser_hp_pot), ItemParse(potion_lesser_mp_pot), ItemParse(potion_lesser_st_pot) };

            fred_house.NearestLocations = new List<Location> { town };
            fred_house.JustQuest = QuestParse(quest_bring_rat_tails);

            forest.NearestLocations = new List<Location> { town, aban_house, fields };
            forest.EnemiesHere = new List<Enemy> { EnemyParse(enemy_rat) };

            aban_house.NearestLocations = new List<Location> { forest };
            aban_house.Key = ItemParse(misc_secret_key);

            fields.NearestLocations = new List<Location> { forest, caves_enterence };

            caves_enterence.NearestLocations = new List<Location> { fields, caves_hallway };
            caves_hallway.NearestLocations = new List<Location> { caves_enterence, caves_dead_end, caves_spider_den };
            caves_dead_end.NearestLocations = new List<Location> { caves_hallway };
            caves_dead_end.EnemiesHere = new List<Enemy> { EnemyParse(enemy_big_snake) };
            caves_spider_den.NearestLocations = new List<Location> { caves_hallway, caves_spider_den_nest };
            caves_spider_den.EnemiesHere = new List<Enemy> { EnemyParse(enemy_spider_worker) };
            caves_spider_den_nest.NearestLocations = new List<Location> { caves_spider_den };

            Locations.Add(home);
            Locations.Add(forest);
            Locations.Add(fred_house);
            Locations.Add(town_shop);
            Locations.Add(aban_house);
            Locations.Add(town);
            Locations.Add(fields);
            Locations.Add(caves_dead_end);
            Locations.Add(caves_enterence);
            Locations.Add(caves_hallway);
            Locations.Add(caves_spider_den);
            Locations.Add(caves_spider_den_nest);
        }
    }
}
