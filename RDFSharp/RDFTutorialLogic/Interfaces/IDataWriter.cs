//-----------------------------------------------------------------------
// <copyright file="IDataReader.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using System.Collections.Generic;
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represents the interface for writing data to an external source.
    /// </summary>
    public interface IDataWriter
    {
        /// <summary>
        /// Writes 
        /// </summary>
        /// <param name="patha"></param>
        void Write(Ontology ontolgy, string path);
    }
}
