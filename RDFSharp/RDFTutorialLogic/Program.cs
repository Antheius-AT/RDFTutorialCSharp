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
            //var data = reader.Read(@"F:\FH_Stuff\3_Semester\SemantischeTechnologien\Aufgabenstellung\RDFTutorialCSharp\TestCSVData\Test2.csv");
            //var tripleStore = new TripleStore(uriPrefix);
            var reasoner = new Reasoner();
            //reasoner.RegisterRule(new InverseDependencyRule("Ist beFReundet mit", uriPrefix));

            //var triples = tripleStore.RetrieveMatchingTriplesAsync(null, null, null);

            //foreach (var item in data)
            //{
            //    try
            //    {
            //        var triple = parser.Parse(item);
            //        tripleStore.TryAddTriple(triple);
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("Du bist ein Volltrottel.");
            //    }
            //}

            //foreach (var item in triples)
            //{
            //    Console.WriteLine(item.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            //}

            //Console.WriteLine("------------------------------------------------------------");
            //var reasoned = reasoner.InvokeRules(triples);

            //foreach (var item in reasoned)
            //{
            //    Console.WriteLine(item.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            //}
            //var predRule1 = new TransitiveDependencyRule(
            //    $"{uriPrefix.ToLower()}:ist zusammen mit", 
            //    $"{uriPrefix.ToLower()}:gehört",
            //    basePredicateIsRelatedToSubject: false,
            //    mappedPredicateIsRelatedToSubject: false,
            //    uriPrefix);

            //var predRule2 = new TransitiveDependencyRule(
            //    $"{uriPrefix.ToLower()}:hat Schulden bei",
            //    $"{uriPrefix.ToLower()}:gehört",
            //    basePredicateIsRelatedToSubject: true,
            //    mappedPredicateIsRelatedToSubject: false,
            //    uriPrefix);

            //var predRule3 = new TransitiveDependencyRule(
            //    $"{uriPrefix.ToLower()}:ist",
            //    $"{uriPrefix.ToLower()}:hat",
            //    basePredicateIsRelatedToSubject: false,
            //    mappedPredicateIsRelatedToSubject: true,
            //    uriPrefix);


            //reasoner.RegisterRule(predRule1);
            //reasoner.RegisterRule(predRule2);
            //reasoner.RegisterRule(predRule3);
            //var rawData = reader.ReadFiles(
            //    @"E:\VisualStudio\Visual C#\RDFTutorialCSharp\TestCSVData\Test2.csv");
            //var tripleData = new List<RDFTriple>();


            //Console.WriteLine("Starting data:");
            //foreach (var triple in tripleData)
            //{
            //    Console.WriteLine(triple.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            //}
            //Console.WriteLine("-----------------------");

            //Console.WriteLine("Rules:");

            //Console.WriteLine("Predicate rule 1: ist zusammen mit => gehört");
            //Console.WriteLine("Predicate rule 1: hat Schulden bei => gehört");

            //Console.WriteLine("-----------------------");
            //Console.WriteLine("Inferred data:");
            //tripleData = reasoner.InvokeRules(tripleData).ToList();
            //foreach (var triple in tripleData.Distinct())
            //{
            //    Console.WriteLine(triple.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            //}
            var path = @"E:\VisualStudio\Visual C#\RDFTutorialCSharp\TestCSVData\Test1.csv";
            var outputPath = @"E:\VisualStudio\Visual C#\RDFTutorialCSharp\TestCSVData\Test10.csv";
            //var path = @"E:\VisualStudio\Visual C#\RDFTutorialCSharp\TestCSVData\Test3.csv";
            var rawData = reader.Read(path);
            var tripleData = new List<RDFTriple>();

            foreach (var rawTripleData in rawData)
            {
                try
                {
                    tripleData.Add(parser.Parse(rawTripleData));
                }
                catch (Exception)
                {
                }

            }

            var ontology = new Ontology("Test", tripleData);
            var writer = new CSVDataWriter();

            writer.Write(ontology, outputPath);

            Console.ReadKey(true);
        }
    }
}

