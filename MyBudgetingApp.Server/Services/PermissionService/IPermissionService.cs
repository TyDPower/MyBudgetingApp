using MyBudgetingApp.Shared.Dtos.PermissionDtos;

namespace MyBudgetingApp.Server.Services.PermissionService
{
    public interface IPermissionService
    {
        Task<PermissionDto> GetPermissionByIdAsync(int id);
        Task<IEnumerable<PermissionDto>> GetPermissionsByUserIdAsync(int userId);
        Task<IEnumerable<PermissionDto>> GetPermissionsByWalletIdAsync(int walletId);
        Task<IEnumerable<PermissionDto>> GetPermissionsByBudgetIdAsync(int budgetId);
        void AddPermissionAsync(PermissionDto permissionDto);
        void UpdatePermissionAsync(PermissionDto permissionDto);
        void DeletePermissionByIdAsync(int id);
    }
}
