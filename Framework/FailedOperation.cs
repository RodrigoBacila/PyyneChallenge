namespace Framework
{
    /// <summary>
    /// Failed Operation
    /// </summary>
    public class FailedOperation : IOperation
    {
        public Error Error { get; }
        public FailureCause Cause { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="failureCause">The failure cause</param>
        public FailedOperation(string errorMessage, FailureCause failureCause)
        {
            Error = new Error(errorMessage);
            Cause = failureCause;
        }

        public bool WasBecauseOfValidationIssues() => Cause == FailureCause.Validation;
        public bool WasBecauseTargetCouldNotBeFound() => Cause == FailureCause.NotFound;
        public bool WasBecauseOfInternalError() => Cause == FailureCause.InternalError;
    }

    /// <summary>
    /// Failed Operation (typed)
    /// </summary>
    /// <typeparam name="T">The current type</typeparam>
    public class FailedOperation<T> : FailedOperation, IOperation<T>
    {
        public T? Result => default;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="failureCause">The failure cause</param>
        public FailedOperation(string errorMessage, FailureCause failureCause) : base(errorMessage, failureCause)
        { }
    }
}
