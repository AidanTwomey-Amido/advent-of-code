using System;
using System.IO;
using System.Linq;
using TobogganTrajectory.Library;

namespace TobogganTrajectory.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the toboggan");

            var calculator = new TrajectoryCalculator();
            var combiner = new TrajectoryCombiner(calculator);

            foreach (var file in new DirectoryInfo("TobogganTrajectory.Harness/bin/Debug/net5.0/Grid").GetFiles())
            {
                var rows = File.ReadAllLines(Path.Combine(file.DirectoryName, file.FullName));

                int combined = combiner.CombineTrajectories(rows, (1, 1), (3, 1), (5, 1), (7, 1), (1, 2));

                Console.WriteLine($"{file.Name}: {combined}");
            }
        }
    }
}
