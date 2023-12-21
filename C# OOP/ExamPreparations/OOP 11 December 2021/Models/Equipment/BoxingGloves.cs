using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double BoxingGlovesWeights = 227;
        private const decimal BoxingGlovePrice = 120;
        public BoxingGloves()
            : base(BoxingGlovesWeights, BoxingGlovePrice)
        {
        }
    }
}
