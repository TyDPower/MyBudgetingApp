using Microsoft.AspNetCore.Mvc;

namespace MyBudgetingApp.Server.Utilities.ErrorHandling
{
    public class ErrorHandling : ControllerBase
    {
        public ActionResult HandleError(Exception ex)
        {
            switch (ex)
            {
                case NotFoundException walletNotFoundEx:
                    // Log the exception and return a 404 Not Found status code
                    //_logger.LogError(userNotFoundEx, userNotFoundEx.Message);
                    return NotFound(walletNotFoundEx.Message);
                case InvalidRequestException invalidRequestEx:
                    // Log the exception and return a 400 Bad Request status code
                    //_logger.LogError(invalidRequestEx, invalidRequestEx.Message);
                    return BadRequest(invalidRequestEx.Message);
                default:
                    // Log the exception and return a 500 Internal Server Error status code
                    //_logger.LogError(ex, "An error occurred.");
                    return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

    }
}