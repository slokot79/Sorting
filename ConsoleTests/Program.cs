using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] A = new long[50000000];
            Random rnd = new Random();
            byte[] numBytes = new byte[8];
            DateTime start, end;

            for (int i = 0; i < A.Length; i++)
            {
                rnd.NextBytes(numBytes);
                A[i] = BitConverter.ToInt64(numBytes, 0);
            }
            start = DateTime.Now;
            BinaryQuick.sort(A);
            end = DateTime.Now;
            Console.WriteLine("Binary: " + (end - start).TotalSeconds);

            for (int i = 0; i < A.Length; i++)
            {
                rnd.NextBytes(numBytes);
                A[i] = BitConverter.ToInt64(numBytes, 0);
            }
            start = DateTime.Now;
            Merge.sort(A);
            end = DateTime.Now;
            Console.WriteLine("Merge: " + (end - start).TotalSeconds);

            for (int i = 0; i < A.Length; i++)
            {
                rnd.NextBytes(numBytes);
                A[i] = BitConverter.ToInt64(numBytes, 0);
            }
            start = DateTime.Now;
            Array.Sort(A);
            end = DateTime.Now;
            Console.WriteLine("Introsort: " + (end - start).TotalSeconds);

            Console.ReadLine();
        }
    }
}
