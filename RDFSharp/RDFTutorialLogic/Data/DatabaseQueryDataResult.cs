//-----------------------------------------------------------------------
// <copyright file="DatabaseQueryTripleResult.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Data
{
    using System;

    /// <summary>
    /// Represents a result returned from a database operation containing information about whether a request
    /// to the database was successful as well as containing any resulting data.
    /// </summary>
    public class DatabaseQueryDataResult<TResult> where TResult : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseQueryDataResult{TResult}"/> class.
        /// </summary>
        /// <param name="success">A value indicating whether the request was successful.</param>
        /// <param name="data">The data returned from the request. May be null if request failed.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if data is null even though the success terminated successfully.
        /// </exception>
        public DatabaseQueryDataResult(bool success, TResult data)
        {
            if (success && data == null)
                throw new ArgumentNullException(nameof(data), "Result must not be null if request terminated successfully.");

            this.Success = success;
            this.Data = data;
        }

        /// <summary>
        /// Gets a value indicating whether the query was successful.
        /// </summary>
        public bool Success
        {
            get;
        }

        /// <summary>
        /// Gets the returned data.
        /// </summary>
        public TResult Data
        {
            get;
        }
    }
}
