//-----------------------------------------------------------------------
// <copyright file="RawTripleData.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace RDFTutorialLogic
{
    /// <summary>
    /// Represents triple data that was read from an external source, and has
    /// not yet been parsed.
    /// </summary>
    public class RawTripleData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RawTripleData"/> class.
        /// </summary>
        /// <param name="data">The data which was read from an external source.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if data is null.
        /// </exception>
        public RawTripleData(IEnumerable<string> data)
        {
            this.Data = data ?? throw new ArgumentNullException(nameof(data), "Data must not be null.");

            this.Data = data;
        }

        /// <summary>
        /// Gets the raw data.
        /// </summary>
        public IEnumerable<string> Data
        {
            get;
        }
    }
}
