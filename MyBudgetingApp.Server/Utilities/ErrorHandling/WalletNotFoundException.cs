namespace MyBudgetingApp.Server.Utilities.ErrorHandling
{
    public class WalletNotFoundException : Exception
    {
        public int ErrorCode { get; } = 404;

        public WalletNotFoundException(string message) : base(message)
        {
        }
    }
}
