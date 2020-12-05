using System;
using System.Collections.Generic;
using System.Linq;

namespace TobogganTrajectory.Library
{
    public class LineScanner
    {
        public static int[] Scan(string row)
        {
            return Iterate(row).ToArray();
        }

        private static IEnumerable<int> Iterate(string row)
        {
            for (int i = 0; i < row.Length; ++i)
                if (row[i] == '#')
                    yield return i;
        }

        public static bool IsTree(int[] positions, int position, int gridWidth)
        {
            return positions.Contains(position % gridWidth);
        }
    }
}
