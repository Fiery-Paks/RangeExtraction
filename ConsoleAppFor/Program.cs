using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RangeExtraction rangeExtraction = new RangeExtraction();
            rangeExtraction.Split("-10-10,5454,65695,45,75");
        }
    }
}
