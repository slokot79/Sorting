using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLokot.Sorting
{
    public class Heap
    {
        public static void Sort(long[] A)
        {
            if (A == null) return;

            int L = A.Length;
            if (L < 2) return;

            if (L == 2)
            {
                if (A[0] > A[1])
                {
                    long c = A[0];
                    A[0] = A[1];
                    A[1] = c;
                }
            }
            else if (L == 3)
            {
                long l = A[0];
                long m = A[1];
                long r = A[2];

                if (l > r)
                {
                    if (m > l)
                    {
                        A[0] = r;
                        A[1] = l;
                        A[2] = m;
                    }
                    else if (m < r)
                    {
                        A[0] = m;
                        A[1] = r;
                        A[2] = l;
                    }
                    else
                    {
                        A[0] = r;
                        A[2] = l;
                    }
                }
                else
                {
                    if (m > r)
                    {
                        A[1] = r;
                        A[2] = m;
                    }
                    else if (m < l)
                    {
                        A[0] = m;
                        A[1] = l;
                    }
                }
            }
            else if (L < 16)
            {
                int pos = 0;
                long min = A[0];
                for (int k = 1; k < L; k += 1)
                {
                    if (A[k] < min)
                    {
                        min = A[k];
                        pos = k;
                    }
                }
                if (pos > 0)
                {
                    A[pos] = A[0];
                    A[0] = min;
                }

                for (int k = 2; k < L; k += 1)
                {
                    int i = k, j = k - 1;
                    long c = A[i], p;
                    while (c < (p = A[j]))
                    {
                        A[i] = p;
                        i = j;
                        j -= 1;
                    }
                    A[i] = c;
                }
            }
            else
            {
                int pos = 0;
                long max = A[0];
                for (int k = 1; k < L; k += 1)
                {
                    if (A[k] > max)
                    {
                        max = A[k];
                        pos = k;
                    }
                }
                if (pos > 0)
                {
                    A[pos] = A[0];
                    A[0] = max;
                }

                for (int k = 4; k <= L; k += 1)
                {
                    int i = k, j = k >> 1;
                    long c = A[i - 1], p;
                    while (c > (p = A[j - 1]))
                    {
                        A[i - 1] = p;
                        i = j;
                        j >>= 1;
                    }
                    A[i - 1] = c;
                }

                for (int l = L; l > 4; l -= 1)
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

                long t = A[3];
                A[3] = A[0];
                A[0] = t;

                t = A[2];
                if (t < A[1])
                {
                    A[2] = A[1];
                    if (t < A[0])
                    {
                        A[1] = A[0];
                        A[0] = t;
                    }
                    else A[1] = t;
                }
            }
        }
    }
}