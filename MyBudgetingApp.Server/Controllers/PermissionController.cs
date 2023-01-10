using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudgetingApp.Shared.Dtos.PermissionDtos;

namespace MyBudgetingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly ErrorHandling _errorHandler;
        private readonly SuccessHandling _successHandler;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
            _errorHandler = new ErrorHandling();
            _successHandler = new SuccessHandling();
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<PermissionDto>> GetPermissionByIdAsync(Guid id)
        {
            try
            {
                // Call the service to get the permission by id
                var permissionDto = await _permissionService.GetPermissionByIdAsync(id);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess(permissionDto);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissionsByUserIdAsync(Guid userId)
        {
            try
            {
                // Call the service to get the permission by user id
                var permission = await _permissionService.GetPermissionsByUserIdAsync(userId);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess(permission);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("wallet/{walletId}")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissionsByWalletIdAsync(Guid walletId)
        {
            try
            {
                // Call the service to get the permission by wallet id
                var permission = await _permissionService.GetPermissionsByWalletIdAsync(walletId);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess(permission);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("budget/{budgetId}")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissionsByBudgetIdAsync(Guid budgetId)
        {
            try
            {
                // Call the service to get the permission by budget id
                var permission = await _permissionService.GetPermissionsByBudgetIdAsync(budgetId);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess(permission);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddPermissionAsync(PermissionDto permissionDto)
        {
            try
            {
                // Call the service to get the permission by budget id
                var id = await _permissionService.AddPermissionAsync(permissionDto);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess($"Permission with ID {id} has been successfully created!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }

        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePermissionAsync(PermissionDto permissionDto)
        {
            try
            {
                // Call the service to get the permission by budget id
                await _permissionService.UpdatePermissionAsync(permissionDto);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess($"Permission with ID {permissionDto.ID} has been successfully updated!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeletePermissionByIdAsync(Guid id)
        {
            try
            {
                _permissionService.DeletePermissionByIdAsync(id);
                return _successHandler.HandleSuccess($"Permission with ID {id} has been successfully deleted!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

    }
}
