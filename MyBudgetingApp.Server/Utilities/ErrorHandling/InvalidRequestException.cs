namespace MyBudgetingApp.Server.Utilities.ErrorHandling
{
    public class InvalidRequestException : Exception
    {
        public int ErrorCode { get; } = 400;

        public InvalidRequestException(string message) : base(message)
        {
        }
    }
}
