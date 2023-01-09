namespace MyBudgetingApp.Server.Data.Repositories.PermissionRepository
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<IEnumerable<Permission>> GetPermissionsByUserIdAsync(int userId);
        Task<IEnumerable<Permission>> GetPermissionsByWalletIdAsync(int walletId);
        Task<IEnumerable<Permission>> GetPermissionsByBudgetIdAsync(int budgetId);
        Task AddPermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionByIdAsync(int id);
    }
}
