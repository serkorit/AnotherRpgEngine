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
        public int MaxStacks;
        public int Stacks { get; set; }
        public int Duration { get; set; }
        private int DurationHolder;
        public bool MarkForDelete { get; set; }
        public bool AppliedOnPlayer { get; set; }
        public bool AppliedOnEnemy { get; set; }

        public EffectsCollection(Effect effect, int maxst, int duration)
        {
            Effect = effect;
            MaxStacks = maxst;
            Stacks = 1;
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

            for (int i = 1; i <= Stacks; i++)
                Effect.OnPlayer();
            Duration--;
            if(Duration <= 0)
            {
                RemoveStack();
                UpdateDuration();
            }
        }

        public void TickEnemy()
        {
            for(int i = 1; i <= Stacks; i++)
                Effect.OnEnemy();
            Duration--;
            if (Duration <= 0)
            {
                RemoveStack();
                UpdateDuration();
            }
        }

        public void AddStack()
        {
            if (Stacks < MaxStacks)
                Stacks++;
            else UpdateDuration();
            if (AppliedOnPlayer) BuffPlayer();
            if (AppliedOnEnemy) BuffEnemy();
        }

        public void RemoveStack()
        {
            Stacks--;
            if (AppliedOnPlayer || AppliedOnEnemy) RemoveBuff();
        }

        public void UpdateDuration()
        {
            Duration = DurationHolder;
        }
    }
}
