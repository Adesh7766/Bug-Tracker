using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
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

        [HttpPost]
        public JsonResult GetAllData([FromBody] ComplainStatusVM vm)
        {
            List<ComplainStatusTrackInfoVM> dbdata = _applicationDBContext
                                                     .ComplainStatusTrackInfo
                                                     .Where( x => 
                                                                (vm.ComplainStatusID == x.ComplainStatusID || vm.ComplainStatusID == 0)
                                                     )
                                                     .Select(x => new ComplainStatusTrackInfoVM
                                                     {
                                                         ComplainStatusTrackInfoID = x.ComplainStatusTrackInfoID.ToInt32(),
                                                         ComplainID = x.ComplainID.ToInt32(),
                                                         ComplainStatusID = x.ComplainStatusID.ToInt32(),
                                                         Remarks = x.Remarks.ToText(),
                                                         CreatedBy = x.CreatedBy.ToInt32(),
                                                         CreatedDate = x.CreatedDate.ToNepaliDate().ToText(),
                                                         Created_By = x.User.Username.ToText(),
                                                         ComplainStatus = x.ComplainStatus.ComplainStatusName.ToText()
                                                     })
                                                     .ToList();

            return Json(new
            {
                Success = true,
                Data = dbdata
            });
        }
    }
}
