using MyBudgetingApp.Shared.Dtos.BudgetDtos;

namespace MyBudgetingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController
    {
        private readonly IBudgetService _controllerService;
        private readonly ErrorHandling _errorHandler;
        private readonly SuccessHandling _successHandler;
        private readonly string _controller;

        public BudgetController(IBudgetService controllerService)
        {
            _controllerService = controllerService;
            _controller = "Budget";
            _errorHandler = new ErrorHandling();
            _successHandler = new SuccessHandling();
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddAsync(BudgetDto dto)
        {
            try
            {
                var id = await _controllerService.AddAsync(dto);
                return _successHandler.HandleSuccess($"{_controller} with ID {id} has been successfully created!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(BudgetDto dto)
        {
            try
            {
                await _controllerService.UpdateAsync(dto);
                return _successHandler.HandleSuccess($"{_controller} with ID {dto.ID} has been successfully updated!");
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
                _controllerService.DeleteByIdAsync(id);
                return _successHandler.HandleSuccess($"{_controller} with ID {id} has been successfully deleted!");
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<object>> GetByIdAsync(Guid id)
        {
            try
            {
                var dto = await _controllerService.GetByIdAsync(id);
                return _successHandler.HandleSuccess(dto);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [HttpGet("getListById/user/{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetListByUserIdAsync(Guid id)
        {
            try
            {
                var obj = await _controllerService.GetListByUserIdAsync(id);
                return _successHandler.HandleSuccess(obj);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }
    }
}
