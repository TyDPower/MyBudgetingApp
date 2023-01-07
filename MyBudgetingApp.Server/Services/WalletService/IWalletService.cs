namespace MyBudgetingApp.Server.Services.WalletService
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletDto>> GetWalletsAsync();
    }
}
