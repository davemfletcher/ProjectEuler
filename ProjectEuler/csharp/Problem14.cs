using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace ProjectEuler
{
    /*
     * The following iterative sequence is defined for the set of positive integers:

            n → n/2 (n is even)
            n → 3n + 1 (n is odd)

        Using the rule above and starting with 13, we generate the following sequence:

        13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
        It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

        Which starting number, under one million, produces the longest chain?

        NOTE: Once the chain starts the terms are allowed to go above one million.

     * Answer: 837799 
     */
    public class Problem14 : IProblem
    {
        private const int Limit = 1000000;

        public Answer GetAnswer()
        {
            var answer = FirstAttempt(Limit);
            return new Answer
            {
                NumericAnswer = answer,
                Description = "Largest number of term for Collatz problem: "+answer
            };
        }

        /// <summary>
        /// Func are great, this is a reminder to start using them more. First mistake was using a int instead of a long for v. Didn't expect the compute to overflow, but it did on i=113383, the tree grew up 120 nodes and overflowed the int.max. The `checked` keyword will throw an exception on overflow.
        /// </summary>
        /// <returns></returns>
        private Func<int, double> FirstAttempt = limit =>
        {
            // 3263 Elapsed milliSeconds
            // 8949113 ticks
            var largestNumberOfTerms = 0;
            double numWithMostTerms = 0;
            for (int i = 5; i < limit;  i++)
            {
                var terms = 1;
                long v = i;
                while (v > 1)
                {
                    v = v % 2 == 0 ? v / 2 : checked(v * 3 + 1);
                    terms++;
                }
                if (terms <= largestNumberOfTerms) continue;
                largestNumberOfTerms = terms;
                numWithMostTerms = i;
            }
            return numWithMostTerms;
        };

        /// <summary>
        /// Cache the terms. When the calculated variable dips below the starting value the cache should know how many steps to home base.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private double SecondAttempt(int limit = Limit)
        {
            // 178 Elapsed milliSeconds
            // 489804 ticks
            var largestNumberOfTerms = 0;
            int[] cache = new int[limit];
            double numWithMostTerms = 0;
            cache[1] = 1;

            for (int i = 2; i < limit; i++)
            {
                cache[i] = 1;
                var terms = 0;
                long v = i;
                while (v > 1)
                {
                    if(v < i)
                    {
                        terms += cache[v];
                        break;
                    }
                    v = v % 2 == 0 ? v / 2 : checked(v * 3 + 1);
                    terms++;
                }
                cache[i] = terms; 
                if (terms <= largestNumberOfTerms) continue;
                largestNumberOfTerms = terms;
                numWithMostTerms = i;
            }
            return numWithMostTerms;
        }
    }
}
