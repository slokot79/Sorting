using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    public static class Merge
    {
        public static void Sort(long[] S)
        {
            int L = S.Length;
            long[] A = S, B = new long[L], T;

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
                    int i = b;
                    int j = m;
                    while (true)
                    {
                        if (i < m && j < n)
                        {
                            if (A[j] < A[i])
                                B[b++] = A[j++];
                            else B[b++] = A[i++];
                        }
                        else if (i < m)
                            B[b++] = A[i++];
                        else if (j < n)
                            B[b++] = A[j++];
                        else break;
                    }
                    m = b + p;
                    n = m + p;
                }
                if (m < L)
                {
                    int i = b;
                    int j = m;
                    while (true)
                    {
                        if (i < m && j < L)
                        {
                            if (A[j] < A[i])
                                B[b++] = A[j++];
                            else B[b++] = A[i++];
                        }
                        else if (i < m)
                            B[b++] = A[i++];
                        else if (j < L)
                            B[b++] = A[j++];
                        else break;
                    }
                }
                else do B[b] = A[b];
                    while (++b < L);

                T = A;
                A = B;
                B = T;
            }

            if (A != S)
                A.CopyTo(S, 0);
        }
    }
}