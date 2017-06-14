using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Resources;

namespace ProjectEuler
{
    /*
     By listing the first six prime numbers: 2,3,5,7,11, and 13, we can see that the 6th prime is 13. What is the 1001st 
     * 1 is not a prime
     * All primes except 2 are odd
     * All primes >3 can be written in the form (6k +/- 1) - If k is an integer this test can determine if it is a prime. 
     * k=1, 5 or 7
     * k=2, 11 or 13
     * k=3, 17 or 19
     * 
     * k=6, 35 (Not a prime) or 37 
     * k=7, 41 or 43
     * 
     * Answer
     * ======
     * prime number: 104743 for 10001st prime
     */
    public class Problem07 : IProblem
    {
        /// <summary>
        /// 6.48 seconds to complete or 64916449 ticks
        /// Produce a list of prime numbers of size limit squared. There will always be one prime factor less than sqrt(num).
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private long FirstAttempt(int limit=2)
        {
            var sieve = Util.PrimeNumbersBelowNumber((long)Math.Pow(limit, 2));
            return sieve[--limit];
        }

        /// <summary>
        /// With the exception of 2 every prime thereafter is odd, therefore odd increments only counting up to limit and counting off prime numbers until limit is reached.
        /// 186544 ticks
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private int SecondAttempt(int limit=2)
        {
            int nthPrime = 2;
            int num = 1;
            while (nthPrime <= limit)
            {
                num = num + 2;
                if (num.IsPrime())
                    nthPrime++;
            }
            return num;
        }

        public Answer GetAnswer()
        {
            const int num = 10001;
            return new Answer  
            {
                Description = string.Format("total primes = {0} Answer {1}", num, SecondAttempt(num))
            };
        }
    }
}
