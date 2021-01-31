using System;

namespace RDFTutorialLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using FileHelpers;
    using RDFSharp.Model;
    using RDFSharp.Store;
    using RDFTutorialLogic.BusinessLogic;
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represents the program class with entry point of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Represents the entry point of the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main()
        {
            var uriPrefix = "RDFDemoLibrary";
            var reader = new CSVDataReader();
            var parser = new TripleParser(uriPrefix);
            var data = reader.Read(@"F:\FH_Stuff\3_Semester\SemantischeTechnologien\Aufgabenstellung\RDFTutorialCSharp\TestCSVData\Test2.csv");
            var tripleStore = new TripleStore(uriPrefix);
            var reasoner = new Reasoner();
            reasoner.RegisterRule(new InverseDependencyRule("Ist beFReundet mit", uriPrefix));

            var triples = tripleStore.RetrieveMatchingTriplesAsync(null, null, null);

            foreach (var item in data)
            {
                try
                {
                    var triple = parser.Parse(item);
                    tripleStore.TryAddTriple(triple);
                }
                catch (Exception)
                {
                    Console.WriteLine("Du bist ein Volltrottel.");
                }
            }

            foreach (var item in triples)
            {
                Console.WriteLine(item.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            }

            Console.WriteLine("------------------------------------------------------------");
            var reasoned = reasoner.InvokeRules(triples);

            foreach (var item in reasoned)
            {
                Console.WriteLine(item.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            }

            Console.ReadKey(true);
        }
    }
}

