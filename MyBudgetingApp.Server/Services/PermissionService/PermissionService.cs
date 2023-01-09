using MyBudgetingApp.Shared.Dtos.PermissionDtos;

namespace MyBudgetingApp.Server.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly DtoMapper<Permission, PermissionDto> _permissionDtoMapper;
        private readonly DtoMapper<PermissionDto, Permission> _permissionMapper;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionDtoMapper = new DtoMapper<Permission, PermissionDto>();
            _permissionMapper = new DtoMapper<PermissionDto, Permission>();
        }

        public async Task<PermissionDto> GetPermissionByIdAsync(int id)
        {
            var permission = await _permissionRepository.GetPermissionByIdAsync(id);
            return _permissionDtoMapper.Map(permission);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsByUserIdAsync(int userId)
        {
            var permissionList = await _permissionRepository.GetPermissionsByUserIdAsync(userId);
            return permissionList.Select(permission => _permissionDtoMapper.Map(permission));
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsByWalletIdAsync(int walletId)
        {
            var permissionList = await _permissionRepository.GetPermissionsByWalletIdAsync(walletId);
            return permissionList.Select(permission => _permissionDtoMapper.Map(permission));
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsByBudgetIdAsync(int budgetId)
        {
            var permissionList = await _permissionRepository.GetPermissionsByBudgetIdAsync(budgetId);
            return permissionList.Select(permission => _permissionDtoMapper.Map(permission));
        }

        public async void AddPermissionAsync(PermissionDto permissionDto)
        {
            var permission = _permissionMapper.Map(permissionDto);
            await _permissionRepository.AddPermissionAsync(permission);
        }

        public async void UpdatePermissionAsync(PermissionDto permissionDto)
        {
            var permission = _permissionMapper.Map(permissionDto);
            await _permissionRepository.UpdatePermissionAsync(permission);
        }

        public async void DeletePermissionByIdAsync(int id)
        {
            // Delete the Permission from the database
            await _permissionRepository.DeletePermissionByIdAsync(id);
        }
    }
}
