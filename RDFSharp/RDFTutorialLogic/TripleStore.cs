//-----------------------------------------------------------------------
// <copyright file="TripleStore.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Interfaces;
    using RDFSharp.Store;

    /// <summary>
    /// Represents a triple store, supporting the management of triples.
    /// </summary>
    public class TripleStore
    {
        /// <summary>
        /// Service used for accessing the triple database.
        /// </summary>
        private IDatabaseService databaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleStore"/> class.
        /// </summary>
        /// <param name="databaseService">The service used for accessing the triple database.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if database service is null.
        /// </exception>
        public TripleStore(IDatabaseService databaseService)
        {
            this.databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService), "Database service must not be null.");
        }

        /// <summary>
        /// Asynchronously tries to add a triple to the store.
        /// </summary>
        /// <param name="triple">The triple to add.</param>
        /// <returns>A task handling the logic and containing a value indicating
        /// whether the triple was successfully added in its result on termination.
        /// </returns>
        public async Task<bool> TryAddTripleAsync(Triple triple)
        {
            if (triple == null)
                throw new ArgumentNullException(nameof(triple), "Triple to add must not be null.");

            var result = await this.databaseService.TryStoreInDatabaseAsync(triple);

            return result.Success;
        }

        /// <summary>
        /// Asynchronously tries to remove a triple from the store.
        /// </summary>
        /// <param name="triple">The triple to remove.</param>
        /// <returns>A task handling the logic and containing a value indicating
        /// whether the triple was successfully deleted in its result on termination.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if triple is null.
        /// </exception>
        public async Task<bool> TryDeleteTripleAsync(Triple triple)
        {
            if (triple == null)
                throw new ArgumentNullException(nameof(triple), "Triple to delete must not be null.");

            var result = await this.databaseService.TryDeleteFromDatabaseAsync(triple);

            return result.Success;
        }

        /// <summary>
        /// Asynchronously tries to retrieve any triples matching the specified subject, predicate, or object.
        /// </summary>
        /// <param name="subject">The specified subject.</param>
        /// <param name="predicate">The specified predicate.</param>
        /// <param name="object">The specified object.</param>
        /// <returns>The triples returned from the database which match the specified pattern.</returns>
        /// <exception cref="ArgumentException">
        /// Is thrown if either of the parameters is an empty string.
        /// </exception>
        public async Task<IEnumerable<Triple>> RetrieveMatchingTriplesAsync(string subject, string predicate, string @object)
        {
            if (subject == string.Empty)
                throw new ArgumentException(nameof(subject), "Subject to look for must not be empty. Use either null for an undefined value, or * to match all possible values");
           
            if (predicate == string.Empty)
                throw new ArgumentException(nameof(subject), "Predicate to look for must not be empty. Use either null for an undefined value, or * to match all possible values");

            if (@object == string.Empty)
                throw new ArgumentException(nameof(subject), "Object to look for must not be empty. Use either null for an undefined value, or * to match all possible values");

            var result = await this.databaseService.RetrieveMatchingTriplesAsync(subject, predicate, @object);

            if (!result.Success)
                return Array.Empty<Triple>();

            return result.Data;
        }
    }
}
