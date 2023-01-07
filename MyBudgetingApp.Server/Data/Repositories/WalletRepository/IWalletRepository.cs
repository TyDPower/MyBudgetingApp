using Microsoft.AspNetCore.Mvc;

namespace MyBudgetingApp.Server.Data.Repositories.WalletRepository
{
    public interface IWalletRepository
    {
        Task<IEnumerable<Wallet>> GetWalletsAsync();
    }
}
