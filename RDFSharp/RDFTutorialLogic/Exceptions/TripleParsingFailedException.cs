//-----------------------------------------------------------------------
// <copyright file="TripleParsingFailedException.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represents an exception that is thrown if the parsing of <see cref="RawTripleData"/> 
    /// into a <see cref="Triple"/> object was not successful.
    /// </summary>
    public class TripleParsingFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripleParsingFailedException"/> class.
        /// </summary>
        public TripleParsingFailedException() : base()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TripleParsingFailedException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if message is null.
        /// </exception
        public TripleParsingFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleParsingFailedException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if either of the parameters are null.
        /// </exception
        public TripleParsingFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripleParsingFailedException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The object that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if either of the parameters are null.
        /// </exception>
        public TripleParsingFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
