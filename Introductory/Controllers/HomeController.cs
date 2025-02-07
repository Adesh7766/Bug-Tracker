using System.Diagnostics;
using Introductory.DAO;
using Introductory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDBContext _applicationDBContext;

        public HomeController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult GetChartData()
        {
            var users = _applicationDBContext.Users
                        .Where(x => x.isActive == true)
                        .ToList();

            var userGroup = _applicationDBContext
                            .UserGroup
                            .Where(x => x.isActive == 1)
                            .ToList();

            return Json(new
            {
                Success = true,
                Data = new
                {
                    usersInfo = users,
                    userGroupInfo = userGroup
                }
            });
        }

        [HttpGet]
        public JsonResult GetComplainTypeData()
        {
            var complains = _applicationDBContext.Complain.ToList();

            var complainType = _applicationDBContext.ComplainType.Where(x => x.IsActive == true);


            return Json(new
            {
                Success = true,
                Data = new
                {
                    ComplainInfo = complains,
                    ComplainTypeInfo = complainType
                }
            });
        }
    }
}
