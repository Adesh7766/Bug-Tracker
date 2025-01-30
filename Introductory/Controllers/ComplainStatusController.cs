using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainStatusController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
