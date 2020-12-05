using System.Collections.Generic;

namespace TobogganTrajectory.Library
{
    public class TrajectoryCalculator
    {
        public int CountTrees(string[] rows, (int, int) offset)
        {
            int columnPosition = 0;
            int count = 0;

            var (right, down) = offset;
            
            for(int j = 0 ; j < rows.Length ; j+=down)
            {
                var treePositions = LineScanner.Scan(rows[j]);

                if (LineScanner.IsTree(treePositions, columnPosition, rows[j].Length))
                    count++;

                columnPosition+=right;
            }

            return count;
        }
    }
}
