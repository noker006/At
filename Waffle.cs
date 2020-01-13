using System;
using System.Collections.Generic;
using System.Text;

namespace At
{
    class Waffle:Sweetness
    {
        public string Taste { get; set; }
        public bool Glaze { get; set; }
        public override string ReturnString()
        {
            string inf;
            return inf = base.ReturnString() + "Taste: " + Taste + "Glaze: " + Glaze;
        }
    }
}
