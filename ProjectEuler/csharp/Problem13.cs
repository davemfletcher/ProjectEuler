using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Resources;

namespace ProjectEuler
{
    /// <summary>
    /// Work out the first ten digits of the sum of the attached one-hundred50-digit numbers.
    /// 
    /// Answer is 5537376230
    /// </summary>

    class Problem13 : Problem
    {
        public override Answer GetAnswer()
        {
            // 27, 000 ticks
            Func<StreamReader, string> myFunc = sr =>
            {
                var result = new BigInteger();
                while (!sr.EndOfStream)
                {
                    result += BigInteger.Parse(sr.ReadLine());
                }

                return result.ToString().Substring(0, 10);
            };

            return new Answer
            {
                Description = Util.ReadEmbeddedFile("projectEuler.Resources.PeData13.txt", myFunc)
            };
        }

    }

   
}
