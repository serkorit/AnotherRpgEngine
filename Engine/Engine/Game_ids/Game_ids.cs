using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        const int hw = 1;
        const int hm = 100;
        const int hp = 1000;

        // Items
        private const int weapon_c = 0;
        private const int potion_c = 1000;
        private const int misc_c = 5000;
        // Weapons
        public const int weapon_wooden_sword = 1;
        public const int weapon_iron_sword = 2;
        public const int weapon_magic_sword = 3;
        public const int weapon_stell_dagger = 4;

        // Misc
        public const int misc_rat_tail = 1 + misc_c;
        public const int misc_spider_leg = 2 + misc_c;
        public const int misc_spider_queen_hittin = 3 + misc_c;
        public const int misc_secret_key = 4 + misc_c;

        // Potions
        public const int potion_lesser_hp_pot = 1 + potion_c;
        public const int potion_medium_hp_pot = 2 + potion_c;
        public const int potion_fire_pot = 3 + potion_c;
        public const int potion_antidote = 4 + potion_c;
        public const int potion_lesser_mp_pot = 5 + potion_c;
        public const int potion_lesser_st_pot = 6 + potion_c;

        // Items

        // Spells

        public const int spell_lesser_healing = 1;
        public const int spell_fireball = 2;
        public const int spell_mana_to_stamina = 3;
        public const int spell_test_spell = 4;

        // Spells


        //Enemies

        public const int enemy_rat = 1;
        public const int enemy_big_snake = 2;
        public const int enemy_spider_worker = 3;
        public const int enemy_spider_soldier = 4;
        public const int enemy_spider_queen = 5;
        public const int enemy_spider_queen_defender = 6;

        //Enemies

        // Quests

        public const int quest_bring_rat_tails = 1;
        public const int quest_bring_spider_legs = 2;
        public const int quest_kill_spider_queen = 3;

        // Quests

        // Locations

        public const int location_home = 1;
        public const int location_fred_house = 2;
        public const int location_aban_house = 3;
        public const int location_forest = 4;
        public const int location_town = 5;
        public const int location_field = 6;
        public const int location_caves01_entrance = 7;
        public const int location_caves01_hallway = 8;
        public const int location_caves01_deadend = 9;
        public const int location_caves01_spider_den = 10;
        public const int location_caves01_spider_den_nest = 11;

        // Locations

        // Effects

        public const int effect_poison = 1;
        public const int effect_buff_damage = 2;
        public const int effect_reduce_max_mana = 3;


        // Effects
    }
}
