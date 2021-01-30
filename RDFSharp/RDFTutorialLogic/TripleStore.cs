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
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Interfaces;
    using RDFSharp.Model;

    /// <summary>
    /// Represents a triple store, supporting the management of triples.
    /// </summary>
    public class TripleStore
    {
        /// <summary>
        /// An object containing the collection of triples, allowing for modification.
        /// </summary>
        private RDFGraph tripleGraph;

        /// <summary>
        /// A string representing the uri prefix of resources.
        /// </summary>
        private string uriPrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleStore"/> class.
        /// </summary>
        /// <param name="databaseService">The service used for accessing the triple database.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if database service is null.
        /// </exception>
        public TripleStore(string uriPrefix)
        {
            this.tripleGraph = new RDFGraph();
            this.uriPrefix = uriPrefix ?? throw new ArgumentNullException(nameof(uriPrefix), "URI prefix must not be null.");
        }

        /// <summary>
        /// Asynchronously tries to add a triple to the store.
        /// </summary>
        /// <param name="triple">The triple to add.</param>
        /// <returns>A task handling the logic and containing a value indicating
        /// whether the triple was successfully added in its result on termination.
        /// </returns>
        public bool TryAddTriple(RDFTriple triple)
        {
            if (triple == null)
                throw new ArgumentNullException(nameof(triple), "Triple to add must not be null.");

            var exists = tripleGraph.ContainsTriple(triple);

            if (!exists)
                this.tripleGraph.AddTriple(triple);

            return !exists;
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
        public bool TryDeleteTripleAsync(RDFTriple triple)
        {
            if (triple == null)
                throw new ArgumentNullException(nameof(triple), "Triple to delete must not be null.");

            var contains = this.tripleGraph.ContainsTriple(triple);

            if (contains)
                this.tripleGraph.RemoveTriple(triple);

            return contains;
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
        public IEnumerable<RDFTriple> RetrieveMatchingTriplesAsync(string subject, string predicate, string @object)
        {
            if (subject == string.Empty)
                throw new ArgumentException(nameof(subject), "Subject to look for must not be empty. Use null to omit a restriction for a specified parameter.");
           
            if (predicate == string.Empty)
                throw new ArgumentException(nameof(subject), "Predicate to look for must not be empty. Use either null for an undefined value, or * to match all possible values");

            if (@object == string.Empty)
                throw new ArgumentException(nameof(subject), "Object to look for must not be empty. Use either null for an undefined value, or * to match all possible values");

            if (subject != null && predicate != null && @object != null)
                return this.tripleGraph.SelectTriplesBySubject(new RDFResource($"{this.uriPrefix}:{subject}"))
                    .SelectTriplesByPredicate(new RDFResource($"{this.uriPrefix}:{predicate}"))
                    .SelectTriplesByObject(new RDFResource($"{this.uriPrefix}:{predicate}"));
            if (subject != null)
            {
                // Wert unbekannt unbekannt
                // Wir wissen Subjekt ist Ungleich null, hat also einen Filter.
                // Wir wissen außerdem dass mindestens eines von beiden null sein müssen.
                if (predicate == null && @object == null)
                    // Wissen dass Objekt und Prädikat null sind, also müssen wir nur nach Subjekten Filtern.
                    return this.tripleGraph.SelectTriplesBySubject(new RDFResource($"{this.uriPrefix}:{subject}"));

                // Wenn wir zu dieser rein kommen wissen wir, dass MINDESTENS eines nicht null ist, entweder Prädikat
                // oder Objekt. 
                else if (predicate != null && @object == null)
                    return this.tripleGraph.SelectTriplesBySubject(new RDFResource($"{this.uriPrefix}:{subject}"))
                        .SelectTriplesByPredicate(new RDFResource($"{this.uriPrefix}:{predicate}"));
                else
                    return this.tripleGraph.SelectTriplesBySubject(new RDFResource($"{this.uriPrefix}:{subject}"))
                        .SelectTriplesByPredicate(new RDFResource($"{this.uriPrefix}:{@object}"));
            }
            if (predicate != null)
            {
                // Wir wissen dass Subjekt sicher null ist.
                // Wir wissen dass predicate NICHT null ist, gilt nurnoch herauszufinden
                // ob object einen Filter hat oder nicht.
                var result = @object == null
                    ?
                    this.tripleGraph.SelectTriplesByPredicate(new RDFResource($"{this.uriPrefix}:{predicate}")) 
                    :
                    this.tripleGraph.SelectTriplesByPredicate(new RDFResource($"{this.uriPrefix}:{predicate}"))
                    .SelectTriplesByObject(new RDFResource($"{this.uriPrefix}:{@object}"));

                return result;
            }
            if (@object != null)
            {
                // Wir wissen dass Sowohl Subjekt als auch Prädikat sicher Null sind.
                return this.tripleGraph.SelectTriplesByObject(new RDFResource($"{this.uriPrefix}:{@object}"));
            }
            else
                // Hier wissen wir dass alle drei Bedingungen NULL sind.
                return this.tripleGraph;
        }
    }
}
