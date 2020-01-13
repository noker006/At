using System;
using System.Collections.Generic;
using System.Text;

namespace At
{
    class ComparerWeightSweetness: IComparer<Sweetness>
    {
            public int Compare(Sweetness i, Sweetness j)
            {
                return i.Weight.CompareTo(j.Weight);
            }

    }
}
