using Xunit;
using TobogganTrajectory.Library;
using FluentAssertions;

namespace TobogganTrajectory.UnitTests
{
    public class GivenAGrid
    {
        private string[] testGrid = new string[]{
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        };

        [Theory]
        [InlineData(1,1, 2)]
        [InlineData(3,1, 7)]
        [InlineData(1,2, 2)]
        public void WhenCalculateTrajectory_TreeCount(int accross, int down, int expected)
        {
            var calculator = new TrajectoryCalculator();
            calculator.CountTrees(testGrid, (accross, down)).Should().Be(expected);
        }

        [Fact]
        public void WhenCombineTrajectories_TreeCountIsCorrect()
        {
            var calculator = new TrajectoryCalculator();
            var combiner = new TrajectoryCombiner(calculator);

            combiner
                .CombineTrajectories(testGrid, (1, 1), (3, 1), (5, 1), (7, 1), (1, 2))
                .Should()
                .Be(336);
        }
    }
}
