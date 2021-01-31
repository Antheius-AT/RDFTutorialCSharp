//-----------------------------------------------------------------------
// <copyright file="ITripleParser.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using System;
    using RDFSharp.Model;
    using RDFTutorialLogic.Data;
    using RDFTutorialLogic.Exceptions;

    /// <summary>
    /// Represents an object capable of parsing objects of type <see cref="RawTripleData"/> into
    /// the <see cref="EnhancedRDFTriple"/> type.
    /// </summary>
    public interface ITripleParser
    {
        /// <summary>
        /// Parses raw triple data into a <see cref="EnhancedRDFTriple"/> object.
        /// </summary>
        /// <param name="data">An <see cref="RawTripleData"/> object representing the raw, unparsed triple data.</param>
        /// <returns>The parsed triple.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if data is null.
        /// </exception>
        /// <exception cref="TripleParsingFailedException">
        /// Is thrown if the data could not be converted into a triple.
        /// </exception>
        RDFTriple Parse(RawTripleData data);
    }
}
