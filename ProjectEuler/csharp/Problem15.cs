using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.csharp
{
    public class Problem15 : IProblem
    {

        public struct ValueTuple<T1, T2>
        {

        }




        public Answer GetAnswer()
        {
            var tuple1 = (1, 2);
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item2);

            return new Answer
            {

            };
        }
    }
}
