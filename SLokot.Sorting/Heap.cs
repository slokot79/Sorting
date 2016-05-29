using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    public class Heap
    {
        public static void sort(long[] A)
        {
            int L = A.Length;
            for (int k = 2; k <= L; k += 1)
            {
                int i = k, j = k >> 1;
                long c = A[i - 1], p;
                while (j >= 1 && c > (p = A[j - 1]))
                {
                    A[i - 1] = p;
                    i = j;
                    j >>= 1;
                }
                A[i - 1] = c;
            }

            for (int l = L; l > 1; l -= 1)
            {
                int i = 1, j = 2, k = 3;
                long c = A[l - 1], s; A[l - 1] = A[0];
                while (true)
                {
                    if (k < l && (s = A[k - 1]) > A[j - 1] && s > c)
                    {
                        A[i - 1] = s;
                        i = k;
                    }
                    else if (j < l && (s = A[j - 1]) > c)
                    {
                        A[i - 1] = s;
                        i = j;
                    }
                    else break;
                    j = i << 1;
                    k = j + 1;
                }
                A[i - 1] = c;
            }
        }
    }
}
