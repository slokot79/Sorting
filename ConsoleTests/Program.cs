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
            long[] A = new long[100000000];
            Random rnd = new Random();
            byte[] numBytes = new byte[8];

            for (int i = 0; i < A.Length; i++)
            {
                rnd.NextBytes(numBytes);
                A[i] = BitConverter.ToInt64(numBytes, 0);
            }

            DateTime start = DateTime.Now;
            BinaryQuick.sort(A);
            DateTime end = DateTime.Now;
            Console.WriteLine((end - start).TotalSeconds);

            start = DateTime.Now;
            BinaryQuick.sort(A);
            end = DateTime.Now;
            Console.WriteLine((end - start).TotalSeconds);

            Console.ReadLine();
        }
    }
}
