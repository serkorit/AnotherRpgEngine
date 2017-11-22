using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        private static void PopulateSpells()
        {
            #region Fireball
            Spells.Add(new Spell(spell_fireball, "Огненный шар", "Наносит 5 урона", 15, SpellType.fire,
                () =>
                {
                    int damage = 5;
                    Ply.Msg("Ты направил палец на себя. Ты видишь яркую вспышку. Ты получаешь " + damage + " единиц урона.");
                    Ply.HP -= damage;
                    return;
                },
                () =>
                {
                    if (Ply.CurEnemy != null)
                    {
                        int damage = 5;
                        Ply.Msg("Ты выпускаешь огненный шар в " + Ply.CurEnemy.Name + " . " + Ply.CurEnemy.Name + " получает " + damage + " единиц урона.");
                        Ply.CurEnemy.HP -= damage;
                        return;
                    }
                    else
                    {
                        Ply.Msg("Ты выпускаешь огненный шар в небо...");
                    }
                    return;
                }));
            #endregion
            #region Lesser Healing
            Spells.Add(new Spell(spell_lesser_healing, "Малое исцеление", "Восстанавливает 3 ХП", 5, SpellType.light,
                () =>
                {
                    int Restore = 3;
                    int restored;

                    if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
                    else restored = Ply.MaxHP - Ply.HP;

                    Ply.Msg("Ты взываешь к силам света. Ты восстановил " + restored);
                    Ply.HP += restored;
                    return;
                },
                () =>
                {
                    int Restore = 3;
                    if (Ply.CurEnemy != null)
                    {
                        Ply.Msg("Ты взываешь к силам света воимя " + Ply.CurEnemy.Name + " . " + Ply.CurEnemy.Name + " восстанавливает " + Restore + " здоровья");
                        Ply.CurEnemy.HP += Restore;
                    }
                    else
                    {
                        Ply.Msg("Ты взываешь к силам света и исцеляешь воздух...");
                    }
                    return;
                }
                ));
            #endregion
            #region ManaToStamina
            Spells.Add(new Spell(spell_mana_to_stamina, "Круговорот энергии", "Превращает ману в стамину", 0, SpellType.psionic,
                () =>
                {
                    int transfered = Ply.Mana;
                    Ply.Stamina += transfered;
                    Ply.Mana = 0;
                    Ply.Msg("Ты присел подумать... Твоя энергия превращается в энергию? Ты восстановил " + transfered + " стамины.");
                    return;
                },
                () =>
                {
                    if (Ply.CurEnemy != null)
                    {
                        Ply.Msg("Жаль, что ты не псионик.");
                    }
                    else
                    {
                        Ply.Msg("Воздух \"слишком туп\", чтобы ты мог с ним взаимодействовать...");
                    }
                }
                ));
            #endregion


            #region Poison

            Spells.Add(new Spell(spell_poison, "Отравление", "Накладывает отравление", 5, SpellType.water,
                () =>
                {
                    Ply.Msg("Ты наложил на себя яд");
                    Ply.AddEffect(new EffectsCollection(Controller.EffectParse(effect_poison), 1, 3));
                },
                () =>
                {
                    if (Ply.CurEnemy != null)
                    {
                        Ply.CurEnemy.AddEffect(new EffectsCollection(Controller.EffectParse(effect_poison), 2, 2));
                        Ply.Msg("Ты наложил на врага яд");
                    }
                }));

            #endregion
            #region Strenght

            Spells.Add(new Spell(spell_strength, "Супер сила", "Усиливает физическую силу", 7, SpellType.water,
                () =>
                {
                    Ply.Msg("Ты зачаровываешь себя.");
                    Ply.AddEffect(new EffectsCollection(Controller.EffectParse(effect_buff_damage), 3, 3));
                },
                () =>
                {
                    if (Ply.CurEnemy != null)
                    {
                        Ply.CurEnemy.AddEffect(new EffectsCollection(Controller.EffectParse(effect_buff_damage), 2, 3));
                        Ply.Msg("Ты наложил на врага зачарование.");
                    }
                }));

            #endregion

        }
    }
}
