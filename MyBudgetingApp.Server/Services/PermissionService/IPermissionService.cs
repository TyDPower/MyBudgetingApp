namespace MyBudgetingApp.Server.Services.PermissionService
{
    public interface IPermissionService
    {
        Task<PermissionDto> GetPermissionByIdAsync(Guid id);
        Task<IEnumerable<PermissionDto>> GetPermissionsByUserIdAsync(Guid userId);
        Task<IEnumerable<PermissionDto>> GetPermissionsByWalletIdAsync(Guid walletId);
        Task<IEnumerable<PermissionDto>> GetPermissionsByBudgetIdAsync(Guid budgetId);
        Task<Guid> AddPermissionAsync(PermissionDto permissionDto);
        Task UpdatePermissionAsync(PermissionDto permissionDto);
        Task DeletePermissionByIdAsync(Guid id);
    }
}
