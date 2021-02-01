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
    using System.Runtime.CompilerServices;
    using RDFSharp.Model;
    using RDFTutorialLogic.BusinessLogic;
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Exceptions;

    /// <summary>
    /// Represents the program class with entry point of the application.
    /// </summary>
    public static class Program
    {
        private const string uriPrefix = "rdflibrary";
        private static readonly CSVDataReader reader = new CSVDataReader();
        private static readonly TripleParser parser = new TripleParser(uriPrefix);
        private static readonly Reasoner reasoner = new Reasoner();
        private static readonly TripleStore store = new TripleStore(uriPrefix, reasoner);

        /// <summary>
        /// Represents the entry point of the application.
        /// </summary>
        public static void Main()
        {
            var firstFilePath = @"F:\FH_Stuff\3_Semester\SemantischeTechnologien\Aufgabenstellung\RDFTutorialCSharp\TestCSVData\Test1.csv";
            var secondFilePath = @"F:\FH_Stuff\3_Semester\SemantischeTechnologien\Aufgabenstellung\RDFTutorialCSharp\TestCSVData\Test2.csv";

            // Einlesen aus CSV Files Erklärung.
            // Struktur von CSV File: Header hat Format: Subject,Predicate,Object. Danach folgen Daten.
            // reader hat 2 Methoden. Read und ReadFiles.
            // Read: Einen Pfad zum CSV File angeben. Return type ist ein IEnumerable<RawTripleData> die noch geparsed werden müssen
            // ReadFiles: Mehrere Pfade zu CSV Files angeben. Return type analog zu Read.
            var singleFileData = reader.Read(firstFilePath);
            var multiFileData = reader.ReadFiles(firstFilePath, secondFilePath);

            // Eingelesene Daten parsen
            var parsedTriples = Parse(singleFileData);

            // Daten zum Store hinzufügen
            AddTriplesToStore(parsedTriples);
            PrintAll(store.RetrieveMatchingTriples(null, null, null), "Alle hinzugefügten Triples im store:");

            // Daten vom Store löschen
            // store.TryDeleteTriple(parsedTriples.First());
            // store.TryDeleteTriple(parsedTriples.Last());

            // Daten aus Store abrufen mit store.RetrieveMatchingTriples und anschließend ausgeben.
            PrintAll(store.RetrieveMatchingTriples(null, null, null), "Erster und letzter Triple gelöscht:");
            PrintAll(store.RetrieveMatchingTriples("Gregor", null, null), "Gefiltert nach Subjekt: Gregor");
            PrintAll(store.RetrieveMatchingTriples("Tom", "ist", null), "Gefiltert nach Subjekt: Tom; Prädikat: ist");
            PrintAll(store.RetrieveMatchingTriples(null, "hat", null), "Gefiltert nach Prädikat: hat");
            PrintAll(store.RetrieveMatchingTriples(null, null, "Durst"), "Gefiltert nach Objekt: Durst");

            // Regeln definieren.
            // DAfür neuen triple store anlegen zwecks übersicht
            var newStore = new TripleStore(uriPrefix, reasoner);

            var parsedTestData = Parse(singleFileData);

            foreach (var item in parsedTestData)
            {
                newStore.TryAddTriple(item);
            }

            // x ist partner von y. ==> y ist partner von x.
            reasoner.RegisterRule(new InverseDependencyRule("ist partner von", uriPrefix));
            reasoner.RegisterRule(new InverseDependencyRule("ist zusammen mit", uriPrefix));
            reasoner.RegisterRule(new TransitiveDependencyRule($"{uriPrefix}:hat schulden bei", $"{uriPrefix}:gehört", true, false, uriPrefix));
            reasoner.RegisterRule(new TransitiveDependencyRule($"{uriPrefix}:ist zusammen mit", $"{uriPrefix}:gehört", false, false, uriPrefix));

            // Regeln ausführen.
            var inferredTriples = reasoner.InvokeRules(store.RetrieveMatchingTriples(null, null, null));

            PrintAll(store.RetrieveMatchingTriples(null, null, null), "Ausgabe von ursprünglichen Triples:");
            PrintAll(inferredTriples.Except(store.RetrieveMatchingTriples(null, null, null)), "Ausgabe von inferenzierten Triples:");

            Console.ReadKey(true);
        }

        /// <summary>
        /// Adds triples to store.
        /// </summary>
        /// <param name="triples"></param>
        private static void AddTriplesToStore(IEnumerable<RDFTriple> triples)
        {
            foreach (var item in triples)
            {
                store.TryAddTriple(item);
            }
        }

        /// <summary>
        /// Parses the raw data into triple objects.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static IEnumerable<RDFTriple> Parse(IEnumerable<RawTripleData> data)
        {
            var parsedTriples = new List<RDFTriple>();

            foreach (var item in data)
            {
                try
                {
                    // Daten parsen und anschließend dem Store hinzufügen.
                    // Im Try catch, um ungültige Zeilen eines eingelesenen Files zu ignorieren.
                    var rdfTriple = parser.Parse(item);
                    parsedTriples.Add(rdfTriple);
                }
                catch (TripleParsingFailedException)
                {
                    Console.WriteLine("Ein Triple konnte nicht geparsed werden.");
                }
            }

            return parsedTriples;
        }

        /// <summary>
        /// Prints all specified triples.
        /// </summary>
        /// <param name="triples"></param>
        /// <param name="sectionHeader"></param>
        private static void PrintAll(IEnumerable<RDFTriple> triples, string sectionHeader)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sectionHeader);
            Console.ResetColor();
            Console.WriteLine("------------------------------");

            foreach (var item in triples)
            {
                Console.WriteLine($"{item.Subject}; {item.Predicate}; {item.Object}");
            }
        }
    }
}

