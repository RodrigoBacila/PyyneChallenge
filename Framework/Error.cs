namespace Framework
{
    /// <summary>
    /// Custom error class
    /// </summary>
    public class Error
    {
        public string Message { get; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="message">The error message</param>
        public Error(string message)
        {
            Message = message;
        }
    }
}
