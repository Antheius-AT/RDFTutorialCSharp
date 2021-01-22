//-----------------------------------------------------------------------
// <copyright file="ITripleParser.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
using RDFTutorialLogic.Data;

namespace RDFTutorialLogic.Interfaces
{
    /// <summary>
    /// Represents an object capable of parsing objects of type <see cref="RawTripleData"/> into
    /// the <see cref="Triple"/> type.
    /// </summary>
    public interface ITripleParser
    {
        /// <summary>
        /// Parses raw triple data into a <see cref="Triple"/> object.
        /// </summary>
        /// <param name="data">An <see cref="RawTripleData"/> object representing the raw, unparsed triple data.</param>
        /// <returns>The parsed triple.</returns>
        Triple Parse(RawTripleData data);
    }
}
