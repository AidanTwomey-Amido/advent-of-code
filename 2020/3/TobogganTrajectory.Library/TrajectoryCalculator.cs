using System.Collections.Generic;
using System.Linq;

namespace TobogganTrajectory.Library
{
    public class TrajectoryCalculator
    {
        public int CountTrees(string[] rows, (int right, int down) offset)
        {
            int columnPosition = 0;

            bool skipRows(string row, int index) => index % offset.down == 0;

            int isCollision((int length, int[] positions) row)
            {
                bool collision = LineScanner.IsTree(row.positions, columnPosition, row.length);

                columnPosition+=offset.right;

                return collision ? 1 : 0;
            }

            return rows
                    .Where(skipRows)
                    .Select(getCollisions)
                    .Aggregate(0, (total, next) => total + isCollision(next));
        }

        private (int, int[]) getCollisions(string row)  => ( row.Length, LineScanner.Scan(row));
    }
}
