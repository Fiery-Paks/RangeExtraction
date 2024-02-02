using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFor
{
    public class RangeExtraction
    {
        protected class ElementPair
        {
            public string element;
            public Types types;

            public ElementPair(string element, Types types)
            {
                this.element = element ?? throw new ArgumentNullException(nameof(element));
                this.types = types;
            }
        }
        protected enum Types
        {
            Number,
            Dash
        }

        protected string input;
        protected int[] mass;
        protected List<string> strings;


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
        protected virtual void ConcatNumber(ref List<ElementPair> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (i != elements.Count - 1
                && elements[i].types == Types.Number
                && elements[i + 1].types == Types.Number)
                {
                    elements[i].element += elements[i + 1].element;
                    elements.Remove(elements[i + 1]);
                    i--;
                }
            }
            for (int i = 0; i < elements.Count; i++)
            {
                if (i == 0 && elements[i].types == Types.Dash)
                {
                    elements[i].element += elements[i + 1].element;
                    elements.Remove(elements[i + 1]);
                    elements[i].types = Types.Number;
                }
                if (i != elements.Count - 1
                && elements[i].types == Types.Dash
                && elements[i + 1].types == Types.Dash)
                {
                    elements[i + 1].element += elements[i + 2].element;
                    elements.Remove(elements[i + 2]);
                    elements[i + 1].types = Types.Number;
                }
            }
            elements.RemoveAll(x => x.types == Types.Dash);
        }
        protected virtual List<ElementPair> Concatenation(List<string> strings)
        {
            List<ElementPair> elements = new List<ElementPair>();
            foreach (string s in strings)
                elements.Add(new ElementPair(s, TypeDefinition(s)));

            ConcatNumber(ref elements);

            return elements;
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
        protected virtual List<int> CreateList(List<ElementPair> elements)
        {

            if (elements.Count != 1)
            {
                var ints = new List<int>();
                ints.Add(int.Parse(elements.First().element));
                ints.Add(int.Parse(elements.Last().element));
                return ints;
            }
            return new List<int> { int.Parse(elements.First().element) };
        }
        protected virtual List<int> CreateFullArray(List<int> ints)
        {
            List<int> full_array = new List<int>();
            for (int i = ints.Min(); i <= ints.Max(); i++)
            {
                full_array.Add(i);
            }
            return full_array;
        }
        public List<int> Split(string text)
        {
            text = text.Replace(" ", "").Replace("\t", "").Replace("\n", "");
            strings = text.Split(',').ToList();
            List<int> elements = new List<int>();
            foreach (string s in strings)
            {
                elements.AddRange(CreateList(Concatenation(Separation(s))));
            }
            return CreateFullArray(elements);
        }

        public int[] Parse(string text)
        {
            return Split(text).ToArray();
        }
    }
}
