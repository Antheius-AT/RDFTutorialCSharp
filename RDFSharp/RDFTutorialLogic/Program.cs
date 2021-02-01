//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RDFSharp.Model;
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
            var reasoner = new Reasoner();

            var predRule1 = new TransitiveDependencyRule(
                $"{uriPrefix.ToLower()}:ist zusammen mit", 
                $"{uriPrefix.ToLower()}:gehört",
                basePredicateIsRelatedToSubject: false,
                mappedPredicateIsRelatedToSubject: false,
                uriPrefix);

            var predRule2 = new TransitiveDependencyRule(
                $"{uriPrefix.ToLower()}:hat Schulden bei",
                $"{uriPrefix.ToLower()}:gehört",
                basePredicateIsRelatedToSubject: true,
                mappedPredicateIsRelatedToSubject: false,
                uriPrefix);

            var predRule3 = new TransitiveDependencyRule(
                $"{uriPrefix.ToLower()}:ist",
                $"{uriPrefix.ToLower()}:hat",
                basePredicateIsRelatedToSubject: false,
                mappedPredicateIsRelatedToSubject: true,
                uriPrefix);

            reasoner.RegisterRule(predRule1);
            reasoner.RegisterRule(predRule2);
            reasoner.RegisterRule(predRule3);
            var rawData = reader.ReadFiles(
                @"E:\VisualStudio\Visual C#\RDFTutorialCSharp\TestCSVData\Test2.csv");
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


            Console.WriteLine("Starting data:");
            foreach (var triple in tripleData)
            {
                Console.WriteLine(triple.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            }
            Console.WriteLine("-----------------------");

            Console.WriteLine("Rules:");

            Console.WriteLine("Predicate rule 1: ist zusammen mit => gehört");
            Console.WriteLine("Predicate rule 1: hat Schulden bei => gehört");

            Console.WriteLine("-----------------------");
            Console.WriteLine("Inferred data:");
            tripleData = reasoner.InvokeRules(tripleData).ToList();
            foreach (var triple in tripleData.Distinct())
            {
                Console.WriteLine(triple.ToString().Replace($"{uriPrefix.ToLower()}:", string.Empty));
            }

            Console.ReadKey(true);
        }
    }
}

