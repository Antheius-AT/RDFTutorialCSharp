namespace RDFTutorialLogic
{
    /// <summary>
    /// Represents the class for storinn the data of a triple.
    /// </summary>
    internal class Triple
    {
        /// <summary>
        /// Gets or sets the subject of the triple.
        /// </summary>
        public string Subject
        {
            get;
        }

        /// <summary>
        /// Gets or sets the predicate of the triple.
        /// </summary>
        public string Predicate
        {
            get;
        }

        /// <summary>
        /// Gets or sets the object of the triple.
        /// </summary>
        public string @Object
        {
            get;
        }
    }
}