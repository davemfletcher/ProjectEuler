using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace projectEuler.Resources
{
    public static class Util
    {
        /// <summary>
        /// Sum using repeating term up to and including limit
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public static long Sum(long limit, long term)
        {
            long numberOfTerms = limit / term ;
            long t = term * numberOfTerms;
            long lastTerm = t;
//            int lastTerm = t == limit ? limit - term : t;

            return Sum(numberOfTerms, term, lastTerm);
        }

        public static long Sum(long numberOfTerms, long firstTerm, long lastTerm)
        {
            return numberOfTerms*(firstTerm + lastTerm) / 2;
        }

        /// <summary>
        /// Addition factorial
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static long NthTriangle(long limit)
        {
            return (limit * (limit + 1)) / 2;
        }

        public static double SumOfSquares(double num)
        {
            double answer = num*(2*num + 1)*(num + 1)/6;
            return answer;
        }

        /// <summary>
        /// Used to find all prime numbers up to limit set
        /// </summary>
        /// <param name="limit">Calculate largest prime below limit limit</param>
        /// <returns></returns>
        public static bool[] EratosthenesSieve(long limit)
        {
            var eSieve = new bool[limit + 1];
            eSieve.Populate(true);

            for (int i = 2; i <= limit; i++)
            {
                if (!eSieve[i]) continue;
                for (int j = i * 2; j <= limit; j += i)
                    eSieve[j] = false;
            }
            return eSieve;
        }

        public static IEnumerable<long> SieveOfEratosthenes(int upperLimit)
        {
            int sieveBound = (upperLimit - 1) / 2,
                upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            var primeBits = new bool[sieveBound + 1];

            yield return 2;

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (!primeBits[i])
                {
                    yield return 2 * i + 1;

                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        primeBits[j] = true;
                    }
                }
            }

            for (int i = upperSqrt + 1; i <= sieveBound; i++)
            {
                if (!primeBits[i])
                {
                    yield return 2 * i + 1;
                }
            }
        }

        /// <summary>
        /// Create a list of Prime numbers (ignore 1) of 'limit' length
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<long> PrimeNumbersBelowNumber(long limit)
        {
            bool[] es = EratosthenesSieve(limit-1);
            
            var pn = new List<long>();
            for (long i = 2; i < es.Length; i++)
            {
                if (es[i])
                    pn.Add(i);
            }
            return pn;
        }

        /// <summary>
        /// Send a list of prime factors for number given
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IList<long> PrimeFactors(long num)
        {
            return PrimeNumbersBelowNumber(num).Where(prime => num%prime == 0).ToList();
        }

        public static long[] FibnocciSequence(int max)
        {
            int firstTerm = 1;
            int secondTerm = 2;
            var sqn = new long[max + 1];
            sqn[0] = 1;
            sqn[1] = 1;
            for (int i = 2; i <= max; i++)
            {
                int fib = firstTerm + secondTerm;
                sqn[i] = secondTerm;

                firstTerm = secondTerm;
                secondTerm = fib;
            }
            return sqn;
        }

        /// <summary>
        /// Read an embedded file from the calling assembly. 
        /// </summary>
        /// <param name="fileName">Name of the resource to read, with full namespace qualification</param>
        /// <param name="myFunc"></param>
        /// <returns>file content</returns>
        public static string ReadEmbeddedFile(string fileName, Func<StreamReader, string> myFunc = null)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                if (stream == null)
                {
                    throw new ArgumentException(string.Format("Could not resolve fileName {0}", fileName));
                }
                using (var reader = new StreamReader(stream))
                {
                    if(myFunc == null)
                        return reader.ReadToEnd();

                    return myFunc(reader);
                }
            }
        }
    }
}
