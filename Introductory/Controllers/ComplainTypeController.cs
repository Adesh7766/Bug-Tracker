using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainTypeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
