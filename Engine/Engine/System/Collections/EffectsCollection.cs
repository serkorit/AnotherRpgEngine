using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class EffectsCollection
    {
        public Effect Effect;
        public int Duration { get; set; }
        private int DurationHolder;
        public bool MarkForDelete { get; set; }
        public bool AppliedOnPlayer { get; set; }
        public bool AppliedOnEnemy { get; set; }

        public EffectsCollection(Effect effect, int duration)
        {
            Effect = effect;
            Duration = duration;
            DurationHolder = Duration;
            MarkForDelete = false;
            AppliedOnPlayer = false;
            AppliedOnEnemy = false;
        }

        public void BuffPlayer()
        {

            Effect.ApplyBuffOnPlayer();
            AppliedOnPlayer = true;
        }

        public void BuffEnemy()
        {
            Effect.ApplyBuffOnEnemy();
            AppliedOnEnemy = true;
        }
        
        private void RemoveBuff()
        {
            if (AppliedOnPlayer) Effect.RemoveBuffOnPlayer();
            if (AppliedOnEnemy) Effect.RemoveBuffOnEnemy();
        }

        public void TickPlayer()
        {

            Effect.OnPlayer();
            Duration--;
            if(Duration <= 0)
            {
                MarkForDelete = true;
            }
        }

        public void TickEnemy()
        {
            Effect.OnEnemy();
            Duration--;
            if (Duration <= 0)
            {
                MarkForDelete = true;
            }
        }
    }
}
