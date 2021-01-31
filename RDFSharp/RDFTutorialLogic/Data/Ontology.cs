//-----------------------------------------------------------------------
// <copyright file="Ontology.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Data
{
    using System;
    using System.Collections.Generic;
    using RDFSharp.Model;

    /// <summary>
    /// Represents the component which stores and manage data of triples.
    /// </summary>
    public class Ontology
    {
        /// <summary>
        /// All the triples currently stored in the ontology.
        /// </summary>
        private readonly IEnumerable<RDFTriple> tripleData;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ontology"/> class.
        /// </summary>
        /// <param name="name">The name of the ontology.</param>
        /// <exception cref="ArgumentNullException">
        /// ... is thrown when the name is null.
        /// </exception>
        public Ontology(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.tripleData = new List<RDFTriple>();
        }

        /// <summary>
        /// Gets the name of the <see cref="Ontology"/>.
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// Retrieve all triples from the ontology.
        /// </summary>
        /// <returns>A enumerable of the triples.</returns>
        public IEnumerable<RDFTriple> RetrieveAll()
        {
            foreach (var triple in this.tripleData)
            {
                yield return triple;
            }
        }
    }
}
