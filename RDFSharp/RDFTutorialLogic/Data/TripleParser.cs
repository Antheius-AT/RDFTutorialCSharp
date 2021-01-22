//-----------------------------------------------------------------------
// <copyright file="TripleParser.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
using RDFTutorialLogic.Interfaces;

namespace RDFTutorialLogic.Data
{
    using System;
    using RDFTutorialLogic.Exceptions;

    /// <summary>
    /// Represent an object capable of parsing triples from raw triple data.
    /// </summary>
    public class TripleParser : ITripleParser
    {
        /// <summary>
        /// Parses raw triple data into a <see cref="Triple"/> object.
        /// </summary>
        /// <param name="data">An <see cref="RawTripleData"/> object representing the raw, unparsed triple data.</param>
        /// <returns>The parsed triple.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if data is null.
        /// </exception>
        /// <exception cref="TripleParsingFailedException">
        /// Is thrown if the data could not be converted into a triple.
        /// </exception>
        public Triple Parse(RawTripleData data)
        {
            throw new System.NotImplementedException();
        }
    }
}
