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

        [HttpGet("GetWalletsAsync")]
        public async Task<ActionResult<IEnumerable<WalletDto>>> GetWalletsAsync()
        {
            try
            {
                var walletDtoList = await _walletService.GetWalletsAsync();
                return _successHandler.HandleSuccess(walletDtoList);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
            
        }
    }
}
