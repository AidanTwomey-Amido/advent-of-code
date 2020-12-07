
using System;
using CustomDeclarations.Library;
using FluentAssertions;
using Xunit;

namespace CustomDeclarations.UnitTests
{
    public class GivenAGroupOfCustomDeclarations
    {
        [Theory]
        [InlineData(3, "abc")]
        [InlineData(3, "a", "b", "c")]
        [InlineData(3, "ab", "ac")]
        [InlineData(1, "a", "a", "a", "a")]
        [InlineData(1, "b")]
        public void ThenCorrectUnionCount(int expectedCount, params string[] declarations)
        {
            DeclarationCounter.CountUnion(declarations).Should().Be(expectedCount);
        }

        [Theory]
        [InlineData(3, "abc")]
        [InlineData(0, "a", "b", "c")]
        [InlineData(1, "ab", "ac")]
        [InlineData(1, "a", "a", "a", "a")]
        [InlineData(1, "b")]
        [InlineData(15, "krlugwajesizdptcvqh", "vwuzeicrdhpastknmo", "zchstrwvaxkipeoud", "hvwzoetbdisrakxcpu")]
        public void ThenCorrectIntersectionCount(int expectedCount, params string[] declarations)
        {
            DeclarationCounter.CountIntersection(declarations).Should().Be(expectedCount);
        }
    }
}
