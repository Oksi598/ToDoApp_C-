using Microsoft.AspNetCore.Mvc;
using ToDoApp.BLL.Services;

namespace ToDoApp.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult GetResult(ServiceResponse serviseResponse)
        {
            return StatusCode((int)serviseResponse.StatusCode, serviseResponse);
        }
    }
}