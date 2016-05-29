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
            if (L0 != L) B[L0] = A[L0];
            T = A;
            A = B;
            B = T;

            int p = 1;
            while ((p = p << 1) < L)
            {
                int b = 0;
                while (true)
                {
                    int m = b + p;
                    int n = m + p;
                    if (n < L)
                    {
                        for (int i = b, j = m, k = b; k < n; k++)
                            B[k] = (i == m || (j < n && A[j] < A[i])) ? A[j++] : A[i++];
                        b = n;
                    }
                    else
                    {
                        if (m < L) for (int i = b, j = m, k = b; k < L; k++)
                            B[k] = (i == m || (j < L && A[j] < A[i])) ? A[j++] : A[i++];
                        break;
                    }
                }
                T = A;
                A = B;
                B = T;
            }
            return A;
        }

    }
}
