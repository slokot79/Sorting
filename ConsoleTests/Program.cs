using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            long[] A = new long[100000]; // 268435448 maximum size without memory exception

            DateTime start, end;

            generate(A);
            Console.WriteLine("Standard sort started");
            start = DateTime.Now;
            Array.Sort(A);
            end = DateTime.Now;
            Console.WriteLine("Standard sort finished in " + (end - start).TotalSeconds + " seconds");
            check(A);
            Console.WriteLine();

            generate(A);
            Console.WriteLine("Binary sort started");
            start = DateTime.Now;
            Binary.Sort(A);
            end = DateTime.Now;
            Console.WriteLine("Binary sort finished in " + (end - start).TotalSeconds + " seconds");
            check(A);
            Console.WriteLine();

            generate(A);
            Console.WriteLine("Merge sort started");
            start = DateTime.Now;
            Merge.Sort(A);
            end = DateTime.Now;
            Console.WriteLine("Merge sort finished in " + (end - start).TotalSeconds + " seconds");
            check(A);
            Console.WriteLine();

            generate(A);
            Console.WriteLine("Heap sort started");
            start = DateTime.Now;
            Heap.Sort(A);
            end = DateTime.Now;
            Console.WriteLine("Heap sort finished in " + (end - start).TotalSeconds + " seconds");
            check(A);

            Console.ReadLine();
        }

        private static void generate(long[] A)
        {
            Console.WriteLine("Generating random values...");
            byte[] b = new byte[8];
            for (int i = 0; i < A.Length; i++)
            {
                rnd.NextBytes(b);
                A[i] = BitConverter.ToInt64(b, 0);
            }
        }

        private static void check(long[] A)
        {
            for (int i = A.Length - 1; i > 0; i -= 1)
                if (A[i - 1] > A[i])
                {
                    Console.WriteLine("Sorting error: A[" + (i - 1) + "] = " + A[i - 1] + ", A[" + (i) + "] = " + A[i]);
                    return;
                }
            Console.WriteLine("Array was sorted correctly");
            return;
        }
    }
}
