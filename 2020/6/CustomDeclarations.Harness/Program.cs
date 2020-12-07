using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomDeclarations.Library;

namespace CustomDeclarations.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the count");

            foreach (var file in new DirectoryInfo("CustomDeclarations.Harness/bin/Debug/net5.0/Declarations").GetFiles())
            {
                var declarations = Batch(File.ReadAllLines(Path.Combine(file.DirectoryName, file.FullName)));

                var count = declarations
                            .Select(DeclarationCounter.CountIntersection)
                            .Sum();

                Console.WriteLine($"{file.Name}: {count}");
            }
        }

        static IEnumerable<IEnumerable<string>> Batch(IEnumerable<string> forms)
        {
            var declaration = new List<string>();

            foreach ( var form in forms)
            {
                if (string.IsNullOrEmpty(form))
                {
                    yield return declaration;
                    declaration = new List<string>();
                }
                else
                {
                    declaration.Add(form);
                }
            }

            yield return declaration;
        }
    }
}
