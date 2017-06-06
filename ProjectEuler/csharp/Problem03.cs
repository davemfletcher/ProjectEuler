using System;
using System.Linq;
using ProjectEuler.Resources;

namespace ProjectEuler
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.

    /// What is the largest prime factor of the number 600851475143 ?
    /// Answer
    /// ======
    /// 600851475143; 8462696833 * 71
    /// 8462696833; 10086647 * 839
    /// 10086647; 6857 * 1471
    /// 6857; has no prime factors it is a prime number
    /// 6857 * 87625999 = 600851475143
    /// 87625999 is not a prime number, factors are: 1471 (is a prime) * 59569
    /// could use sieve of Eratosthenes
    /// </summary>
    class Problem03 : Problem
    {
        /// <summary>
        /// 2227 ticks to run
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private long FirstAttempt(long num)
        {
            for(long d = 2; d < Math.Sqrt(num); d++)
                while (num % d == 0)
                {
                    num /= d;
                }
            
            return num;
        }

        /// <summary>
        /// Every composite number has a prime factor less than or equal to it's square root
        /// 1900 ticks to run
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private long SecondAttempt(long num)
        {
            var primeNumbers = Util.PrimeNumbersBelowNumber((int)Math.Sqrt(num)).Reverse();

            return primeNumbers.FirstOrDefault(primeNumber => num%primeNumber == 0);
        }

        public override Answer GetAnswer()
        {
            const long limit = 600851475143;
            return new Answer
            {
                Description = string.Format("{0}", SecondAttempt(limit))
            };
        }
    }
}
