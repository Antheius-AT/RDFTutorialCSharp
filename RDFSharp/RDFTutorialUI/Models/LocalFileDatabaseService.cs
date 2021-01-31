//-----------------------------------------------------------------------
// <copyright file="LocalFileDatabaseService.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using FileHelpers;
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Interfaces;

    /// <summary>
    /// Represents a database service capable of interacting with a database
    /// being stored locally on the PC's drive.
    /// </summary>
    public class LocalFileDatabaseService : IDatabaseService
    {
        /// <summary>
        /// Backing field of the <see cref="FilePath"/> property.
        /// </summary>
        private string filePath;

        /// <summary>
        /// Represents an object capable of writing and reading CSV files.
        /// </summary>
        private FileHelperEngine<EnhancedRDFTriple> fileHelper;

        /// <summary>
        /// Object capable of reading and writing to files on disk.
        /// </summary>
        private IDataReader dataReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalFileDatabaseService"/> class.
        /// </summary>
        /// <param name="filePath">The path to the database file.</param>
        /// <exception cref="ArgumentException">
        /// Is thrown if the specified path does not lead to a CSV file.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Is thrown the data reader is null.
        /// </exception>
        public LocalFileDatabaseService(string filePath, IDataReader dataReader)
        {
            this.fileHelper = new FileHelperEngine<EnhancedRDFTriple>();
            this.FilePath = filePath;
            this.dataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader), "Data Reader must not be null.");
        }

        /// <summary>
        /// Gets or sets the path to the database file.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Is thrown if the specified path does not lead to a CSV file.
        /// </exception>
        public string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                var isFileValid = value != null && File.Exists(value) && Path.GetExtension(value) == ".csv";

                if (!isFileValid)
                    throw new ArgumentException(nameof(value), "File path must be a valid path specifying a CSV file.");

                this.filePath = value;
            }
        }

        /// <summary>
        /// Asynchronously tries to delete the specified triple.
        /// </summary>
        /// <param name="triple">The triple to delete.</param>
        /// <returns>A task object handling the logic of deleting the triple
        /// and containing a value indicating whether the deletion was successful
        /// in its result on termination.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if triple is null.
        /// </exception>
        public async Task<DatabaseQuerySuccessResult> TryDeleteFromDatabaseAsync(EnhancedRDFTriple triple)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously retrieves all triples from the database matching 
        /// either the specified subject, predicate, or object.
        /// Use the * wildcard, to match all entries for the specified category.
        /// </summary>
        /// <param name="subject">The subject to look for.</param>
        /// <param name="predicate">The predicate to look for.</param>
        /// <param name="object">The object to look for.</param>
        /// <param name="result">The resulting collection. Null if retrieval was not successful.</param>
        /// <returns>A task object handling the logic and containing the resulting
        /// collection in its result on termination.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Is thrown if either of the parameters are an empty string.
        /// </exception>
        public async Task<DatabaseQueryDataResult<IEnumerable<EnhancedRDFTriple>>> RetrieveMatchingTriplesAsync(string subject, string predicate, string @object)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously tries to store a triple in the database.
        /// </summary>
        /// <param name="triple">The triple to be stored.</param>
        /// <returns>A task handling the logic and containing a value indicating whether
        /// the triple was successfully stored in its result on termination.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if triple is null.
        /// </exception>
        public async Task<DatabaseQuerySuccessResult> TryStoreInDatabaseAsync(EnhancedRDFTriple triple)
        {
            throw new NotImplementedException();
        }
    }
}
