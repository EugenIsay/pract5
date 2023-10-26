using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avto_Gruz
{
    internal class Truck : Avto
    {
        public override void Info(float capacity, float consumption, float speed, float weight)
        {
            base.Info(capacity, consumption, speed, weight);
            this.weight = weight + 38000.0f;
        }
        protected override float F()
        {
            temp0 = 0.004444444f;
            base.F();
            return result;
        }
    }
}
