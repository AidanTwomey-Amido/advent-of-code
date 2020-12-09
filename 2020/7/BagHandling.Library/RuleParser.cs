using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BagHandling.Library
{
    public class RuleParser
    {
        private readonly Regex rx = new Regex(@"\w+",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly HashSet<Bag> allBags = new HashSet<Bag>(new BagComparer());


        private Bag Mementoise(Bag bag)
        {
            var alreadyCreated = allBags.TryGetValue(bag, out var setBag);

            if ( alreadyCreated )
            {
                return setBag;
            }
            else
            {
                allBags.Add(bag);
                return bag;
            }
        }

        public IEnumerable<Bag> GetParents(Bag root)
        {
            return GetAllParents(Mementoise(root));
        }

        private IEnumerable<Bag> GetAllParents(Bag root)
        {
            if (root.Parents.Any())
            {
                return root.Parents.Union(root.Parents.SelectMany(p => GetAllParents(p)));
            }

            return Array.Empty<Bag>();
        }

        public Bag AddBagToSet(string rule)
        {
            MatchCollection matches = rx.Matches(rule);

            var parent = new Bag(matches[0].Value, matches[1].Value);

            parent = Mementoise(parent);

            var bags = matches[4].Value == "no"
                ? Array.Empty<Bag>()
                : MatchBags(matches).Select(Mementoise);

            foreach (var bag in bags)
            {
                parent.Children.Add(bag);
                bag.Parents.Add(parent);
            }

            return parent;
        }

        private IEnumerable<Bag> MatchBags(MatchCollection matches)
        {
            //light red bags contain 1 bright white bag, 2 muted yellow bags.

            int i = 4;

            do{
                yield return new Bag(matches[i+1].Value,matches[i+2].Value);
                i+=4;
            } while (i < matches.Count);
        }
    }
}
