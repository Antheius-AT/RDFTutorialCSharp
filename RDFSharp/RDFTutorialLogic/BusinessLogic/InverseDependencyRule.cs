//-----------------------------------------------------------------------
// <copyright file="ReflexiveDependencyRule.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RDFSharp.Model;
    using RDFTutorialLogic.Interfaces;

    /// <summary>
    /// This class represents a reflexive dependency rule.
    /// </summary>
    public class InverseDependencyRule : IInferencingRule
    {
        /// <summary>
        /// The predicate which is marked as inverse.
        /// </summary>
        private string inversePredicate;

        /// <summary>
        /// Uri prefix of the application.
        /// </summary>
        private string uriPrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="InverseDependencyRule"/> class.
        /// </summary>
        /// <param name="inversePredicate">The predicate to mark as inverse.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if inverse predicate is null.
        /// </exception>
        public InverseDependencyRule(string inversePredicate, string uriPrefix)
        {
            this.inversePredicate = inversePredicate;
            this.uriPrefix = uriPrefix;
        }

        /// <summary>
        /// Invokes the rule.
        /// </summary>
        /// <param name="triples">The collection of triples.</param>
        /// <returns>The modified collection of triples.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if triples is null.
        /// </exception>
        public IEnumerable<RDFTriple> Invoke(IEnumerable<RDFTriple> triples)
        {
            var resultingTriples = triples.ToList();
            var inferredTriples = new List<RDFTriple>();

            for (int i = 0; i < triples.Count(); i++)
            {
                var currentTriple = triples.ElementAt(i);
                var predicateWithoutPrefix = currentTriple.Predicate.ToString().Replace("rdfdemolibrary:", string.Empty);

                if (predicateWithoutPrefix == this.inversePredicate.ToLower())
                {
                    var subject = new RDFResource(currentTriple.Object.ToString());
                    var predicate = new RDFResource(currentTriple.Predicate.ToString());
                    var @object = new RDFResource(currentTriple.Subject.ToString());
                    inferredTriples.Add(new RDFTriple(subject, predicate, @object));
                }
            }

            resultingTriples.AddRange(inferredTriples);
            return resultingTriples.Distinct();
        }
    }
}
