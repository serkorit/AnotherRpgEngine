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
        public int Stacks
        {
            get { return Stacks; }
            set
            {
                Stacks = value;

            }
        }


        public EffectsCollection(Effect effect, int max)
        {
            Effect = effect;
            MaxStacks = max;
            Stacks = 0;
        }
    }
}
