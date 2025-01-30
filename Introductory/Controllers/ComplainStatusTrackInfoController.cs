using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainStatusTrackInfoController : BaseController
    {
        ApplicationDBContext _applicationDBContext;

        public ComplainStatusTrackInfoController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllData()
        {
            List<ComplainStatusTrackInfoVM> dbdata = _applicationDBContext
                                                     .ComplainStatusTrackInfo
                                                     .Select(x => new ComplainStatusTrackInfoVM
                                                     {
                                                         ComplainStatusTrackInfoID = x.ComplainStatusTrackInfoID.ToInt32(),
                                                         ComplainID = x.ComplainID.ToInt32(),
                                                         ComplainStatusID = x.ComplainStatusID.ToInt32(),
                                                         Remarks = x.Remarks.ToText(),
                                                         CreatedBy = x.CreatedBy.ToInt32(),
                                                         CreatedDate = x.CreatedDate.ToNepaliDate().ToText()
                                                     })
                                                     .ToList();

            return Json(new
            {
                Success = true,
                data = dbdata
            });
        }
    }
}
