using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Resources;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=13"/>
    /// Work out the first ten digits of the sum of the attached one-hundred 50-digit numbers.
    /// 
    /// Answer is 5537376230
    /// </summary>

    class Problem13 : IProblem
    {
        private string MyFunc(StreamReader sr)
        {
            var result = new BigInteger();
            while (!sr.EndOfStream)
            {
                result += BigInteger.Parse(sr.ReadLine());
            }

            return result.ToString().Substring(0, 10);
        }

        public Answer Solution()
        {
            // 13 Elapsed milliSeconds
            // 36277 ticks


            return new Answer
            {
                Description = Util.ReadEmbeddedFile("ProjectEuler.Resources.PeData13.txt", MyFunc)
            };
        }

    }

   
}
