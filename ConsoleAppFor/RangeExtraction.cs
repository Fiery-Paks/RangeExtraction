using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFor
{
    public class RangeExtraction
    {
        private string input;
        private int[] mass;
        private List<string> strings;

        public RangeExtraction(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public RangeExtraction()
        {
        }

        public void Split(string text)
        {
            strings = text.Split(',').ToList();
        }

        public int[] Parse()
        {

            return mass;
        }
    }
}
