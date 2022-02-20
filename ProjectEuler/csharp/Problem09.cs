using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEuler.csharp
{
    /* <see cref="https://projecteuler.net/problem=09"/>
     * A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

        a*a + b*b = c*c
        For example, 3*3 + 4*4 = 9 + 16 = sqrt(25) = 5.

        There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        Find the product abc.

     * Answer:  31875000
     * Facts:   Every Pythagorean Triplet a >= 3, a+b+c is even
     *          a*a + b*b = c*c AND a+b+c=1000
     * a=200, b=375, c=425
     */
    class Problem09 : IProblem
    {
        /// <summary>
        /// The most straightforward approach is to simply loop over a and b and then check
        /// whether a^2 + b^2 = (s − a − b)^2
        /// 22000 ticks to complete
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private int FirstAttempt(int max)
        {
            for (int a = 0; a < max; a++)
            {
                for (int b = a + 1; b < max; b++)
                {
                    int c = max - a - b;

                    if (c <= b) break;

                    if (a * a + b * b == c * c)
                    {
                        //                        Console.WriteLine(string.Format("a:{0} b:{1} c:{2}",a,b,c));
                        return a * b * c;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Using a=2mn, b=m^2-n^2, c=m^2+n^2. a+b+c=1000 by substitution = 2m(n+m)=1000
        /// m > n. Calculate m and n, m not going to be larger than sqrt(1000)
        /// ticks 9587 to complete
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private int SecondAttempt(int max)
        {
            var n = 1;
            int m;
            var finished = false;

            for (m = (int)Math.Sqrt(max); m > n; m--)
            {
                while (n < m)
                {
                    if (2 * m * (n + m) == max)
                    {
                        finished = true;
                        break;
                    }
                    n++;
                }
                if (finished)
                    break;
                n = 1;
            }
            if (!finished) return -1;

            //we know m and n, calculate a,b,c
            var a = 2 * m * n;
            var b = (int)(Math.Pow(m, 2) - Math.Pow(n, 2));
            var c = (int)(Math.Pow(m, 2) + Math.Pow(n, 2));

            if ((int)Math.Pow(a, 2) + (int)Math.Pow(b, 2) != (int)Math.Pow(c, 2))
                return -1;

            return a * b * c;
        }

        public Answer Solution()
        {
            return new Answer()
            {
                Description = FirstAttempt(1000).ToString()
            };
        }
    }
}
