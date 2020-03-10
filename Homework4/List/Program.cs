using List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for (int i= 0; i < 10; i++)
            {
                list.Add(i);
            }
            int max = list.Head.Data;
            int min = list.Head.Data;
            int sum = 0;
            list.ForEach(i => Console.WriteLine($"{i}"));
            list.ForEach(i => max = i > max ? i : max);
            list.ForEach(i => min = i < min ? i : min);
            list.ForEach(i => sum += i);
            Console.WriteLine($"max={max},min={min},sum={sum}");
        }
    }
}
