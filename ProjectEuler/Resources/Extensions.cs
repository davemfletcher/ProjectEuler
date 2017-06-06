using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Resources
{
    public static class Extensions
    {
        public static bool IsPrime(this int number)
        {
            return CheckIfPrime(number);
        }

        public static bool IsPrime(this long number)
        {
            return CheckIfPrime(number);
        }

        private static bool CheckIfPrime(long number)
        {
            if ((number % 2) == 0)
                return number == 2;

            var sqrt = (int)Math.Sqrt(number);
            for (int t = 3; t <= sqrt; t = t + 1)
            {
                if (number % t == 0)
                    return false;
            }
            return number != 1;
        }

        public static IList<T> Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
            return arr;
        }
    }
}
