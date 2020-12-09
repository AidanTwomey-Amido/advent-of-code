using System;
using System.IO;
using System.Linq;
using BagHandling.Library;

namespace BagHandling.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the count");

            foreach (var file in new DirectoryInfo("BagHandling.Harness/bin/Debug/net5.0/Rules").GetFiles())
            {
                var rules = File.ReadAllLines(Path.Combine(file.DirectoryName, file.FullName));

                var ruleSet = new RuleParser();

                foreach (var rule in rules)
                {
                    ruleSet.AddBagToSet(rule);
                }

                var outermostBags = ruleSet.GetParents(new Bag("shiny", "gold")).ToList();

                Console.WriteLine($"{file.Name}: {outermostBags.Count}");
            }
        }

        // static IEnumerable<IEnumerable<string>> Batch(IEnumerable<string> forms)
        // {
        //     var declaration = new List<string>();

        //     foreach ( var form in forms)
        //     {
        //         if (string.IsNullOrEmpty(form))
        //         {
        //             yield return declaration;
        //             declaration = new List<string>();
        //         }
        //         else
        //         {
        //             declaration.Add(form);
        //         }
        //     }

        //     yield return declaration;
        // }
    }
}
