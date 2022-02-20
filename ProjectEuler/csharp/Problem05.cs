using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjEuler.Resources;

namespace ProjEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=05"/> 
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// 
    /// Answer : 232792560
    /// ======
    /// 
    /// </summary>
    class Problem05 : IProblem
    {

        /// <summary>
        /// Started with at k=10 (2520) a safe low number and moved up in 20 increments.  
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int FirstAttempt(int num = 2520)
        {
            int answer = 0;
            bool done = false;
            while (!done)
            {
                for (int i = 20; i > 1; i--)
                {
                    if (i == 2 && num % i == 0)
                    {
                        answer = num;
                        done = true;
                    }

                    else if (num % i != 0)
                        break;
                }

                num += 20;
            }
            return answer;
        }

        /// <summary>
        /// prime factorisation for the highest number (N) divisible by all K (including K).  
        /// K=2, N=2
        /// K=3, N=2*3 = 6
        /// K=4, N=2*3*2 = 12 - (included 2 again to include 4: 2*2=4)
        /// K=5, N=2*3*2*5 = 60
        /// K=6, not needed 2*3 already included in previous: answer is still the same (60)
        /// K=7, N=2*3*2*5*7 = 420
        /// K=8, N=2*3*2*5*7*2 = 840 - needed another 2 to get 8: 2*2*2=8
        /// K=9, N=2*3*2*5*7*2*3 = 2520 - needed another 3 to get 9
        /// K=10 not needed 10 can already be calculated from K=9
        /// </summary>
        /// <returns></returns>
        private long SecondAttempt(long N = 20)
        {
            // TOO damn hard
            return -1;
        }

        /// <summary>
        /// Find all the primes from 1 to N. Then for each prime , find the largest pow such that P^pow lt 20 holds.
        /// Then multiply the results together.
        /// 2^4=16, 2^5=32
        /// 3^2=9, 3^3=27
        /// 5^1=5, 5^2=25
        /// The rest of the primes will have ^1, for N=20
        /// 2^4 * 3^2 * 5 * 7 * 11 * 13 * 17 * 19 = 232792560 
        /// Takes 1900 ticks
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        private long ThirdAttempt(long N = 20)
        {
            var primeFactors = new List<int>();
            var primes = Util.PrimeNumbersBelowNumber(N);
            foreach (var prime in primes)
            {
                bool done = false;
                int pow = 1;
                while (!done)
                {
                    var p = Math.Pow(prime, ++pow);
                    if (p > N)
                    {
                        primeFactors.Add(pow - 1);
                        done = true;
                    }
                }
            }
            return primes.Zip(primeFactors,
                (p, pf) => (long)Math.Pow(p, pf))
                .Aggregate((a, b) => a * b);
        }


        public Answer Solution()
        {
            //            int num = 232750000;
            return new Answer
            {
                Description = string.Format("{0}", FirstAttempt())
            };
        }
    }
}
