namespace MyBudgetingApp.Server.Data.Repositories.WalletRepository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _dataContext;

        public WalletRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> AddAsync(Wallet obj)
        {
            await _dataContext.Wallet.AddAsync(obj);
            await _dataContext.SaveChangesAsync();
            return obj.ID;
        }

        public Task DeleteByIdAsync(Guid id)
        {
            var obj = _dataContext.Wallet.Find(id);
            if (obj == null)
            {
                throw new NotFoundException($"Wallet with ID {id} not found");
            }
            _dataContext.Wallet.Remove(obj);
            return _dataContext.SaveChangesAsync();
        }

        public async Task<Wallet> GetByIdAsync(Guid id)
        {
            return await _dataContext.Wallet.FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new NotFoundException($"No wallet with ID no. {id} found!");
        }

        public async Task<IEnumerable<Wallet>> GetListByUserIdAsync(Guid userId)
        {
            var walletList = await _dataContext.Wallet.Where(x => x.Owner_FK_User_ID == userId).ToListAsync();
            if (!walletList.Any()) throw new NotFoundException($"No wallets found for user with ID no. {userId}!");
            return walletList;
        }

        public async Task UpdateAsync(Wallet obj)
        {
            _dataContext.Wallet?.Update(obj);
            await _dataContext.SaveChangesAsync();
        }
    }
}
