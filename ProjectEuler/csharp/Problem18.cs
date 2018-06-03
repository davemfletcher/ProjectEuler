using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Resources;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// Max Path Sum I
    /// 
    /// By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

    //       3
    //      7 4
    //     2 4 6
    //    8 5 9 3

    //That is, 3 + 7 + 4 + 9 = 23.

    //Find the maximum total from top to bottom of the triangle below:

    //                   75
    //                  95 64
    //                17 47 82
    //               18 35 87 10
    //              20 04 82 47 65
    //             19 01 23 75 03 34
    //            88 02 77 73 07 63 67
    //           99 65 04 28 06 16 70 92
    //          41 41 26 56 83 40 80 70 33
    //        41 48 72 33 47 32 37 16 94 29
    //       53 71 44 65 25 43 91 52 97 51 14
    //      70 11 33 28 77 73 17 78 39 68 17 57
    //     91 71 52 38 17 14 91 43 58 50 27 29 48
    //    63 66 04 68 89 53 67 30 73 16 69 87 40 31
    //  04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

    /// NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.However,
    /// Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force,
    /// and requires a clever method! ;o)
    ///
    ///
    /// 
    /// </summary>
    public class Problem18 : IProblem
    {
        readonly Func<StreamReader, List<int[]>> _myFunc = sr =>
        {
            var data = new List<int[]>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine()?.Trim();
                if (line == null) continue;
                var dataline = line.Split(' ').Select(int.Parse).ToArray();
                Array.Sort(dataline);
                data.Add(dataline);
            }
            return data;
        };


        public Answer Solution()
        {
            return new Answer
            {
                Description = $"Answer = {FirstAttempt()}"
            };
        }

        private double FirstAttempt()
        {
            var listArray = Util.ReadEmbeddedFileAsList("ProjectEuler.Resources.PeData18.txt", _myFunc);
            int[] ansArray = new int[listArray.Count];

            ansArray[0] = listArray[0].Max();
            for (int i = 1; i < listArray.Count; i++)
            {
                var n = listArray[i].Max();

            }


            //listArray.ForEach(n =>
            //{
            //    int i = 0;
            //    if(n.)
            //    ans += n.Max();
            //});

            return 0;
        }

        private double SecondAttempt()
        {


            return 0;
        }
    }
}
