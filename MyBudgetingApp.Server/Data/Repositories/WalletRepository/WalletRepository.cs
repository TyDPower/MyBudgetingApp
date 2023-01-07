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
            try
            {
                return await _dataContext.Wallet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
