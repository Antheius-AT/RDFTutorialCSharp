using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace RDFTutorialLogic.Data
{
    /// <summary>
    /// This class only exits temporary!
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst]
    [IgnoreEmptyLines]
    public class CsvTripleDataFormat
    {
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
    }
}
