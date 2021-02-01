//-----------------------------------------------------------------------
// <copyright file="RawTripleData.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Data
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FileHelpers;

    /// <summary>
    /// Represents triple data that was read from an external source, and has
    /// not yet been parsed.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst]
    [IgnoreEmptyLines]
    public class RawTripleData : IEquatable<RawTripleData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RawTripleData"/> class.
        /// </summary>
        /// <param name="data">The data which was read from an external source.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if data is null.
        /// </exception>
        //public RawTripleData(IEnumerable<string> data)
        //{
        //    this.Data = data ?? throw new ArgumentNullException(nameof(data), "Data must not be null.");
        //}

        /// <summary>
        /// Gets or sets the subject of the triple.
        /// </summary>
        [FieldOrder(1)]
        [FieldCaption(nameof(Subject))]
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the predicate of the triple.
        /// </summary>
        [FieldOrder(2)]
        [FieldCaption(nameof(Predicate))]
        public string Predicate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the object of the triple.
        /// </summary>
        [FieldOrder(3)]
        [FieldCaption(nameof(@Object))]
        public string @Object
        {
            get;
            set;
        }

        /// <summary>
        /// Overrides the <see cref="Object.ToString"/> method.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return $"{this.Subject} {this.Predicate} {this.Object}";
        }

        /// <summary>
        /// Determines whether two instances of <see cref="RawTripleData"/> are equal to another.
        /// </summary>
        /// <param name="other">The data to compare this instance to.</param>
        /// <returns>Whether or not the objects are equal.</returns>
        public bool Equals([AllowNull] RawTripleData other)
        {
            return this.Subject == other.Subject && this.Predicate == other.Predicate && this.Object == other.Object;
        }
    }
}
