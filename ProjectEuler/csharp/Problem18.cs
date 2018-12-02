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
    /// By starting at the top of the triangle below and moving to adjacent numbers on the row below,
    /// the maximum total from top to bottom is 23.
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

    /// NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However,
    /// Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force,
    /// and requires a clever method! ;o)
    ///
    ///
    /// 
    /// </summary>
    public class Problem18 : IProblem
    {

        private readonly Func<StreamReader, int[,]> _myFunc = sr =>
        {
            var data = new List<int[]>();
            int[] dataline;
            int lines = 0;

            int j = 0;
            while (!sr.EndOfStream)
            {
                lines++;
                var line = sr.ReadLine()?.Trim();
                if (line == null) continue;
                dataline = line.Split(' ').Select(int.Parse).ToArray();
                data.Add(dataline);
            }

            var inputTriangle = new int[lines, lines];
            foreach (var d in data)
            {
                for (int i = 0; i < d.Length; i++)
                {
                    inputTriangle[j, i] = d[i];
                }

                j++;
            }

            return inputTriangle;
        };

        public Answer Solution()
        {
            return new Answer
            {
                Description = $"Answer = {FirstAttempt()}"
            };
        }

        /// <summary>
        /// Brute force method
        /// </summary>
        /// <param name="inputTriangle"></param>
        /// <returns></returns>
        private int TraverseTriangle(int[,] inputTriangle)
        {
            int posSolutions = (int)Math.Pow(2, inputTriangle.GetLength(0) - 1);
            int largestSum = 0;
            int tempSum, index;

            for (int i = 0; i <= posSolutions; i++)
            {
                tempSum = inputTriangle[0, 0];
                index = 0;
                for (int j = 0; j < inputTriangle.GetLength(0) - 1; j++)
                {
                    var i1 = (i >> j & 1);
                    index = index + i1;
//                    Console.WriteLine($"i={i},({Convert.ToString(i,2)}), j={j}, i1={i1}, index{index}");

                    var sum = inputTriangle[j + 1, index];
                    tempSum += sum;
                }
                if (tempSum > largestSum)
                {
                    largestSum = tempSum;
                }
            }

            return largestSum;
        }

   
        private double FirstAttempt()
        {
            int[,] listArray = Util.ReadAsArray("ProjectEuler.Resources.PeData18.txt", _myFunc);


            return TraverseTriangle(listArray);
        }

  
    }
}
