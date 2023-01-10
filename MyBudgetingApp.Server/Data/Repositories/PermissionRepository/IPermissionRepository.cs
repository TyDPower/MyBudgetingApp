namespace MyBudgetingApp.Server.Data.Repositories.PermissionRepository
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionByIdAsync(Guid id);
        Task<IEnumerable<Permission>> GetPermissionsByUserIdAsync(Guid userId);
        Task<IEnumerable<Permission>> GetPermissionsByWalletIdAsync(Guid walletId);
        Task<IEnumerable<Permission>> GetPermissionsByBudgetIdAsync(Guid budgetId);
        Task<Guid> AddPermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionByIdAsync(Guid id);
    }
}
