using System;

namespace RDFTutorialLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using FileHelpers;
    using RDFSharp.Model;
    using RDFSharp.Store;
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
            //var data = new List<string>() { "Berg", "istHoch", "Martin" };
            //var tripleParser = new TripleParser();
            //var triple = tripleParser.Parse(new RawTripleData(data));

            //var dataReader = new CSVDataReader();
            //var data = dataReader.Read(@"E:\Test.csv");

            //foreach (var item in data)
            //    Console.WriteLine(item);

            var uri = new Uri("design.html", UriKind.RelativeOrAbsolute);

            var res = new RDFResource("RDFDemoLibrary:TestTest");
            var triple = new RDFTriple(res, res, res);

            var graph = new RDFGraph();
            graph.AddTriple(triple);

            Console.WriteLine($"Contains Triple: {graph.ContainsTriple(triple)}");

            var sameTriple = new RDFTriple(res, res, res);

            Console.WriteLine($"Contains same triple but other reference: {graph.ContainsTriple(sameTriple)}");

            graph.RemoveTriple(new RDFTriple(res, res, new RDFResource()));

            Console.ReadKey(true);
        }
    }
}

