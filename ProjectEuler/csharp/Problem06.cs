
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
    class Problem06 : IProblem
    {
        const long Limit = 100;
        /// <summary>
        /// to sum use Nth triangle, it is the addition version of factorial
        /// Time: 2 Elapsed milliSeconds, 7758 ticks
        /// Limit = 1000,000 Time: 83 Elapsed milliSeconds, 228,222 ticks
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private long FirstAttempt(long limit = Limit)
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
        /// A formula for sum of squares
        /// Limit = 1000,000 Time: 1 Elapsed milliSeconds, 4,299 ticks
        /// </summary>
        /// <param name="limit"></param>
        /// <seealso cref="http://www.mathblog.dk/project-euler-problem-6/"/>
        /// <returns></returns>
        private long SecondAttempt(long limit = Limit)
        {
            var squareOfSums = (long)Math.Pow(Util.NthTriangle(limit), 2);
            var sumOfSquares = SquareOfSums(limit);

            return (long)(squareOfSums - sumOfSquares);
        }

        private long SquareOfSums(long n=Limit)
        {
            long result =
                (n * (n + 1) * (2 * n + 1)) / 6;
            return result;
        }

        public Answer GetAnswer()
        {
            return new Answer
            {
                Description = string.Format("{0}", SecondAttempt(1000000))
            };
        }
            

    }


}
