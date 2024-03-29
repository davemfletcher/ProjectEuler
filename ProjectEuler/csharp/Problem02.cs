﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using ProjEuler.Resources;

namespace ProjEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=02"/> 
    /// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

    /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

    /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    /// Answer = 4613732
    ///
    /// </summary>
    public class Problem02 : IProblem
    {
        private const int Limit = 4000000;

        /// <summary>
        /// Every third term in the fibonacci sequence is even
        /// takes 1894 ticks.
        /// </summary>
        /// <returns></returns>
        private long FirstAttempt()
        {
            const int size = 40;
            var fib = Util.FibonacciSequence(size);
            long total = 0;
            for (int i = 2; i < size; i += 3)
            {
                total += fib[i];
                if (total >= Limit) break;
            }
            return total;
        }

        /// <summary>
        /// takes 2087 ticks
        /// </summary>
        /// <returns></returns>
        private int SecondAttempt()
        {
            int a = 1;
            int b = 1;
            int total = 0;
            while (total < Limit)
            {
                int fib = a + b;
                a = b;
                b = fib;
                if (fib % 2 == 0)
                {
                    total += fib;
                }
            }
            return total;
        }

        /// <summary>
        /// The golden ratio is n/n-1 = 1.618. This an approximate ratio between 2 consecutive fib terms (with rounding)
        /// eg 8*1.618 = 13, 34*1.618 = 55
        /// Every third term is even, phi^3 (4.236), 8*4.236=34 (with rounding), 34*4.236=144
        /// This method can be used to skip any number of terms
        /// done in 2474 ticks
        /// </summary>
        /// <returns></returns>
        private int UsingPhi()
        {
            double thirdTerm = Math.Pow(Constants.GoldenRatio, 3);
            int total = 0;
            for (double i = 2; i < 4000000; i = Math.Round(thirdTerm * i))
            {
                total += (int)i;
            }
            return total;
        }

        public Answer Solution()
        {
            return new Answer
            {
                Description = string.Format("{0}", UsingPhi())
            };
        }
    }
}
