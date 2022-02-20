using ProjEuler;
using System.Linq;

namespace ProjEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=04"/> 
    /// A palindromic number reads the same both ways. 
    /// The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// 
    /// Answer is 906609
    /// </summary>
    class Problem04 : IProblem
    {
        /// <summary>
        /// Highest palindrome, therefore start with the highest numbers and iterate down
        /// 1866 ticks to run
        /// </summary>
        /// <returns></returns>
        private int FirstAttempt()
        {
            int maxPalindrome = 0;
            for (int i = 1000; i > 100; i--)
            {
                for (int j = 1000; j > 100; j--)
                {
                    int x = i * j;
                    if (isPalindrome(x) && x > maxPalindrome)
                    {
                        maxPalindrome = x;
                    }
                }
            }

            return maxPalindrome;
        }

        private bool isPalindrome(int num)
        {
            var numChars = num.ToString().ToCharArray();

            return !numChars.Where((t, i) => t != numChars[numChars.Length - 1 - i]).Any();

            //            Old way
            //            for (int i = 0; i < numChars.Length; i++)
            //            {
            //                if (numChars[i] != numChars[numChars.Length - 1 - i])
            //                    return false;
            //            }
            //            
            //            return true;
        }

        public Answer Solution()
        {
            return new Answer
            {
                Description = string.Format("{0}", FirstAttempt())
            };
        }
    }
}
