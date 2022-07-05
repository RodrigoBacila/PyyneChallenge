namespace Framework
{
    /// <summary>
    /// Operation Interface
    /// </summary>
    public interface IOperation
    { }

    /// <summary>
    /// Operation Interface (typed)
    /// </summary>
    /// <typeparam name="T">The current type</typeparam>
    public interface IOperation<T> : IOperation
    {
        T? Result { get; }
    }
}
