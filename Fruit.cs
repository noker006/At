using System;
using System.Collections.Generic;
using System.Text;

namespace At
{
    class Fruit:Sweetness
    {
        public bool VitaminC { get; set; }
        public bool VitaminA { get; set; }

        public override string ReturnString()
        {
            string inf;
            return inf = base.ReturnString() + "Vitamin C: " + VitaminC + "Vitamin A: " + VitaminA;
        }
    }
}
