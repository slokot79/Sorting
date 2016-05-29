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
            long[] A = new long[268435448]; //268435448

            DateTime start, end;

            generate(A);
            Console.WriteLine("Standard Sort Started");
            start = DateTime.Now;
            Array.Sort(A);
            end = DateTime.Now;
            Console.WriteLine("Standard: " + (end - start).TotalSeconds);
            check(A);

            generate(A);
            Console.WriteLine("Binary Sort Started");
            start = DateTime.Now;
            BinaryQuick.sort(A);
            end = DateTime.Now;
            Console.WriteLine("Binary: " + (end - start).TotalSeconds);
            check(A);

            generate(A);
            Console.WriteLine("Merge Sort Started");
            start = DateTime.Now;
            Merge.sort(A);
            end = DateTime.Now;
            Console.WriteLine("Merge: " + (end - start).TotalSeconds);
            check(A);

            generate(A);
            Console.WriteLine("Heap Sort Started");
            start = DateTime.Now;
            Heap.sort(A);
            end = DateTime.Now;
            Console.WriteLine("Heap Sort Done: " + (end - start).TotalSeconds);
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
                    Console.WriteLine("Sorting error: A[" + (i - 1) + "] = " + A[i - 1] + ", A[" + (i) + "] = " + A[i]);

            Console.WriteLine(".");
        }
    }
}
