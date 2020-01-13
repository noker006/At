using System;
using System.Collections.Generic;
using System.Text;

namespace At
{
    class Candy:Sweetness
    {
        public int PercentageCocoa { get; set; }
        public string Filling { get; set; }

        public override string ReturnString()
        {
            string inf;
            return inf = base.ReturnString() + "PercentageCocoa: " + PercentageCocoa + "Filling: " + Filling;
        }
    }
}
