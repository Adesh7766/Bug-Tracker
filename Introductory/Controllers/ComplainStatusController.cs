using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Introductory.Controllers
{
    public class ComplainStatusController : BaseController
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public ComplainStatusController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        [HttpPost]
        public JsonResult Save([FromBody] ComplainStatusVM vm)
        {
            if (string.IsNullOrEmpty(vm.ComplainStatusName))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter Complain Status Name"
                });
            }
            else if (string.IsNullOrEmpty(vm.ComplainStatusCode))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Select Complain Status Code"
                });
            }
            else
            {
                if (vm.ComplainStatusID == 0)
                {
                    // ADD NEW ROW
                    var oldComplain = _applicationDBContext
                                    .ComplainStatus
                                    .Where(x => x.ComplainStatusCode == vm.ComplainStatusCode)
                                    .FirstOrDefault();
                    if (oldComplain != null)
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Complain Status Already Exists"
                        });
                    }
                    else
                    {
                        ComplainStatus dbMdl = new ComplainStatus()
                        {
                            ComplainStatusID = vm.ComplainStatusID,
                            ComplainStatusName = vm.ComplainStatusName.ToText(),
                            ComplainStatusCode = vm.ComplainStatusCode.ToText(),
                            CreatedDate = DateTime.Now,
                            CreatedBy = SignedInUserID,
                            IsActive = true,
                        };

                        _applicationDBContext.ComplainStatus.Add(dbMdl);

                        _applicationDBContext.SaveChanges();
                        return Json(new
                        {
                            Success = true,
                            Message = "Complain Status Registered Successfully!!!"
                        });
                    }
                }
                else
                {
                    // UPDATE EXISTING ROWS
                    var oldRow = _applicationDBContext.ComplainStatus
                                    .Where(x => x.ComplainStatusID == vm.ComplainStatusID)
                                    .FirstOrDefault();
                    if (oldRow == null)
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Complain Status Not Found"
                        });
                    }
                    else
                    {
                        oldRow.ComplainStatusName = vm.ComplainStatusName.ToText();
                        oldRow.ComplainStatusCode = vm.ComplainStatusCode.ToText();

                        _applicationDBContext.SaveChanges();

                        return Json(new
                        {
                            Success = true,
                            Message = "Complain Status Updated Successfuly"
                        });
                    }
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var oldData = _applicationDBContext
                            .ComplainStatus
                            .Where(x => x.ComplainStatusID == id)
                            .FirstOrDefault();

            if (oldData == null)
            {
                return Json(new
                {
                    Success = false,
                    Messaage = "Data Not Found!"
                });
            }
            else
            {
                oldData.IsActive = false;
                _applicationDBContext.SaveChanges();

                return Json(new
                {
                    Success = true,
                    Messaage = "Complain Status Deleted Successfully!"
                });
            }
        }

        [HttpPost]
        public JsonResult GetAllData([FromBody] ComplainStatusVM vm)
        {
            List<ComplainStatusVM> dbData = _applicationDBContext
                                            .ComplainStatus
                                            .Where(x =>
                                              x.IsActive == true
                                              && (string.IsNullOrEmpty(vm.ComplainStatusName) || x.ComplainStatusName.Contains(vm.ComplainStatusName))
                                              && (string.IsNullOrEmpty(vm.ComplainStatusCode) || x.ComplainStatusCode.Contains(vm.ComplainStatusCode))
                                            )
                                            .Select(s => new ComplainStatusVM
                                            {
                                                ComplainStatusID = s.ComplainStatusID.ToInt32(),
                                                ComplainStatusName = s.ComplainStatusName.ToText(),
                                                ComplainStatusCode = s.ComplainStatusCode.ToText(),
                                                //CreatedDate = s.CreatedDate.ToNepaliDate(), //if CreatedDate is string in modal
                                                CreatedDate = DateTime.Now.ToShortDateString(),
                                                //CreatedBy = LoggedInUserID,
                                                Created_By = s.Users.Username.ToText(),
                                            })
                                           .ToList();

            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }

        [HttpGet]
        public JsonResult GetComplainStatus()
        {
            List <ComplainStatusVM> dbData = _applicationDBContext
                                          .ComplainStatus
                                          .Where(x => x.IsActive == true)
                                          .Select(s => new ComplainStatusVM
                                          {
                                              ComplainStatusID = s.ComplainStatusID.ToInt32(),
                                              ComplainStatusName = s.ComplainStatusName.ToText()
                                          })
                                          .ToList();

            return Json(new
            {
                Success = true,
                Data = dbData
            });
        }

        [HttpGet]
        public JsonResult GetComplainByID(int key)
        {
            var dbData = _applicationDBContext
                            .ComplainStatus
                            .Where(x => x.ComplainStatusID == key)
                            .FirstOrDefault();
            if (dbData == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Data Not Found In Database"
                });
            }
            else
            {
                return Json(new
                {
                    Success = true,
                    Data = dbData
                });
            }
        }
    }
}
