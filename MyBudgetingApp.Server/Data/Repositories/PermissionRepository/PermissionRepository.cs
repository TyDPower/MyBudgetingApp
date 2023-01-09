namespace MyBudgetingApp.Server.Data.Repositories.PermissionRepository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DataContext _dataContext;

        public PermissionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _dataContext.Permission.FirstOrDefaultAsync(p => p.ID == id) 
                ?? throw new NotFoundException($"No permission with ID no. {id} found!");
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByUserIdAsync(int userId)
        {
            var permissionList = await _dataContext.Permission.Where(p => p.FK_User_ID == userId).ToListAsync();
            if (!permissionList.Any()) throw new NotFoundException($"No permissions found for user with ID no. {userId}!");
            return permissionList;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByWalletIdAsync(int walletId)
        {
            var permissionList = await _dataContext.Permission.Where(p => p.FK_Wallet_ID == walletId).ToListAsync();
            if (!permissionList.Any()) throw new NotFoundException($"No permissions found for wallet with ID no. {walletId}!");
            return permissionList;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByBudgetIdAsync(int budgetId)
        {
            var permissionList = await _dataContext.Permission.Where(p => p.FK_Budget_ID == budgetId).ToListAsync();
            if (!permissionList.Any()) throw new NotFoundException($"No permissions found for budget with ID no. {budgetId}!");
            return permissionList;
        }

        public async Task AddPermissionAsync(Permission permission)
        {
            await _dataContext.Permission.AddAsync(permission);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            _dataContext.Permission.Update(permission);
            await _dataContext.SaveChangesAsync();
        }

        public Task DeletePermissionByIdAsync(int id)
        {
            var permission = _dataContext.Permission.Find(id);
            if (permission == null)
            {
                throw new NotFoundException($"Permission with ID {id} not found");
            }
            _dataContext.Permission.Remove(permission);
            return _dataContext.SaveChangesAsync();
        }
    }
}

