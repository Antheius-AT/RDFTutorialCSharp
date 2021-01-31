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
    public class PredicateDependencyRule : IInferencingRule
    {
        /// <summary>
        /// The base predicate from which the connection emanates.
        /// </summary>
        private readonly string basePredicate;

        /// <summary>
        /// The predicate which is mapped in an unidiretional way to the base predicate.
        /// </summary>
        private readonly string mappedPredicate;

        /// <summary>
        /// The prefix 
        /// </summary>
        private readonly string prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateDependencyRule"/> class.
        /// </summary>
        /// <param name="basePredicate">The base predicate from which the connection emanates.</param>
        /// <param name="mappedPredicate">The predicate which is mapped in an unidiretional way to the base predicate.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the base predicate or the mapped predicate is null.
        /// </exception>
        public PredicateDependencyRule(string basePredicate, string mappedPredicate)
        {
            this.basePredicate = basePredicate ?? throw new ArgumentNullException(nameof(basePredicate));
            this.mappedPredicate = mappedPredicate ?? throw new ArgumentNullException(nameof(mappedPredicate));
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
            for (int i = 0; i < triples.Count(); i++)
            {
                for (int j = i; j < triples.Count(); j++)
                {
                    var baseTriple = triples.ElementAt(i);
                    var currTriple = triples.ElementAt(j);

                    if(baseTriple.Predicate.ToString() != this.basePredicate)
                        break;

                    
                    
                }
            }

            return new List<RDFTriple>();
        }
    }
}
