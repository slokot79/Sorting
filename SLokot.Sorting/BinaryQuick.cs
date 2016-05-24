using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    public static class BinaryQuick
    {
        public static void sort(long[] source)
        {
            long[] A = source;
            if (A == null) return;

            int L = source.Length;
            if (L <= 1) return;

            long a, bit = long.MinValue;
            long orL = 0L, andL = -1L;
            long orR = 0L, andR = -1L;
            int i = 0, j = L - 1;
            while (true)
            {
                while (i < L && ((a = A[i]) & bit) != 0L)
                {
                    orL |= a;
                    andL &= a;
                    i += 1;
                }
                while (j >= 0 && ((a = A[j]) & bit) == 0L)
                {
                    orR |= a;
                    andR &= a;
                    j -= 1;
                }
                if (i < j)
                {
                    a = A[i];
                    A[i] = A[j];
                    A[j] = a;
                }
                else break;
            }

            process(A, 0, i, 0x4000000000000000, orL & (andL ^ -1L));
            process(A, i, L, 0x4000000000000000, orR & (andR ^ -1L));
        }

        private static void process(long[] A, int from, int until, long bit, long mask)
        {
            if (mask == 0L) return;
            while ((bit & mask) == 0L) bit >>= 1;

            long a;
            long orL = 0L, andL = -1L;
            long orR = 0L, andR = -1L;
            int i = from, j = until - 1;
            while (true)
            {
                while (i < until && ((a = A[i]) & bit) == 0L)
                {
                    orL |= a;
                    andL &= a;
                    i += 1;
                }
                while (j >= from && ((a = A[j]) & bit) != 0L)
                {
                    orR |= a;
                    andR &= a;
                    j -= 1;
                }
                if (i < j)
                {
                    a = A[i];
                    A[i] = A[j];
                    A[j] = a;
                }
                else break;
            }

            process(A, from, i, bit >> 1, orL & (andL ^ -1L));
            process(A, i, until, bit >> 1, orR & (andR ^ -1L));
        }

    }
}
