using Microsoft.AspNetCore.Mvc;

namespace MyBudgetingApp.Server.Data.Repositories.WalletRepository
{
    public interface IWalletRepository
    {
        Task<Wallet> GetByIdAsync(Guid id);
        Task<IEnumerable<Wallet>> GetListByUserIdAsync(Guid userId);
        Task<Guid> AddAsync(Wallet obj);
        Task UpdateAsync(Wallet obj);
        Task DeleteByIdAsync(Guid id);
    }
}
