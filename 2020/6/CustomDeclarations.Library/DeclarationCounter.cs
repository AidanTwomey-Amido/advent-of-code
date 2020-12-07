using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDeclarations.Library
{
    public class DeclarationCounter
    {
        public static int CountUnion(IEnumerable<string> declarations)
        {
            return declarations
                .SelectMany(d => d.ToCharArray())
                .Distinct()
                .Count();
        }

        public static int CountIntersection(IEnumerable<string> declarations)
        {
            return Intersections(declarations.Select(d => d.ToCharArray())).Count();
        }

        private static IEnumerable<char> Intersections(IEnumerable<IEnumerable<char>> declarations)
        {
            var head = declarations.Take(1).Single();
            var tail = declarations.Skip(1);

            foreach (var c in head)
            {
                if (tail.All(t => t.Contains(c)))
                    yield return c;
            }
        }
    }
}
