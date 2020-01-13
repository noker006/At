using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace At
{
    [Serializable]
   abstract class Sweetness
   {
        public string Name { get; set; }
        public double Weight { get; set; }// в граммах 
        public int Caloric { get; set; }
        public double PriceFor1kg { get; set; }
        public virtual string ReturnString()
        {
            string inf;
            return inf = Name + " " + Weight + " " + Caloric + " " + PriceFor1kg;
        }
   }
}
