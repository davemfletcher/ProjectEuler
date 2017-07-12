using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// <see cref="https://projecteuler.net/problem=15"/>
    /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

    //  How many such routes are there through a 20×20 grid?

    //  Answer = 137846528820
    /// </summary>
    public class Problem15 : IProblem
    {
        private const int Grid = 20;

        public Answer Solution()
        {
            return new Answer
            {
                Description = $"Answer is {FirstAttempt()}"
            };
        }

        private double FirstAttempt(int gridSize = Grid)
        {
            //using grid points not squares.
            long[,] grid = new long[gridSize+1, gridSize+1];

            for (int i=0; i< gridSize; i++)
            {
                grid[i, gridSize] = 1;
                grid[gridSize, i] = 1;
            }

            for(int i = gridSize - 1; i >= 0; i--)
            {
                for(int j = gridSize - 1; j >= 0; j--)
                {
                    grid[i, j] = grid[i+1, j] + grid[i, j+1];
                }
            }
            return grid[0, 0];
        }

        /// <summary>
        ///  multiplicative formula
        /// </summary>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        private double SecondAttempt(int gridSize = Grid)
        {
            long paths = 1;
            for(int i=0; i< gridSize; i++)
            {
                paths *= (2 * gridSize) - i;
                paths /= i + 1;
            }
            return paths;

        }
        
    }
}
