using Xunit;
using TobogganTrajectory.Library;
using FluentAssertions;

namespace TobogganTrajectory.UnitTests
{
    // public class GivenAGrid
    // {
    //     public void
    // }
    public class GivenARow
    {
        [Theory]
        [InlineData("..##.......", 2, 3)]
        [InlineData("#...#...#..", 0, 4, 8)]
        [InlineData("...........")]
        [InlineData("#####", 0, 1, 2, 3, 4)]
        [InlineData(".#...##..#.", 1, 5, 6, 9)]
        [InlineData("...........#", 11)]
        [InlineData("#...........", 0)]
        public void WhenScanThenTreesAreReturned(string row, params int[] expectedPositions)
        {
            LineScanner.Scan(row).Should()
                .HaveCount(expectedPositions.Length)
                .And.ContainInOrder(expectedPositions);
        }

        [Theory]
        [InlineData(11, 2)]
        [InlineData(11, 2, 3, 14)]
        public void AndATreeExistsAtAGivenIndexWhenIsTreeIsCalledThenTrue(int length, params int[] positions)
        {
            var treePositions = new[] { 2, 3 };

            foreach (var position in positions)
                LineScanner.IsTree(treePositions, position, length).Should().BeTrue();
        }

        [Theory]
        [InlineData(11, 0)]
        [InlineData(11, 11, 12, 15)]
        public void AndATreeExistsAtAGivenIndexWhenIsTreeIsCalledThenFalse(int length, params int[] positions)
        {
            var treePositions = new[] { 2, 3 };

            foreach (var position in positions)
                LineScanner.IsTree(treePositions, position, length).Should().BeFalse();
        }
    }
}
