using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using ProjectEuler.Resources;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=01"/> 
    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    // Find the sum of all the multiples of 3 or 5 below 1000.

    // Answer : 233168
    /// </summary>
    public class Problem01 : IProblem
    {

        public long FirstAttempt(int num=999)
        {
            long result = 0;
            for (long i = 1; i <= num; i++ )
            {
                if (i % 3 == 0 || i % 5 == 0)
                    result += i;
            }
            return result;
        }

        

        public long SecondAttempt(int num=999)
        {
            var a = Util.Sum(num, 3);
            var b = Util.Sum(num, 5);
            var c = Util.Sum(num, 15);

            return (a + b) - c;
        }

        public long Extra(int num=999)
        {
            var a = Util.Sum(num, 6);
            var b = Util.Sum(num, 7);
            var c = Util.Sum(num, 42);

            return a + b - c;
        }

        private static void FizzBuzz(int limit=100)
        {
            for (int i = 0; i <= limit; i++)
            {
                var output = "";
                if(i%3==0 && i%5==0)
                    output = "FizzBuzz";
                else if(i%3==0)
                    output = "Fizz";
                else if(i%5==0)
                    output = "Buzz";
                else
                    output = i.ToString();

                Console.WriteLine(output);
            }

        }

        public Answer Solution()
        {
            FizzBuzz();
            long ans = SecondAttempt();
            return new Answer
            {
                NumericAnswer = ans,
                Description = string.Format("the sum of all the multiples of 3 or 5 below 1000 = {0}",ans)
            };
        }


    }
}
