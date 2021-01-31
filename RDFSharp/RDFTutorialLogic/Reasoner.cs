//-----------------------------------------------------------------------
// <copyright file="Reasoner.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using RDFSharp.Model;
    using RDFTutorialLogic.BusinessLogic;
    using RDFTutorialLogic.Interfaces;

    /// <summary>
    /// Represents a class capable of inferring knowledge that can be logically concluded from
    /// specific triples. 
    /// </summary>
    public class Reasoner
    {
        /// <summary>
        /// Dictionary associating properties with every available rule.
        /// </summary>
        private List<IInferencingRule> rules;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reasoner"/> class.
        /// </summary>
        public Reasoner()
        {
            this.rules = new List<IInferencingRule>
            {
                new TransitiveDependencyRule()
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reasoner"/> class.
        /// </summary>
        /// <param name="rules">The list of rules that are used by the reasoner.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if rule collection is null.
        /// </exception>
        public Reasoner(List<IInferencingRule> rules)
        {
            this.rules = rules ?? throw new ArgumentNullException(nameof(rules), "Rules must not be null.");
        }

        /// <summary>
        /// Registers a new rule with the reasoner.
        /// </summary>
        /// <param name="rule">The registered rule.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if rule is null.
        /// </exception>
        public void RegisterRule(IInferencingRule rule)
        {
            if (rule == null)
                throw new ArgumentNullException(nameof(rule), "Rule to register must not be null.");

            this.rules.Add(rule);
        }

        /// <summary>
        /// Gets all rules stored in the reasoner.
        /// </summary>
        /// <returns>The set of stored rules.</returns>
        public List<IInferencingRule> GetAllRules()
        {
            return new List<IInferencingRule>(this.rules);
        }

        /// <summary>
        /// Invokes the specified rules on the specified collection of triples to 
        /// generate new triples by inferring information.
        /// </summary>
        /// <param name="triples">The collection of triples.</param>
        /// <returns>The modified collection of triples containing newly generated, inferred triples.</returns>
        public IEnumerable<RDFTriple> InvokeRules(IEnumerable<RDFTriple> triples)
        {
            if (triples == null)
                throw new ArgumentNullException(nameof(triples), "Triples collection must not be null.");

            foreach (var rule in this.rules)
            {
                triples = rule.Invoke(triples);
            }

            return triples;
        }
    }
}
