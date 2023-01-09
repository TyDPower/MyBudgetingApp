namespace MyBudgetingApp.Server.Utilities.ErrorHandling
{
    public class NotFoundException : Exception
    {
        public int ErrorCode { get; } = 404;

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
