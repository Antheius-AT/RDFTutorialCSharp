using System;

namespace RDFTutorialLogic
{
    using FileHelpers;
    /// <summary>
    /// Represents the program class with entry point of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Represents the entry point of the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main()
        {
            var engine = new FileHelperEngine<Triple>();
          
            var result = engine.ReadFile("text.csv");
            var triple = new Triple();
            triple.

        }
    }
}
