using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult SaveComplain([FromBody] ComplainVM vm)
        //{
        //    if (string.IsNullOrEmpty(vm.FullNme))
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "FullName is required."
        //        });
        //    }
        //    else if (string.IsNullOrEmpty(vm.ContactNo))
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "Contact Number is required."
        //        });
        //    }
        //    else if (string.IsNullOrEmpty(vm.email))
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "email is required."
        //        });
        //    }
        //    else if (string.IsNullOrEmpty(vm.Statement))
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "Statement is required."
        //        });
        //    }
        //    else if (string.IsNullOrEmpty(vm.Address))
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "Address is required."
        //        });
        //    }
        //    else if (vm.ComplainTypeId == 0)
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "Complain Type is required."
        //        });
        //    }
        //    else if (string.IsNullOrEmpty(vm.IssueDate))
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = "Issue Date is required."
        //        });
        //    }
        //    else
        //    {
        //        //Write the code for saving and updating the complain.
        //    }
        //}
    }
}
