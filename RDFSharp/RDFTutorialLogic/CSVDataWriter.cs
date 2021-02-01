using System;
using System.Collections.Generic;
using System.Text;

namespace RDFTutorialLogic
{
    using FileHelpers;
    using Interfaces;
    using RDFTutorialLogic.Data;

    public class CSVDataWriter : IDataWriter
    {
        private readonly FileHelperEngine<RawTripleData> writer;
        public CSVDataWriter()
        {
            this.writer = new FileHelperEngine<RawTripleData>();
        }

        public void Write(Ontology ontolgy, string path)
        {
            throw new NotImplementedException();
        }
    }
}
