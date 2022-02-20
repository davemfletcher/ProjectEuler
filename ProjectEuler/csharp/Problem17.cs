using ProjEuler.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ProjEuler.csharp
{
    /// <summary>
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    // If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

    // NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115
    // (one hundred and fifteen) contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage.

    // Answer = 21124

    /// </summary>
    public class Problem17 : IProblem
    {
        public Answer Solution()
        {
            //var ans = FirstAttempt(1000000);
            var ans = SecondAttempt(1000000);
            return new Answer
            {
                Description = $"Answer is {ans}",
                NumericAnswer = ans
            };
        }


        /// <summary>
        /// cref="https://github.com/Humanizr/Humanizer#number-to-words"
        /// for a 1-1M = 5272 Elapsed milliSeconds 14458134 ticks
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private double FirstAttempt(int limit = 1000)
        {
            double answer = 0;
            Enumerable.Range(1, limit).ToList().ForEach(
                n =>
                {
                    var word = n.ToWords();
                    word = word.Replace("-", string.Empty).Replace(" ", string.Empty);
                    answer += word.ToString().Length;
                }
             );
            return answer;
        }

        /// <summary>
        /// cref="https://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp"
        /// for a 1-1M = 3910 Elapsed milliSeconds 10724671 ticks
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        private double SecondAttempt(int limit = 1000)
        {
            double answer = 0;
            Enumerable.Range(1, limit).ToList().ForEach(
                n =>
                {
                    var word = NumberToWords(n);
                    word = word.Replace("-", string.Empty).Replace(" ", string.Empty);
                    answer += word.ToString().Length;
                }
            );
            return answer;
        }

        private static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if (number / 1000000 > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if (number % 10 > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
