using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    public static class Binary
    {
        public static void Sort(long[] source)
        {
            long[] A = source;
            if (A == null) return;

            int L = source.Length;
            if (L <= 1) return;

            long bit = long.MinValue;
            long a, mask, next;
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

            mask = orL & (andL ^ -1L);
            if (mask != 0L)
            {
                next = 0x4000000000000000;
                while ((next & mask) == 0L)
                    next >>= 1;
                process(A, 0, i, next);
            }

            mask = orR & (andR ^ -1L);
            if (mask != 0L)
            {
                next = 0x4000000000000000;
                while ((next & mask) == 0L)
                    next >>= 1;
                process(A, i, L, next);
            }
        }

        private static void process(long[] A, int from, int until, long bit)
        {
            long a, mask, next;
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

            mask = orL & (andL ^ -1L);
            if (mask != 0L)
            {
                next = bit >> 1;
                while ((next & mask) == 0L)
                    next >>= 1;
                process(A, from, i, next);
            }

            mask = orR & (andR ^ -1L);
            if (mask != 0L)
            {
                next = bit >> 1;
                while ((next & mask) == 0L)
                    next >>= 1;
                process(A, i, until, next);
            }
        }
    }
}
