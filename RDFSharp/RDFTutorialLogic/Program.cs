//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman, Tom Pirich</author>
//-----------------------------------------------------------------------
namespace RDFTutorialLogic
{
    using System.Collections.Generic;
    using RDFSharp.Model;
    using RDFTutorialLogic.Data;

    /// <summary>
    /// Represents the program class with entry point of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Represents the entry point of the application.
        /// </summary>
        public static void Main()
        {
            var uriPrefix = "RDFDemoLibrary";
            var reader = new CSVDataReader();
            var parser = new TripleParser(uriPrefix);
            var reasoner = new Reasoner();
        }
    }
}

