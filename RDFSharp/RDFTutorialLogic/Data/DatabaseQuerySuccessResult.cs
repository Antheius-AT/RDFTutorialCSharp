//-----------------------------------------------------------------------
// <copyright file="DatabaseQuerySuccessResult.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Data
{
    /// <summary>
    /// Represents a result returned from a database operation containing information about whether a request
    /// to the database was successful.
    /// </summary>
    public class DatabaseQuerySuccessResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseQuerySuccessResult"/> class.
        /// </summary>
        /// <param name="success">A value indicating whether the request was successful.</param>
        public DatabaseQuerySuccessResult(bool success)
        {
            this.Success = success;
        }

        /// <summary>
        /// Gets a value indicating whether the query was successful.
        /// </summary>
        public bool Success
        {
            get;
        }
    }
}
