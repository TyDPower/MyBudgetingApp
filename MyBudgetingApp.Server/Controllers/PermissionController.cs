using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudgetingApp.Shared.Dtos.PermissionDtos;
using MyBudgetingApp.Shared.Dtos.WalletDtos;

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
        public async Task<ActionResult<PermissionDto>> GetPermissionByIdAsync(int id)
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
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissionsByUserIdAsync(int userId)
        {
            try
            {
                // Call the service to get the permission by user id
                var permission = await _permissionService.GetPermissionsByUserIdAsync(userId);
                // Return the permission as a PermissionDto object
                return Ok(permission);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("wallet/{walletId}")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissionsByWalletIdAsync(int walletId)
        {
            try
            {
                // Call the service to get the permission by wallet id
                var permission = await _permissionService.GetPermissionsByWalletIdAsync(walletId);
                // Return the permission as a PermissionDto object
                return Ok(permission);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("budget/{budgetId}")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetPermissionsByBudgetIdAsync(int budgetId)
        {
            try
            {
                // Call the service to get the permission by budget id
                var permission = await _permissionService.GetPermissionsByBudgetIdAsync(budgetId);
                // Return the permission as a PermissionDto object
                return Ok(permission);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpPost("create")]
        public ActionResult AddPermissionAsync(PermissionDto permissionDto)
        {
            try
            {
                // Call the service to get the permission by budget id
                _permissionService.AddPermissionAsync(permissionDto);
                // Return the permission as a PermissionDto object
                return Ok();
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpPut("update")]
        public ActionResult UpdatePermissionAsync(PermissionDto permissionDto)
        {
            try
            {
                // Call the service to get the permission by budget id
                _permissionService.UpdatePermissionAsync(permissionDto);
                // Return the permission as a PermissionDto object
                return Ok();
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpDelete("delete")]
        public ActionResult DeletePermissionByIdAsync(int id)
        {
            try
            {
                _permissionService.DeletePermissionByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

    }
}
