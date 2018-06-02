using ProjectEuler.csharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //var problem = new FizzBuzz();

            //var problem = new Problem01();
            //var problem = new Problem02();
            //var problem = new Problem03();
            //var problem = new Problem04();
            //var problem = new Problem05();
            //var problem = new Problem06();
            //var problem = new Problem07();
            //var problem = new Problem08();
            //var problem = new Problem09();
            //var problem = new Problem10();
            //var problem = new Problem11();
            //var problem = new Problem12();
            //var problem = new Problem13();
            //var problem = new Problem14();
            //var problem = new Problem15();
            //var problem = new Problem16();
            var problem = new Problem17();

            var answer = problem.Solution();
            stopWatch.Stop();

            Console.WriteLine(problem.GetType().Name + @" = " + answer.Description);

            Console.WriteLine(stopWatch.Elapsed + @" Elapsed");
            Console.WriteLine(stopWatch.ElapsedMilliseconds + @" Elapsed milliSeconds");
            Console.WriteLine(stopWatch.ElapsedTicks + @" ticks");
            Console.ReadLine();
        }
    }
}
