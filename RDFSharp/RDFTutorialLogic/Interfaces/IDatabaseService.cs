//-----------------------------------------------------------------------
// <copyright file="IDatabaseService.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represent an object capable of handling database transactions.
    /// </summary>
    public interface IDatabaseService
    {
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
        Task<bool> TryStoreInDatabaseAsync(Triple triple);

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
        Task<bool> TryRetrieveFromDatabaseAsync(string subject, string predicate, string @object, out IEnumerable<Triple> result);

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
        Task<bool> TryDeleteFromDatabaseAsync(Triple triple);
    }
}
