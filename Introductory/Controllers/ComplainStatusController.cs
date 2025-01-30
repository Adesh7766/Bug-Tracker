using Introductory.DAO;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainStatusController : BaseController
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public ComplainStatusController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllData()
        {
            List<ComplainStatusVM> dbData = _applicationDBContext
                                            .ComplainStatus
                                            .Where(x => x.IsActive == true)
                                            .Select(x => new ComplainStatusVM
                                            {
                                                ComplainStatusID = x.ComplainStatusID,
                                                ComplainStatusName = x.ComplainStatusName
                                            })
                                            .ToList();

            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }
    }
}
