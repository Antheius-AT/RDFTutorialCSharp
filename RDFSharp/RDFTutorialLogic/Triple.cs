namespace RDFTutorialLogic
{
    /// <summary>
    /// Represents the class for storing the data of a triple.
    /// </summary>
    internal class Triple
    {
        /// <summary>
        /// Gets the subject of the triple.
        /// </summary>
        public string Subject
        {
            get;
        }

        /// <summary>
        /// Gets the predicate of the triple.
        /// </summary>
        public string Predicate
        {
            get;
        }

        /// <summary>
        /// Gets the object of the triple.
        /// </summary>
        public string @Object
        {
            get;
        }
    }
}