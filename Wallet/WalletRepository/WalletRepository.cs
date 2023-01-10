using Microsoft.Data.SqlClient;

namespace MyBudgetingApp.Server.Data.Repositories.WalletRepository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _dataContext;

        public WalletRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Wallet>> GetWalletsAsync()
        {
            return await _dataContext.Wallet.ToListAsync() ?? throw new NotFoundException("No wallets found!");
        }

        public async Task<Wallet> GetWalletByIdAsync(int id)
        {
            return await _dataContext.Wallet.FirstOrDefaultAsync(w => w.RowID == id)
                ?? throw new NotFoundException($"No wallet with ID no. {id} found!");
        }
    }
}
