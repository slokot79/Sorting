using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    public static class Merge
    {
        public static long[] sort(long[] A)
        {
            int L = A.Length;
            long[] B = new long[L], T;

            int L0 = L & (-2);
            for (int i = 0; i < L0; i += 2)
            {
                if (A[i] > A[i + 1])
                {
                    B[i] = A[i + 1];
                    B[i + 1] = A[i];
                }
                else
                {
                    B[i] = A[i];
                    B[i + 1] = A[i + 1];
                }
            }
            if (L0 != L)
                B[L0] = A[L0];

            T = A;
            A = B;
            B = T;

            int p = 1;
            while ((p = p << 1) < L)
            {
                int b = 0;
                int m = p;
                int n = p << 1;
                while (n < L)
                {
                    merge(A, B, b, m, n);
                    b = n;
                    m = b + p;
                    n = m + p;
                }
                if (m < L) merge(A, B, b, m, L);
                else for (int i = b; i < L; i += 1) B[i] = A[i];

                T = A;
                A = B;
                B = T;
            }
            return A;
        }

        private static void merge(long[] A, long[] B, int b, int m, int n)
        {
            int i = b;
            int j = m;
            int k = b;
            while (true)
            {
                if (i < m && j < n)
                {
                    if (A[j] < A[i])
                        B[k++] = A[j++];
                    else B[k++] = A[i++];
                }
                else if (i < m)
                    B[k++] = A[i++];
                else if (j < n)
                    B[k++] = A[j++];
                else break;
            }
        }
    }
}