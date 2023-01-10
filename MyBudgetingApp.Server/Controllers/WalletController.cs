using MyBudgetingApp.Shared.Models;

namespace MyBudgetingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController
    {
        private readonly IWalletService _walletService;
        private readonly ErrorHandling _errorHandler;
        private readonly SuccessHandling _successHandler;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
            _errorHandler = new ErrorHandling();
            _successHandler = new SuccessHandling();
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<WalletDto>> GetByIdAsync(Guid id)
        {
            try
            {
                // Call the service to get the permission by id
                var dto = await _walletService.GetByIdAsync(id);
                // Return the permission as a PermissionDto object
                return _successHandler.HandleSuccess(dto);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WalletDto>>> GetListByUserIdAsync(Guid userId)
        {
            try
            {
                // Call the service to get the wallet by user id
                var obj = await _walletService.GetListByUserIdAsync(userId);
                // Return the wallet as a WalletDto object
                return _successHandler.HandleSuccess(obj);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddAsync(WalletDto dto)
        {
            try
            {
                var id = await _walletService.AddAsync(dto);
                return _successHandler.HandleSuccess($"Wallet with ID {id} has been successfully created!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(WalletDto dto)
        {
            try
            {
                await _walletService.AddAsync(dto);
                return _successHandler.HandleSuccess($"Wallet with ID {dto.ID} has been successfully updated!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteByIdAsync(Guid id)
        {
            try
            {
                _walletService.DeleteByIdAsync(id);
                return _successHandler.HandleSuccess($"Wallet with ID {id} has been successfully deleted!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }
    }
}
