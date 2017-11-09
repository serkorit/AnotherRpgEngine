using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        private static void PopulateItems()
        {
            Items.Add(new Weapon(weapon_wooden_sword, "Деревянный меч", "Все еще лучше, чем ничего.",
                1, 2, 10, 2, WeaponType.sword));
            Items.Add(new Weapon(weapon_iron_sword, "Железный меч", "Он немного ржавый",
                2, 4, 30, 2, WeaponType.sword));
            Items.Add(new Weapon(weapon_stell_dagger, "Железный кинжал", "Ты посмотрел за свою спину?",
                1, 3, 15, 1, WeaponType.dagger));

            Items.Add(new HealingPotion(potion_lesser_hp_pot, "Малое зелье исцеления", "Переносной подорожник.", 3, 3));
            Items.Add(new HealingPotion(potion_medium_hp_pot, "Среднее зелья исцеления", "Не поможет если вы уже мертвы.", 3, 6));
            Items.Add(new FirePotion(potion_fire_pot, "Огненное зелья", "Не для жарки мяса.", 2, 5));

            Items.Add(new Misc(misc_rat_tail, "Крысиный хвост", "Зачем ты это срезал?", MiscType.junk));
            Items.Add(new Misc(misc_spider_leg, "Паучая лапа", "Крепче палки!", MiscType.junk));
            Items.Add(new Misc(misc_secret_key, "Странный ключ", "???", MiscType.key));
        }
    }
}
