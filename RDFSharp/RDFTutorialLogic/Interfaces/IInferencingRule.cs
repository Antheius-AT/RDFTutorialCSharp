//-----------------------------------------------------------------------
// <copyright file="TripleStore.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using RDFSharp.Model;

    /// <summary>
    /// Represent an inferencing rule which can be applied by an inferencer
    /// to infer and generate new triples.
    /// </summary>
    public interface IInferencingRule
    {
        /// <summary>
        /// Invokes the specified rule.
        /// </summary>
        /// <param name="triples">The collection of triples.</param>
        /// <returns>The modified collection of triples.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if triples is null.
        /// </exception>
        IEnumerable<RDFTriple> Invoke(IEnumerable<RDFTriple> triples);
    }
}
