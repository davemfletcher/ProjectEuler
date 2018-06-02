using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// For FizzBuzz N=10,000,000
    /// First Attempt took 14660 Elapsed milliSeconds, 40201355 ticks
    /// Second Attempt took 6176 Elapsed milliSeconds, 16935925 ticks
    /// Third Attempt 7383 Elapsed milliSeconds, 20247910 ticks
    /// </summary>
    public class FizzBuzz : IProblem
    {
        private string FirstAttempt(int limit = 100)
        {
            var output = new string[limit+1];
            for (int i = 0; i <= limit; i++)
            {
                var tmp = "";
                if (i % 3 == 0 && i % 5 == 0)
                    tmp ="FizzBuzz";
                else if (i % 3 == 0)
                    tmp = "Fizz";
                else if (i % 5 == 0)
                    tmp = "Buzz";
                else
                    tmp = i.ToString();


                output[i] = $"{tmp}, ";
            }
            //output.ToList().ForEach(e => Console.WriteLine(e.ToString()));
            //return string.Join("\n", output);
            return "to long to print";

        }


        private string SecondAttempt(int limit = 100)
        {
            var output = new StringBuilder();
            Enumerable.Range(1, limit).ToList().ForEach(
                n => output.AppendLine(
                    (n % 15 == 0)
                        ? "FizzBuzz"
                        : (
                            (n % 3 == 0)
                                ? "Fizz"
                                : (n % 5 == 0 ? "Buzz" : n.ToString())
                        )
                )
            );

            return limit > 100 ? "to long to print" : output.ToString();

        }

        private string Test(int num, int dev, string result)
        {
            return num % dev == 0 ? result : "";
        }


        /// <summary>
        /// cref="https://www.youtube.com/watch?v=FyCYva9DhsI" kevlin henney NDC conference talk (his code in comments and it was in js)
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private string ThirdAttempt(int limit = 100)
        {
            var output = new StringBuilder();

            Enumerable.Range(1, limit).ToList().ForEach(
                n =>
                {
                    var fizz = Test(n, 3, "Fizz");
                    var buzz = Test(n, 5, "Buzz");
                    string ans = (fizz + buzz).Length > 0 ? fizz + buzz : n.ToString();
                    output.AppendLine(ans);
                }

            //(d, s, x) => n % d == 0: _ => s+x(""): x
            //var fizz = x => test(3, "Fizz", x);
            //var buzz = x => test(5, "Buzz", x);
            //return fizz(buzz(x=>x)).n.toString()
            );
            return limit > 100 ? "to long to print" : output.ToString();

        }

        public Answer Solution()
        {
            //string ans = FirstAttempt(10000000);
            //string ans = SecondAttempt(10000000);
            string ans = ThirdAttempt(10000000);

            return new Answer
            {
                Description = $"Fizz Buzz = {ans}"
            };
        }

    }
}
