using System.IO;
using System.Numerics;
using ProjEuler;
using ProjEuler.Resources;

namespace ProjectEuler.adventOfCode._2018
{
    public class Day01 : IProblem
    {
        public Day01()
        {
            
        }

        private string MyFunc(StreamReader sr)
        {
            var result = new BigInteger();
            while (!sr.EndOfStream)
            {
                result += BigInteger.Parse(sr.ReadLine());
            }

            return result.ToString();
        }


        private string FirstAttempt()
        {
            return Util.ReadEmbeddedFile("ProjectEuler.Resources.Advent01.txt", MyFunc);
        }

        public Answer Solution()
        {
            var result = FirstAttempt();
            return new Answer(){Description = result};
        }
    }
}
