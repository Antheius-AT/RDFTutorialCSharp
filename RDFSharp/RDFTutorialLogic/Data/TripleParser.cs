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
    using System.Linq;
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
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Data to parse into a triple must not be null.");

            Triple triple;
            string subject;
            string predicate;
            string @object;

            subject = data.Subject;
            predicate = data.Predicate;
            @object = data.Object;

            triple = new Triple(subject, predicate, @object);

            return triple;
        }
    }
}
