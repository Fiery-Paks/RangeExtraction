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
            rangeExtraction.Split("10-10,5454,65695,45,75");
            return;
            Console.Write("Введите число - ");
            //Парсинг строки в число
            int n = int.Parse(Console.ReadLine());
            int summ = 0;

            for (int i = 1; i <= n; i++)
            {
                //Например - "0 + 1 = 1"
                Console.WriteLine($"{summ} + {i} = {summ + i}");
                summ = summ + i;
            }
            //Ожидание ввода символа с консоли чтобы консоль не зкрылась
            Console.ReadKey();
        }
    }
}
