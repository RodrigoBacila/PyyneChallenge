namespace Framework
{
    /// <summary>
    /// Successful Operation
    /// </summary>
    public class SuccessfulOperation : IOperation
    {
        public static string Message => "The operation was performed successfully.";
    }

    /// <summary>
    /// Successful Operation (typed)
    /// </summary>
    /// <typeparam name="T">The current type</typeparam>
    public class SuccessfulOperation<T> : IOperation<T>
    {
        public T Result { get; }

        public SuccessfulOperation(T result)
        {
            Result = result;
        }
    }
}
