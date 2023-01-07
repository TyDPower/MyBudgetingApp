using Microsoft.AspNetCore.Mvc;

namespace MyBudgetingApp.Server.Utilities.SuccessHandling
{
    public class SuccessHandling : ControllerBase
    {
        public ActionResult HandleSuccess(object result)
        {
            return new OkObjectResult(result);
        }

        public ActionResult HandleSuccess(IEnumerable<object> result)
        {
            return new OkObjectResult(result);
        }
    }

}
