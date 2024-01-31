using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFor
{
    public class RangeExtraction
    {
        protected enum Types
        {
            Number,
            Dash
        }

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
        protected virtual Types TypeDefinition(string element)
        {
            if (IsConvertingToInt32(element))
                return Types.Number;
            else if (element == "-")
                return Types.Dash;
            throw new Exception("Неизвестный тип enum Types");
        }
        protected virtual bool IsConvertingToInt32(string elemet)
        {
            if (int.TryParse(elemet, out _))
                return true;
            return false;
        }
        protected virtual List<string> Concatenation(List<string> strings)
        {
            Dictionary<string, Types> list = new Dictionary<string, Types>();

            
            for (int i = 0; i < strings.Count; i++)
            {
                list.Add(new KeyValuePair("w", TypeDefinition("")));
            }
            return strings;
        }
        protected virtual List<string> Separation(string enterText)
        {
            var split_list = new List<string>();
            for (int i = 0; i < enterText.Length; i++)
            {
                split_list.Add(enterText[i].ToString());
            }
            return split_list;
        }
        public void Split(string text)
        {
            text = text.Replace(" ", "").Replace("\t", "").Replace("\n", "");
            strings = text.Split(',').ToList();

            List<string> split_ = new List<string>();
            foreach (string s in strings)
            {
                List<string> list =  Separation(s);

            }
        }

        public int[] Parse()
        {

            return mass;
        }
    }
}
