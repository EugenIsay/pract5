using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avto_Gruz
{
    internal class Bus : Avto
    {
        public override void Info(float capacity, float consumption, float speed, float weight)
        {
            base.Info(capacity, consumption, speed, weight);
            this.weight = weight * 78.15f + 18000.0f;
        }
        protected override float F()
        {
            temp0 = 0.0013888f;
            base.F();
            return result;
        }
    }
}
