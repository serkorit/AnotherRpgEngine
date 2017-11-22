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
            Spells.Add(new Spell(spell_fireball, "Огненный шар", "Deal 6 damage", 15, SpellType.fire,
                () =>
                {
                    int damage = 6;
                    Ply.Msg("Ты направил палец на себя. Ты видишь яркую вспышку. Ты получаешь " + damage + " единиц урона.");
                    Ply.HP -= damage;
                    return;
                },
                () =>
                {
                    if (Ply.CurEnemy != null)
                    {
                        int damage = 6;
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
            Spells.Add(new Spell(spell_lesser_healing, "Малое исцеление", "Restore 2 hp", 5, SpellType.light,
                () =>
                {
                    int Restore = 2;
                    int restored;

                    if (Ply.HP <= Ply.MaxHP - Restore) restored = Restore;
                    else restored = Ply.MaxHP - Ply.HP;

                    Ply.Msg("Ты взываешь к силам света. Ты восстановил " + restored);
                    Ply.HP += restored;
                    return;
                },
                () =>
                {
                    int Restore = 2;
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
            Spells.Add(new Spell(spell_mana_to_stamina, "Круговорот энергии", "Transform all mana to stamina", 0, SpellType.psionic,
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


            #region TestSpell

            Spells.Add(new Spell(spell_test_spell, "Тестовое заклинание", "ВО ИМЯ ТЕСТОВ", 0, SpellType.other,
                () =>
                {
                    Ply.Msg("Ты наложил на себя яд");
                    Ply.AddEffect(new EffectsCollection(Controller.EffectParse(effect_poison), 1, 2));
                },
                () =>
                {
                    if(Ply.CurEnemy != null)
                    Ply.CurEnemy.AddEffect(new EffectsCollection(Controller.EffectParse(effect_poison), 2, 2));
                    Ply.Msg("Ты наложил на врага яд");
                }));

            #endregion

        }
    }
}
