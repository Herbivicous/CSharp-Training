using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int>() { 56, 4, 3, 7, 13, 61, 100 };

            Console.WriteLine(data.OrderBy(i => Watch(i)*i).First());
        }

        private static int Watch(int i)
        {
            return i;
        }
    }
}
