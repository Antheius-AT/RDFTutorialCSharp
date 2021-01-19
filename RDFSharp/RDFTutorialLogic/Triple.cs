using System;

namespace RDFTutorialLogic
{
    /// <summary>
    /// Represents the class for storing the data of a triple.
    /// </summary>
    internal class Triple
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
            if (subject == string.Empty)
                throw new ArgumentOutOfRangeException(nameof(subject), "The length of the subject has to be greater than 0 or null.");

            if (predicate == string.Empty)
                throw new ArgumentOutOfRangeException(nameof(predicate), "The length of the subject has to be greater than 0 or null.");

            if (@object == string.Empty)
                throw new ArgumentOutOfRangeException(nameof(@object), "The length of the subject has to be greater than 0 or null.");

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
    }
}