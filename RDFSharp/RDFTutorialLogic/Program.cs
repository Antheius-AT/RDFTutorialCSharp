using System;

namespace RDFTutorialLogic
{
    using System.Collections.Generic;
    using FileHelpers;
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

            var dataReader = new CSVDataReader();
            var data = dataReader.Read(@"E:\VisualStudio\Visual C#\RDFTutorialCSharp\TestCSVData\Test.csv");

            foreach (var item in data)
                Console.WriteLine(item);
            
            Console.ReadKey(true);
        }
    }
}

