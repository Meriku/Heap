using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap<int>();
            var rnd = new Random();

            for (int i = 0; i < 300; i++)
            {
                heap.Add(rnd.Next(1, 101));
            }

            for (int i = heap.Count; i > 0; i--)
            {
                Console.WriteLine( heap.GetMax() );
            }

            Console.ReadLine();
        }
    }
}
