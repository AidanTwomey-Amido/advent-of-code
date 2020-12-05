using System.Collections.Generic;
using System.Linq;

namespace TobogganTrajectory.Library
{
    public class TrajectoryCalculator
    {
        public int CountTrees(string[] rows, (int right, int down) offset)
        {
            int columnPosition = 0;

            int isCollision((int length, int[] positions) row)
            {
                bool collision = LineScanner.IsTree(row.positions, columnPosition, row.length);

                columnPosition+=offset.right;

                return collision ? 1 : 0;
            }

            return rows
                    .Where((value, index) => index % offset.down == 0)
                    .Select(GetCollisions)
                    .Aggregate(0, (total, next) => total + isCollision(next));
        }

        private (int, int[]) GetCollisions(string row)  => ( row.Length, LineScanner.Scan(row));
    }
}
