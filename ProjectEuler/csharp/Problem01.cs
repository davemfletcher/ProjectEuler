using System;
using System.Collections.Generic;
using System.IO;
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


        private long SecondAttempt(int num=999)
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
        

        public Answer Solution()
        {
            long ans = SecondAttempt();
            return new Answer
            {
                NumericAnswer = ans,
                Description = $"the sum of all the multiples of 3 or 5 below 1000 = {ans}"
            };
        }


        public static int priceCheck(List<string> products, List<float> productPrices, List<string> productSold, List<float> soldPrice)
        {
            if (productSold == null || soldPrice == null)
            {
                return 0;
            }

            int errors = 0;
            for(int i =0; i < productSold.Count;i++)
            {
                // compare the sold price to the listed price, we have to assume the price index matches the product indexes.
                var soldItem = productSold[i];
                var productIndex = products.IndexOf(soldItem);
                if (productIndex == -1)
                {
                    // product not found
                    // TODO should probably throw an exception, or log it. It can fall through and be included as an error for now.
                }

                if (Math.Abs(productPrices[productIndex] - soldPrice[i]) > 0.001)
                {
                    errors++;
                }
            }

            return errors;
        }

    }
}
