//-----------------------------------------------------------------------
// <copyright file="Triple.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Data
{
    using System;

    /// <summary>
    /// Represents the class for storing the data of a triple.
    /// </summary>
    public class Triple
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triple"/> class.
        /// </summary>
        /// <param name="subject">The subject of the triple.</param>
        /// <param name="predicate">The predicate of the triple.</param>
        /// <param name="object">The object of the triple.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// is thrown when
        /// ... the <paramref name="subject"/> is empty.
        /// ... the <paramref name="predicate"/> is empty.
        /// ... the <paramref name="object"/> is empty.
        /// </exception>
        public Triple(string subject, string predicate, string @object)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentOutOfRangeException(nameof(subject), "The subject must contain content an cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(predicate))
            {
                throw new ArgumentOutOfRangeException(nameof(predicate), "The predicate must contain content an cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(@object))
            {
                throw new ArgumentOutOfRangeException(nameof(@object), "The object must contain content an cannot be null.");
            }
              
            this.Subject = subject;
            this.Predicate = predicate;
            this.Object = @object;
        }

        /// <summary>
        /// Gets the subject of the triple.
        /// </summary>
        public string Subject
        {
            get;
        }

        /// <summary>
        /// Gets the predicate of the triple.
        /// </summary>
        public string Predicate
        {
            get;
        }

        /// <summary>
        /// Gets the object of the triple.
        /// </summary>
        public string @Object
        {
            get;
        }

        /// <summary>
        /// Overrides the <see cref="Object.ToString"/> method.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return $"{this.Subject} {this.Predicate} {this.Object}";
        }
    }
}