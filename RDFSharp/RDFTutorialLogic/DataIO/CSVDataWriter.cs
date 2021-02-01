//-----------------------------------------------------------------------
// <copyright file="IDataReader.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System.IO;
    using System.Linq;
    using FileHelpers;
    using Interfaces;
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represents a csv writer.
    /// </summary>
    public class CSVDataWriter : IDataWriter
    {
        /// <summary>
        /// Represents a helper engine for writing data to a csv file.
        /// </summary>
        private readonly FileHelperEngine<RawTripleData> writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVDataWriter"/> class.
        /// </summary>
        public CSVDataWriter()
        {
            this.writer = new FileHelperEngine<RawTripleData>();
            this.writer.HeaderText = this.writer.GetFileHeader();
        }

        /// <summary>
        /// Writes data from a ontology to a given csv file.
        /// </summary>
        /// <param name="ontolgy">The ontology whichs data is written to a file.</param>
        /// <param name="path">The path to the file.</param>
        public void Write(Ontology ontolgy, string path)
        {
            var extension = Path.GetExtension(path);

            if (extension != ".csv")
            {
                throw new IOException("The reader only handles .csv files.");
            }

            var rawData = ontolgy.RetrieveAll().Select(rdfTriple => new RawTripleData
            {
                Subject = rdfTriple.Subject.ToString(),
                Predicate = rdfTriple.Predicate.ToString(),
                Object = rdfTriple.Object.ToString()
            });

            this.writer.WriteFile(path, rawData);
        }
    }
}
