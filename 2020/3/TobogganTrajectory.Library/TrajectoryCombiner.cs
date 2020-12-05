using System.Linq;

namespace TobogganTrajectory.Library
{
    public class TrajectoryCombiner
    {
        private readonly TrajectoryCalculator calculator;
        public TrajectoryCombiner(TrajectoryCalculator calculator)
        {
            this.calculator = calculator;
        }

        public int CombineTrajectories(string[] rows, params (int, int)[] offsets)
        {
            return offsets
                    .Select(o => calculator.CountTrees(rows, o))
                    .Aggregate(1, (total, next) => total * next);
        }
    }
}
