//-----------------------------------------------------------------------
// <copyright file="TripleParser.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Data
{
    using System;
    using RDFSharp.Model;
    using RDFTutorialLogic.Exceptions;
    using RDFTutorialLogic.Interfaces;

    /// <summary>
    /// Represent an object capable of parsing triples from raw triple data.
    /// </summary>
    public class TripleParser : ITripleParser
    {
        /// <summary>
        /// Represents the minimum length for a subject, predicate or object.
        /// </summary>
        private const int minimumLength = 1;

        /// <summary>
        /// A string representing the uri prefix of resources.
        /// </summary>
        private string uriPrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleParser"/> class.
        /// </summary>
        /// <param name="uriPrefix">The uri prefix used to locate resources.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if uri prefix is null.
        /// </exception>
        public TripleParser(string uriPrefix)
        {
            this.uriPrefix = uriPrefix ?? throw new ArgumentNullException(nameof(uriPrefix), "Uri prefix must not be null.");
        }

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
        public RDFTriple Parse(RawTripleData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Data to parse into a triple must not be null.");

            if (!ValidateRawTripleConstraints(data.Subject, data.Predicate, data.Object))
                throw new TripleParsingFailedException("The raw triple does not correspond the constraints.");

            RDFTriple triple;
            string subject;
            string predicate;
            string @object;

            subject = data.Subject;
            predicate = data.Predicate;
            @object = data.Object;

            triple = new RDFTriple(new RDFResource($"{this.uriPrefix}:{subject}"), new RDFResource($"{this.uriPrefix}:{predicate}"), new RDFResource($"{this.uriPrefix}:{@object}"));

            return triple;
        }

        /// <summary>
        /// Validates the subject, predicate and object of a triple and checks the following:
        /// ... subject, predicate and object are null or white space.
        /// ... subject, predicate and object have the <see cref="minimumLength"/>.
        /// </summary>
        /// <param name="subject">The subject of the raw triple.</param>
        /// <param name="predicate">The predicate of the raw triple.</param>
        /// <param name="object">The object of the raw triple.</param>
        /// <returns>True if the triple fullfil the constraints.</returns>
        private bool ValidateRawTripleConstraints(string subject, string predicate, string @object)
        {
            if(string.IsNullOrWhiteSpace(subject) && string.IsNullOrWhiteSpace(predicate) && string.IsNullOrWhiteSpace(@object))
            {
                return false;
            }

            if(subject.Length < minimumLength || predicate.Length < minimumLength || @object.Length < minimumLength)
            {
                return false;
            }

            return true;
        }
    }
}
