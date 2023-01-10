namespace MyBudgetingApp.Server.Services.WalletService
{
    public interface IWalletService
    {
        Task<WalletDto> GetByIdAsync(Guid id);
        Task<IEnumerable<WalletDto>> GetListByUserIdAsync(Guid userId);
        Task<Guid> AddAsync(WalletDto dto);
        Task UpdateAsync(WalletDto dto);
        Task DeleteByIdAsync(Guid id);
    }
}
