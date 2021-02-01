//-----------------------------------------------------------------------
// <copyright file="IDataReader.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic.Interfaces
{
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represents the interface for writing data to an external source.
    /// </summary>
    public interface IDataWriter
    {
        /// <summary>
        /// Writes data from an ontology to a given csv file.
        /// </summary>
        /// <param name="ontolgy">The ontology whichs data is written to a file.</param>
        /// <param name="path">The path to the file.</param>
        void Write(Ontology ontolgy, string path);
    }
}
