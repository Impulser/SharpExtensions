using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpExtensions.Extensions.Collection;

namespace SharpExtensions.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Enumerable.Range(15, 200).ToArray().ForEach((i, j) => Console.WriteLine("[{0}] {1}", i, j));
            Console.ReadLine();
        }

        static bool C<T>(T obj)
        {
            return obj == null;
        }

        static bool IsStruct<T>(T s)
            where T : struct
        {
            return true;
        }
    }
}
