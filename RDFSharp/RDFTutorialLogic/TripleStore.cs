//-----------------------------------------------------------------------
// <copyright file="TripleStore.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Interfaces;

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
        public async Task<bool> TryDeleteTripleAsync(Triple triple)
        {
            var result = await this.databaseService.TryDeleteFromDatabaseAsync(triple);

            return result.Success;
        }

        /// <summary>
        /// Asynchronously tries to retrieve any triples matching the specified subject, predicate, or object.
        /// </summary>
        /// <param name="subject">The specified subject.</param>
        /// <param name="predicate">The specified predicate.</param>
        /// <param name="object">The specified object.</param>
        /// <returns></returns>
        public Task<bool> TryRetrieveTriplesAsync(string subject, string predicate, string @object)
        {
            throw new NotImplementedException();
        }
    }
}
