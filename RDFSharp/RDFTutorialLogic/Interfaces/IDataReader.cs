﻿//-----------------------------------------------------------------------
// <copyright file="IDataReader.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Represents the interface for reading in data from an external source.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Reads the data from a specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A collection of raw triple data which will be processed further.</returns>
        IEnumerable<RawTripleData> Read(string path);

        /// <summary>
        /// Reads in data from multiple files.
        /// </summary>
        /// <param name="paths">The paths to the files.</param>
        /// <returns>An enumerable of raw triples.</returns>
        public IEnumerable<RawTripleData> ReadFiles(params string[] paths);
    }
}
