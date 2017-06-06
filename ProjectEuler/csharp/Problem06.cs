
using System;
using ProjectEuler.Resources;

namespace ProjectEuler
{

    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,

    /// 1^2 + 2^2 + ... + 10^2 = 385
    /// The square of the sum of the first ten natural numbers is,

    /// (1 + 2 + ... + 10)^2 = 55^2 = 3025
    /// The difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// 
    /// Answer
    /// ======
    /// //answer = 25164150
    /// </summary>
    class Problem06 : Problem
    {
        /// <summary>
        /// to sum use Nth triangle, it is the addition version of factorial
        /// For limit = 100,000 - ticks = 102K
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private long FirstAttempt(long limit = 100)
        {
            var squareOfSums = (long) Math.Pow(Util.NthTriangle(limit), 2);

            long sumOfSquares = 0;
            for (long i = 0; i <= limit; i++)
            {
                sumOfSquares += (long)Math.Pow(i, 2);
            }

            return (long)(squareOfSums - sumOfSquares);
        }

        /// <summary>
        /// TODO wrong answer with this attempt
        /// For limit = 100,000 - ticks = 10K
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private long SecondAttempt(long limit = 100)
        {
            var squareOfSums = (long)Math.Pow(Util.NthTriangle(limit), 2);
            var sumOfSquares = SquareOfSums(limit);

            return (long)(squareOfSums - sumOfSquares);
        }

        private long SquareOfSums(long limit=100)
        {
            long result = (((2*limit + 1)*(limit + 1))/limit)/6;
            return result;
        }

        public override Answer GetAnswer()
        {
            return new Answer
            {
                Description = string.Format("{0}", SecondAttempt())
            };
        }
            

    }


}
