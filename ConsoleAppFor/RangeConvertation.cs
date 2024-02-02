using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFor
{
    public class RangeConvertation
    {
        private int[] ints;

        public RangeConvertation(int[] ints)
        {
            this.ints = ints ?? throw new ArgumentNullException(nameof(ints));
        }

        public override string ToString()
        {
            

            return base.ToString();
        }
    }
}
