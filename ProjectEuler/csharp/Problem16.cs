using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=16"/>
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

    /// What is the sum of the digits of the number 2^1000?
    /// 
    /// Answer = 1366
    /// </summary>
    public class Problem16 : IProblem
    {
        private const int _power = 1000;
        public Answer Solution()
        {
            return new Answer
            {
                Description = $"Answer is {FirstAttempt()}"
            };
        }

        /// <summary>
        /// BigInteger to the rescue, convert integer into an array via a string and back to individual ints before calling the sum function.
        /// 22 Elapsed milliSeconds
        /// 62559 ticks
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        private double FirstAttempt(int power = _power)
        {
            var value = BigInteger.Pow(2, power);
            var intArray = value.ToString().Select(o => (int)char.GetNumericValue(o)).ToArray();
            return intArray.Sum();

        }

        /// <summary>
        /// Kudos to mathblog, shave off the lsd add it to the result and make the number smaller on the next iteration.
        /// 5 Elapsed milliSeconds
        /// 15815 ticks
        /// <seealso cref="http://www.mathblog.dk/project-euler-16/"/>
        /// </summary>
        /// <returns></returns>
        private double SecondAttempt()
        {
            int result = 0;

            BigInteger number = BigInteger.Pow(2, 15);

            while (number > 0)
            {
                result += (int)(number % 10);
                number /= 10;
            }
            return result;
        }

        private double ThridAttempt()
        {

            return 0;
        }
    }
}
