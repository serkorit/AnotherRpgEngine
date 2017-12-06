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
                1, 2, 10, 2, WeaponType.sword, 1, 2));
            Items.Add(new Weapon(weapon_iron_sword, "Железный меч", "Он немного ржавый",
                2, 4, 30, 2, WeaponType.sword, 10, 20));
            Items.Add(new Weapon(weapon_stell_dagger, "Железный кинжал", "Ты посмотрел за свою спину?",
                1, 3, 15, 1, WeaponType.dagger,5, 10));

            #region Lesser hp pot
            Items.Add(new Potion(potion_lesser_hp_pot, "Малое зелье исцеления", "Переносной подорожник.",  1,
                () =>
                {
                    int Restore = 6;
                    int restored;
                    Ply.Msg("Ты пьешь " + "Малое зелье исцеления" + "...");
                    if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
                    else restored = Ply.MaxHP - Ply.HP;

                    Ply.Msg("Ты восстановил " + restored);
                    Ply.HP += restored;
                }
                ,
                () =>
                {
                    int Restore = 6;
                    int restored;
                    Ply.Msg("Ты кидаешь " + "Малое зелье исцеления.");
                    if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
                    else restored = Ply.MaxHP - Ply.HP;

                    Ply.HP += restored / 2;
                    Ply.Msg("Ты восстановил " + restored / 2);
                    if (Ply.CurEnemy != null)
                    {
                        Ply.CurEnemy.HP += restored / 2;
                        Ply.Msg("Противник восстановил " + restored / 2);
                    }
                },1,2));
            #endregion
            #region Medium hp pot
            Items.Add(new Potion(potion_medium_hp_pot, "Среднее зелья исцеления", "Не поможет если вы уже мертвы.", 2,
                () =>
                {
                    int Restore = 6;
                    int restored;
                    Ply.Msg("Ты пьешь " + "Малое зелье исцеления" + "...");
                    if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
                    else restored = Ply.MaxHP - Ply.HP;

                    Ply.Msg("Ты восстановил " + restored);
                    Ply.HP += restored;
                }
                ,
                () =>
                {
                    int Restore = 6;
                    int restored;
                    Ply.Msg("Ты кидаешь " + "Малое зелье исцеления.");
                    if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
                    else restored = Ply.MaxHP - Ply.HP;

                    Ply.HP += restored / 2;
                    Ply.Msg("Ты восстановил " + restored / 2);
                    if (Ply.CurEnemy != null)
                    {
                        Ply.CurEnemy.HP += restored / 2;
                        Ply.Msg("Противник восстановил " + restored / 2);
                    }
                },3,6));
            #endregion
            #region Lesser mp pot
            Items.Add(new Potion(potion_lesser_mp_pot, "Малое зелье энергии", "Переносной подорожник для разума.", 2,
                () =>
                {
                    int Restore = 10;
                    int restored;
                    Ply.Msg("Ты пьешь " + "Малое зелье энергии" + "...");
                    if (Ply.Mana <= Ply.MaxMana - Restore) restored = Restore;
                    else restored = Ply.MaxMana - Ply.Mana;

                    Ply.Msg("Ты восстановил " + restored + " маны.");
                    Ply.Mana += restored;
                }
                ,
                () =>
                {
                    int Restore = 10;
                    int restored;
                    Ply.Msg("Ты кидаешь " + "Малое зелье энергии.");
                    Ply.Msg("Кажется ничего не произошло...");
                },1,2));
            #endregion
            #region Lesser st pot
            Items.Add(new Potion(potion_lesser_st_pot, "Малое зелье восстановления", "Переносной подорожник для мышц.", 1,
                () =>
                {
                    int Restore = 20;
                    int restored;
                    Ply.Msg("Ты пьешь " + "Малое зелье восстановления" + "...");
                    if (Ply.Stamina <= Ply.MaxStamina - Restore) restored = Restore;
                    else restored = Ply.MaxStamina - Ply.Stamina;

                    Ply.Msg("Ты восстановил " + restored + " стамины.");
                    Ply.Stamina += restored;
                }
                ,
                () =>
                {
                    int Restore = 10;
                    int restored;
                    Ply.Msg("Ты кидаешь " + "Малое зелье восстановления.");
                    Ply.Msg("Кажется ничего не произошло...");
                },1,2));
            #endregion
            #region Fire pot
            Items.Add(new Potion(potion_fire_pot, "Огненное зелье", "Не для жарки мяса.", 1,
                () =>
                {
                    int Damage = 6;
                    Ply.Msg("Ты решил выпить " + "Огненное зелье" + ". Твое горло горит. Ты получаешь " + Damage / 2 + " единиц урона.");
                    Ply.HP -= Damage / 2;
                },
                () =>
                {
                    int Damage = 6;
                    if (Ply.CurEnemy != null)
                    {
                        Ply.Msg("Ты кидаешь " + "Огненное зелье" + "." + Ply.CurEnemy.Name + " получает " + Damage + " единиц урона.");
                        Ply.CurEnemy.HP -= Damage;
                    }
                    else Ply.Msg("Ты кидаешь " + "Огненное зелье" + "... Но тут никого нет...");
                },5,10));
            #endregion

            Items.Add(new Misc(misc_rat_tail, "Крысиный хвост", "Зачем ты это срезал?", MiscType.junk, 1, 2));
            Items.Add(new Misc(misc_spider_leg, "Паучая лапа", "Крепче палки!", MiscType.junk, 2, 3));
            Items.Add(new Misc(misc_secret_key, "Странный ключ", "???", MiscType.key, 100, 0));
        }
    }
}
