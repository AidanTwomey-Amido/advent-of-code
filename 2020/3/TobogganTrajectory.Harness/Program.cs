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

            foreach (var file in new DirectoryInfo("TobogganTrajectory.Harness/bin/Debug/net5.0/Grid").GetFiles())
            {
                var rows = File.ReadAllLines(Path.Combine( file.DirectoryName, file.FullName));
                
                var offsets = new []{(1,1), (3,1), (5,1), (7,1), (1,2)};

                var treeCounts = offsets
                    .Select(o => calculator.CountTrees(rows, o))
                    .Aggregate(1, (total, next) => total * next);

                Console.WriteLine($"{file.Name}: {treeCounts}");
            }
        }
    }
}
