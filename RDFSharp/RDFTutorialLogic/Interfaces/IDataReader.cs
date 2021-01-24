//-----------------------------------------------------------------------
// <copyright file="DatabaseQuerySuccessResult.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Represents the interface for reading in data.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Reads the data from a specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A collection of raw triple data which will be processed further.</returns>
        IEnumerable<RawTripleData> Read(string path);
    }
}
