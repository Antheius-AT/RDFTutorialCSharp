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
    using Interfaces;
    using RDFSharp.Model;

    /// <summary>
    /// Represents an inferencing rule which maps a predicate to another predicate in an unidirectional way.
    /// </summary>
    public class TransitiveDependencyRule : IInferencingRule
    {
        /// <summary>
        /// The base predicate from which the connection emanates.
        /// </summary>
        private readonly string basePredicate;

        /// <summary>
        /// The predicate which is mapped in an unidiretional way to the base predicate.
        /// </summary>
        private readonly string mappedPredicate;


        private readonly bool basePredicateIsRelatedToSubject;

        /// <summary>
        /// A value indicating whether the mapped 
        /// </summary>
        private readonly bool mappedPredicateIsRelatedToSubject;

        /// <summary>
        /// The prefix 
        /// </summary>
        private readonly string prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitiveDependencyRule"/> class.
        /// </summary>
        /// <param name="basePredicate">The base predicate from which the connection emanates.</param>
        /// <param name="mappedPredicate">The predicate which is mapped in an unidiretional way to the base predicate.</param>
        /// <param name="basePredicateIsRelatedToSubject">Determines whether the base predicate is related to the subject.</param>
        /// <param name="mappedPredicateIsRelatedToSubject">Determines whether the mapped predicate is related to the subject.</param>
        /// <param name="prefix">The prefix of a triple.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the base predicate or the mapped predicate is null.
        /// </exception>
        public TransitiveDependencyRule(string basePredicate, string mappedPredicate, bool basePredicateIsRelatedToSubject, bool mappedPredicateIsRelatedToSubject, string prefix)
        {
            this.basePredicate = basePredicate ?? throw new ArgumentNullException(nameof(basePredicate));
            this.mappedPredicate = mappedPredicate ?? throw new ArgumentNullException(nameof(mappedPredicate));
            this.basePredicateIsRelatedToSubject = basePredicateIsRelatedToSubject;
            this.mappedPredicateIsRelatedToSubject = mappedPredicateIsRelatedToSubject;
            this.prefix = prefix;
        }

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
            // Case: 
            // Elsa gehört Irina
            // Gregor ist zusammen mit Irina.
            // ist zusammen ist gemapped auf gehört: ist zusammen => gehört
            // => PredicateRule(basePredicate: ist zusammen, mappedPredicate: gehört)
            // Result = Elsa gehört Gregor.

            // Das Haus gehört Irina
            // Irina hat Schulden bei Gregor.
            // schuldet Geld ist gemapped auf gehört: schuldet Geld => gehört
            // => PredicateRule(basePredicate: ist zusammen, mappedPredicate: gehört)
            // Result = Elsa gehört Gregor.
            var generateDTriples = triples.ToList();
            var inferredTriples = new List<RDFTriple>();
            for (int i = 0; i < triples.Count(); i++)
            {
                for (int j = 0; j < triples.Count(); j++)
                {
                    if (i == j)
                        continue;

                    var baseTriple = triples.ElementAt(i);
                    var currTriple = triples.ElementAt(j);

                    if(baseTriple.Predicate.ToString() != this.basePredicate)
                        break;
                    // At this point: Base triple has predicate: "ist zusammen" 

                    if (currTriple.Predicate.ToString() != this.mappedPredicate)
                        continue;
                    // At this. point the predicate of the current triple is equal to the mapped predicate.

                    inferredTriples = this.ManageRelation(baseTriple, currTriple, inferredTriples);
                }
            }

            generateDTriples.AddRange(inferredTriples);
            return generateDTriples.Distinct();
        }

        /// <summary>
        /// Manages the relationship for the base triple and the mapped triple.
        /// </summary>
        /// <param name="baseTriple"></param>
        /// <param name="mappedTriple"></param>
        /// <param name="inferredTriples"></param>
        /// <returns></returns>
        private List<RDFTriple> ManageRelation(RDFTriple baseTriple, RDFTriple mappedTriple, List<RDFTriple> inferredTriples)
        {
            if (this.basePredicateIsRelatedToSubject)
            {
                if (this.mappedPredicateIsRelatedToSubject)
                {
                    ManageBasePredRelToSubAndMappedPredRelToSubCase(baseTriple, mappedTriple, inferredTriples);
                }
                else
                {
                    ManageBasePredRelToSubAndMappedPredRelToObjCase(baseTriple, mappedTriple, inferredTriples);
                }

            }
            else
            {
                if (this.mappedPredicateIsRelatedToSubject)
                {
                    ManageBasePredRelToObjAndMappedPredRelToSubCase(baseTriple, mappedTriple, inferredTriples);
                }
                else
                {
                    ManageBasePredRelToObjAndMappedPredRelToObjCase(baseTriple, mappedTriple, inferredTriples);
                }
            }

            return inferredTriples;
        }


        /// <summary>
        /// Manages the case when the predicate of the base triple is related to the subject and
        /// the mapped predicate is related to the subject.
        /// </summary>
        /// <param name="baseTriple">The base triple.</param>
        /// <param name="mappedTriple">The triple which is mapped onto the predicate of the base triple.</param>
        /// <param name="inferredTriples">The list of inferred triples.</param>
        private void ManageBasePredRelToSubAndMappedPredRelToSubCase(RDFTriple baseTriple, RDFTriple mappedTriple, List<RDFTriple> inferredTriples)
        {
            if (baseTriple.Subject.ToString() == mappedTriple.Subject.ToString())
            {
                var inferredTriple = new RDFTriple(
                    new RDFResource(mappedTriple.Object.ToString()),
                    new RDFResource(mappedTriple.Predicate.ToString()),
                    new RDFResource(baseTriple.Object.ToString())
                    );

                inferredTriples.Add(inferredTriple);
            }
        }

        /// <summary>
        /// Manages the case when the predicate of the base triple is related to the subject and
        /// the mapped predicate is related to the object.
        /// </summary>
        /// <param name="baseTriple">The base triple.</param>
        /// <param name="mappedTriple">The triple which is mapped onto the predicate of the base triple.</param>
        /// <param name="inferredTriples">The list of inferred triples.</param>
        private void ManageBasePredRelToSubAndMappedPredRelToObjCase(RDFTriple baseTriple, RDFTriple mappedTriple, List<RDFTriple> inferredTriples)
        {
            if (baseTriple.Subject.ToString() == mappedTriple.Object.ToString())
            {
                var inferredTriple = new RDFTriple(
                    new RDFResource(mappedTriple.Subject.ToString()),
                    new RDFResource(mappedTriple.Predicate.ToString()),
                    new RDFResource(baseTriple.Object.ToString())
                    );

                inferredTriples.Add(inferredTriple);
            }
        }


        /// <summary>
        /// Manages the case when the predicate of the base triple is related to the object and
        /// the mapped predicate is related to the subject.
        /// </summary>
        /// <param name="baseTriple">The base triple.</param>
        /// <param name="mappedTriple">The triple which is mapped onto the predicate of the base triple.</param>
        /// <param name="inferredTriples">The list of inferred triples.</param>
        private void ManageBasePredRelToObjAndMappedPredRelToSubCase(RDFTriple baseTriple, RDFTriple mappedTriple, List<RDFTriple> inferredTriples)
        {
            if (baseTriple.Object.ToString() == mappedTriple.Subject.ToString())
            {
                var inferredTriple = new RDFTriple(
                    new RDFResource(baseTriple.Subject.ToString()),
                    new RDFResource(mappedTriple.Predicate.ToString()),
                    new RDFResource(mappedTriple.Object.ToString())
                    );

                inferredTriples.Add(inferredTriple);
            }
        }


        /// <summary>
        /// Manages the case when the predicate of the base triple is related to the object and
        /// the mapped predicate is related to the object.
        /// </summary>
        /// <param name="baseTriple">The base triple.</param>
        /// <param name="mappedTriple">The triple which is mapped onto the predicate of the base triple.</param>
        /// <param name="inferredTriples">The list of inferred triples.</param>
        private void ManageBasePredRelToObjAndMappedPredRelToObjCase(RDFTriple baseTriple, RDFTriple mappedTriple, List<RDFTriple> inferredTriples)
        {
            if (baseTriple.Object.ToString() == mappedTriple.Object.ToString())
            {
                var inferredTriple = new RDFTriple(
                    new RDFResource(baseTriple.Subject.ToString()),
                    new RDFResource(mappedTriple.Predicate.ToString()),
                    new RDFResource(mappedTriple.Subject.ToString())
                    );

                inferredTriples.Add(inferredTriple);
            }
        }
    }
}
