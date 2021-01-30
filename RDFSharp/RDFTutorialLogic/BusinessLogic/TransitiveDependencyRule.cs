//-----------------------------------------------------------------------
// <copyright file="TransitiveDependencyRule.cs" company="FHWN">
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
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Interfaces;

    /// <summary>
    /// Represents a rule to infer transitive dependencies and generate new triples
    /// based on those dependencies.
    /// </summary>
    public class TransitiveDependencyRule : IInferencingRule
    {
        /// <summary>
        /// Invokes the specified rule.
        /// </summary>
        /// <param name="triples">The collection of triples.</param>
        /// <returns>The modified collection of triples.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if triples is null.
        /// </exception>
        public IEnumerable<RDFTriple> Invoke(IEnumerable<RDFTriple> triples)
        {
            // Fall 1
            // Mensch hat Geld
            // Denise ist scheiße
            // Gregor ist Mensch

            // Inferenziere: Gregor ist Mensch --> Mensch hat Geld --> Gregor hat Geld.
            // Hier setze ich in das Subjekt des ursprünglichen Triples das Subjekt jenes Triples ein, wo das Subjekt des ursprünglichen
            // Triples das Objekt ist.

            // Fall 2
            // Gregor ist Mensch
            // Denise ist scheiße
            // Mensch hat Geld

            // Hier setze ich Das Subjekt des ursprünglichen Triples dort ein, wo das Objekt des ursprünglichen Triples
            // Das Subjekt ist.

            var tripleResult = triples.ToList();
            var inferredTriples = new List<RDFTriple>();

            for (int i = 0; i < triples.Count(); i++)
            {
                for (int j = i + 1; j < triples.Count(); j++)
                {
                    // Hier das zu vergleichende Triple (i) mit dem jeweils aktuellen Triple (j) vergleichen.
                    var currentTriple = triples.ElementAt(j);
                    var baseTriple = triples.ElementAt(i);

                    // 1: Mensch hat geld.
                    if (baseTriple.Subject.ToString() == currentTriple.Object.ToString())
                    {
                        var subject = new RDFResource(currentTriple.Subject.ToString());
                        var predicate = new RDFResource(baseTriple.Predicate.ToString());
                        var @object = new RDFResource(baseTriple.Object.ToString());
                        var inferredTriple = new RDFTriple(subject, predicate, @object);
                        
                        inferredTriples.Add(inferredTriple);
                    }
                    else if (baseTriple.Object.ToString() == currentTriple.Subject.ToString())
                    {
                        var subject = new RDFResource(baseTriple.Subject.ToString());
                        var predicate = new RDFResource(currentTriple.Predicate.ToString());
                        var @object = new RDFResource(currentTriple.Object.ToString());
                        var inferredTriple = new RDFTriple(subject, predicate, @object);

                        inferredTriples.Add(inferredTriple);
                    }
                    
                }

            }

            return inferredTriples;
        }
    }
}
