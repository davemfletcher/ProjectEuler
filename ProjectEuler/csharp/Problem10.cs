using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Resources;

namespace ProjectEuler
{
    /*
     *  The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
     *  Find the sum of all the primes below two million.
     *  answer: 142913828922 
     * */
    public class Problem10 : Problem
    {
        /// <summary>
        /// Start with 2 (1 is not a prime) increment in odd intervals and test for a prime.
        /// 9,000,000 ticks to complete 
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private long FirstAttempt(int max)
        {
            long sum = 2;
            for (int i = 3; i < max; i+=2)
            {
                if (i.IsPrime())
                    sum += i;
            }
            return sum;
        }

        /// <summary>
        /// Creating the EratosthenesSieve is quicker than iteratively testing for a prime.
        /// 600,000 ticks to complete
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private long SecondAttempt(int max)
        {
            bool[] eratosthenesSieve = Util.EratosthenesSieve(max);
            long sum = 2;

            for(int i = 3; i < eratosthenesSieve.Length; i+=2)
            {
                if (eratosthenesSieve[i])
                    sum += i;
            }
            return sum;
        }

        public override Answer GetAnswer()
        {
            const int max = 2000000;
            return new Answer
            {
                Description = SecondAttempt(max).ToString()
            };

        }
    }
}
