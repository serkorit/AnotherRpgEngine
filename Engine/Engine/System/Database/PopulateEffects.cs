using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static partial class Controller
    {
        private static void PopulateEffects()
        {
            Effect effect = new Effect("Отравление", "После такого стоит обратиться к врачу.", effect_poison, EffectType.tick);
            #region Poisoneffecct
            effect.OnPlayer += () =>
                {
                    int damage = 1;
                    Ply.Msg("Ты получаешь " + damage + " урона в результате действия яда.");
                    Ply.HP -= damage;
                };

            effect.OnEnemy += () =>
            {
                int damage = 1;
                Ply.Msg(Ply.CurEnemy.Name + " получает " + damage + " урона в результате действия яда.");
                Ply.CurEnemy.HP -= damage;
            };

            Effects.Add(effect);
            #endregion
            #region StrenghtBuff
            effect = new Effect("Мощь", "Все еще неспособен свернуть горы", effect_buff_damage, EffectType.buff);
            effect.OnPlayer += () =>
            {

            };
            effect.OnEnemy += () =>
            {

            };
            Effects.Add(effect);
            #endregion
        }
    }
}
