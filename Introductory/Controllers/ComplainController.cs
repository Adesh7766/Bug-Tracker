using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainController : BaseController
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public ComplainController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult SaveComplain([FromBody] ComplainVM vm)
        {
            if (string.IsNullOrEmpty(vm.FullName))
            {
                return Json(new
                {
                    Success = false,
                    Message = "FullName is required."
                });
            }
            else if (string.IsNullOrEmpty(vm.ContactNo))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Contact Number is required."
                });
            }
            else if (string.IsNullOrEmpty(vm.email))
            {
                return Json(new
                {
                    Success = false,
                    Message = "email is required."
                });
            }
            else if (string.IsNullOrEmpty(vm.Statement))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Statement is required."
                });
            }
            else if (string.IsNullOrEmpty(vm.Address))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Address is required."
                });
            }
            else if (vm.ComplainTypeId == 0)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Complain Type is required."
                });
            }
            else if (string.IsNullOrEmpty(vm.IssueDate))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Issue Date is required."
                });
            }
            else
            {
                if(vm.ComplainId == 0)
                {
                    if(string.IsNullOrEmpty(vm.FullName))
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Full name is not provided."
                        });
                    }
                    else if (string.IsNullOrEmpty(vm.email))
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Email is not provided"
                        });
                    }
                    else if (string.IsNullOrEmpty(vm.ContactNo))
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Contact Number is not provided"
                        });
                    }
                    else if (string.IsNullOrEmpty(vm.Statement))
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Statement is not provided"
                        });
                    }
                    else if (string.IsNullOrEmpty(vm.Address))
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Address is not provided"
                        });
                    }
                    else if (vm.ComplainTypeId == 0)
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Complain Type is not provided"
                        });
                    }
                    else if (string.IsNullOrEmpty(vm.IssueDate))
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Issue Date is not provided"
                        });
                    }
                    else
                    {
                        var oldComplain = _applicationDBContext
                                            .Complain
                                            .Where(x => x.email == vm.email)
                                            .FirstOrDefault();

                        if(oldComplain != null)
                        {
                            return Json(new
                            {
                                Success = false,
                                Message = "email already existsfor other user."
                            });
                        }
                        else
                        {
                            Complain complain = new Complain
                            {
                                FullName = vm.FullName,
                                email = vm.email,
                                ContactNo = vm.ContactNo,
                                Statement = vm.Statement,
                                Address = vm.Address,
                                CustomerId = HttpContext.Session.GetString("USER_ID").ToInt32(),
                                IssueDate = vm.IssueDate.ToEnglishDate(),
                                CreatedDate = DateTime.Now,
                                ComplainTypeId = vm.ComplainTypeId
                            };

                            _applicationDBContext.Add(complain);
                            _applicationDBContext.SaveChanges();

                            return Json(new
                            {
                                Success = true,
                                Message = "Complain Saved Successfully"
                            });
                        }
                    }
                }
                else
                {
                    var oldComplain = _applicationDBContext
                                        .Complain
                                        .Where(x => x.ComplainId == vm.ComplainId)
                                        .FirstOrDefault();

                    
                    if(oldComplain == null)
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Complain does not exists in the database"
                        });
                    }
                    else
                    {
                        oldComplain.FullName = vm.FullName;
                        oldComplain.email = vm.email;
                        oldComplain .ContactNo = vm.ContactNo;
                        oldComplain .Statement = vm.Statement;  
                        oldComplain .Address = vm.Address;
                        oldComplain.CustomerId = vm.CustomerId;
                        oldComplain.IssueDate = vm.IssueDate.ToEnglishDate();
                        oldComplain.CreatedDate = DateTime.Now;
                        oldComplain.ComplainTypeId = vm.ComplainTypeId;

                        _applicationDBContext.Add(oldComplain);
                        _applicationDBContext.SaveChanges();

                        return Json(new
                        {
                            Success = true,
                            Message = "Complain updated successfully."
                        });
                    }
                }
            }
        }
    }
}
