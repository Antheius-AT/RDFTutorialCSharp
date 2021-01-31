using System.Linq;
//-----------------------------------------------------------------------
// <copyright file="CSVDataReader.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System.IO;
    using Interfaces;
    using FileHelpers;
    using System.Collections.Generic;
    using RDFTutorialLogic.Data;
    using System.Text;
    using System;

    /// <summary>
    /// Represents an implementation of an <see cref="IDataReader"/> which is responsible for reading in data from a csv files.
    /// </summary>
    public class CSVDataReader : IDataReader
    {
        /// <summary>
        /// This component helps us reading data from csv files.
        /// </summary>
        private readonly FileHelperEngine<RawTripleData> fileReaderEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVDataReader"/> class.
        /// </summary>
        public CSVDataReader()
        {
            this.fileReaderEngine = new FileHelperEngine<RawTripleData>(encoding: Encoding.UTF8);
        }

        /// <summary>
        /// Reads data from a .csv file with the <see cref="FileHelperEngine"/> component.
        /// </summary>
        /// <param name="path">The path to the .csv file.</param>
        /// <returns>Returns a collection of raw triples.</returns>
        /// <exception cref="IOException">
        /// ... is thrown when the file does not exist.
        /// ... is thrown when the file extension is invalid. => Expected is a .csv file.
        /// </exception>
        public IEnumerable<RawTripleData> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new IOException("The file does not exist.");
            }

            var extension = Path.GetExtension(path);
            if (extension != ".csv")
            {
                throw new IOException("The reader only handles .csv files.");
            }

            this.fileReaderEngine.HeaderText = this.fileReaderEngine.GetFileHeader();
            return this.fileReaderEngine.ReadFile(path);
        }

        /// <summary>
        /// Reads in data from multiple csv files.
        /// </summary>
        /// <param name="paths">The paths to the files.</param>
        /// <returns>An enumerable of raw triples.</returns>
        public IEnumerable<RawTripleData> ReadFiles(params string[] paths)
        {
            if(paths == null)
            {
                throw new ArgumentNullException(nameof(paths));
            }

            var triples = new List<RawTripleData>();

            foreach (var path in paths)
            {
                var currData = this.Read(path);
                currData.ToList().ForEach(triple =>
                {
                    if (!triples.Contains(triple))
                        triples.Add(triple);
                });
            } 

            return triples;
        }
    }
}