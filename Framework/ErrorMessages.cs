namespace Framework
{
    /// <summary>
    /// Custom Error Messages
    /// </summary>
    public static class ErrorMessages
    {
        public static string ProvidedAccountNotFound => "The provided account number or ID could not be matched to an existing registry in the database.";
        public static string InternalError => "An error has occurred. Please try again, or contact an administrator in case the problem persists.";
    }
}
