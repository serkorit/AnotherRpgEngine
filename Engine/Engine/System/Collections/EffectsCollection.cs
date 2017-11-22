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

        public EffectsCollection(Effect effect, int maxst, int duration)
        {
            Effect = effect;
            MaxStacks = maxst;
            Stacks = 1;
            Duration = duration;
            DurationHolder = Duration;
        }

        public void Tick()
        {
            Effect.Tick();
            Duration--;
            if(Duration <= 0)
            {
                RemoveStack();
                UpdateDuration();
            }
        }

        public void AddStack()
        {
            if(Stacks < MaxStacks)
                Stacks++;
        }

        public void RemoveStack()
        {
            Stacks--;
        }

        public void UpdateDuration()
        {
            Duration = DurationHolder;
        }
    }
}
