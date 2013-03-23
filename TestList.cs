using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class TestList
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(45);
            list.Add(41);
            list.Add(2);
            list.Remove(1);
            list.Add(4);
            list.Insert(5, 1);
            list.Insert(12,3);
            int element = 5;
            list.FindElement(element);
            Console.WriteLine(list);
            Console.WriteLine("Element with max value is {0}", list.Max<int>());
            Console.WriteLine("Element with min value is {0}", list.Min<int>());
        }
    }
}
