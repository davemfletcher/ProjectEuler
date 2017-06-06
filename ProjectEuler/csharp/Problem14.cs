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
    public class Problem14 : Problem
    {
        private const int Limit = 1000000;

        public override Answer GetAnswer()
        {
//            var answer = SecondAttempt();
            var answer = FirstAttempt();
            return new Answer
            {
                NumericAnswer = answer,
                Description = "Largest number of term for Collatz problem: "+answer
            };
        }

//        private long SecondAttempt()
//        {
//
//        }

        /// <summary>
        /// First mistake was using a int instead of a long for v. Didn't expect the compute to overflow, but it did on i=113383, the tree grew 120 nodes and overflowed when computing v = 827370449 (odd number compute).
        /// </summary>
        /// <returns></returns>
        private double FirstAttempt()
        {
            var largestNumberOfTerms = 0;
            var term = 0;
            for (int i = 5; i < Limit; i++)
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
                term = i;
            }
            return term;
        }
    }
}
