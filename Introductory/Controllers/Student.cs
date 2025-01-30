using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class Student : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
