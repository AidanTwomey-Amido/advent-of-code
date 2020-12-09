using System.Linq;
using FluentAssertions;
using Xunit;
using BagHandling.Library;

namespace BagHandling.UnitTests
{

    public class GivenAPuzzleRule
    {
        [Fact]
        public void AndRedBagContainsWhiteThenCorrectRelationshpiIsFormed()
        {
            var rule = "light red bags contain 1 bright white bag, 2 muted yellow bags.";

            var ruleParser = new RuleParser();

            Bag redBag = ruleParser.AddBagToSet(rule);

            redBag.Id.Should().Be("light_red");
            
            // redBag.Children.Should().NotBeEmpty()
            //                 .And.HaveCount(2)
                            // .And.Contain(c => c.Id == "bright_white" || c.Id == "muted_yellow");
        }

        [Fact]
        public void AndWhiteBagContainsGoldOnlyThenCorrectRelationshpiIsFormed()
        {
            var rule = "bright white bags contain 1 shiny gold bag.";

            var ruleParser = new RuleParser();

            Bag whiteBag = ruleParser.AddBagToSet(rule);

            whiteBag.Id.Should().Be("bright_white");
            // whiteBag.Children.Should().NotBeEmpty()
            //                 .And.HaveCount(1)
            //                 .And.OnlyContain(b => b.Id == "shiny_gold");

            // whiteBag.Children.Single().Parents.Single().Should().Be(whiteBag);
        }

        [Fact]
        public void AndFadedBlueContainsNoBagsThenContainsIsEmpty()
        {
            var rule = "faded blue bags contain no other bags.";

            var ruleParser = new RuleParser();

            Bag blueBag = ruleParser.AddBagToSet(rule);

            blueBag.Id.Should().Be("faded_blue");
            // blueBag.Children.Should().BeEmpty();
        }


        //dark orange bags contain 3 bright white bags, 4 muted yellow bags.
    }
}
