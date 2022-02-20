using ProjectEuler.adventOfCode._2018;
using ProjEuler.csharp;
using ProjEuler;

class Program
{
    static void Main(string[] args)
    {
        var stopWatch = new System.Diagnostics.Stopwatch();
        IProblem problem;
        stopWatch.Start();

        //var problem = new FizzBuzz();
        problem = new Day01();

        #region Euler

        problem = new Problem01();
        //problem = new Problem02();
        //problem = new Problem03();
        //problem = new Problem04();
        //problem = new Problem05();
        //problem = new Problem06();
        //problem = new Problem07();
        //problem = new Problem08();
        //problem = new Problem09();
        //problem = new Problem10();
        //problem = new Problem11();
        //problem = new Problem12();
        //problem = new Problem13();
        //problem = new Problem14();
        //problem = new Problem15();
        //problem = new Problem16();
        //problem = new Problem17();
        //            problem = new Problem18();

        #endregion

        var answer = problem.Solution();
        stopWatch.Stop();

        Console.WriteLine(problem.GetType().Name + @" = " + answer.Description);

        Console.WriteLine(stopWatch.Elapsed + @" Elapsed");
        Console.WriteLine(stopWatch.ElapsedMilliseconds + @" Elapsed milliSeconds");
        Console.WriteLine(stopWatch.ElapsedTicks + @" ticks");
        Console.ReadLine();
    }
}
