using System;
using System.Collections.Generic;
using System.Text;

namespace At
{
    class ComparerCaloricSweetness:IComparer<Sweetness>
    {
        public int Compare(Sweetness i, Sweetness j)
        {
            return i.Caloric.CompareTo(j.Caloric);
        }
    }
}
