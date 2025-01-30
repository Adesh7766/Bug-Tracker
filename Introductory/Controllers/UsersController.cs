using System.ComponentModel.DataAnnotations;
using System.Net;
using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Introductory.Controllers
{
    public class UsersController : BaseController
    {
        ApplicationDBContext _applicationDBContext;

        public UsersController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save([FromBody] UsersVM usersVM)
        {

            if (string.IsNullOrEmpty(usersVM.UserName))
            {
                var obj = new
                {
                    Success = false,
                    Message = "Username is required"
                };

                return Json(obj);
            }
            else if(usersVM.UserGroupId == 0)
            {
                var obj = new
                {
                    Success = false,
                    Message = "UserGroup ID required"
                };

                return Json(obj);
            }
            else if(usersVM.Password != usersVM.ConfirmPassword)
            {
                var obj = new
                {
                    Success = false,
                    Message = "Confirm your password."
                };

                return Json(obj);
            }
            else if (string.IsNullOrEmpty(usersVM.Password))
            {
                var obj = new
                {
                    Success = false,
                    Message = "Password is required"
                };

                return Json(obj);
            }
            else if(string.IsNullOrEmpty(usersVM.ConfirmPassword))
            {
                var obj = new
                {
                    Success = false,
                    Message = "Confirm your password"
                };

                return Json(obj);
            }
            else if(string.IsNullOrEmpty(usersVM.Fullname))
            {
                var obj = new 
                { 
                    Success = false,
                    Message = "Fullname is required"
                };

                return Json(obj);
            }
            else if(string.IsNullOrEmpty(usersVM.Email))
            {
                var obj = new
                {
                    Success = false,
                    Message = "Email is required"
                };

                return Json(obj);
            }
            else if(string.IsNullOrEmpty(usersVM.ContactNo))
            {
                var obj = new
                {
                    Success = false,
                    Message = "Contact number is required"
                };

                return Json(obj);
            }
            else
            {
                var duplicate = _applicationDBContext
                                 .Users
                                 .Where(x => x.Username == usersVM.UserName)
                                 .FirstOrDefault();
                
                if(duplicate == null)
                {
                    if(usersVM.UserID == 0)
                    { 
                        Users newUser = new Users()
                        {
                            Username = usersVM.UserName,
                            UserGroupId = usersVM.UserGroupId,
                            Password = usersVM.Password,
                            ValidFrom = usersVM.ValidFrom.ToEnglishDate(),
                            ValidTo = usersVM.ValidTo.ToEnglishDate(),
                            Fullname = usersVM.Fullname,
                            Email = usersVM.Email,
                            ContactNo = usersVM.ContactNo,
                            Address = usersVM.Address,
                            DOB = usersVM.DOB.ToEnglishDate(),
                            isActive = true
                        };

                        _applicationDBContext.Add(newUser);
                        _applicationDBContext.SaveChanges();

                        var obj = new
                        {
                            Success = true,
                            Message = "User added successfully"
                        };

                        return Json(obj);
                    }
                    else
                    {
                        //Update data

                        var oldData = _applicationDBContext
                                        .Users
                                        .Where(x => x.UserID == usersVM.UserID)
                                        .FirstOrDefault();

                        if(oldData == null)
                        {
                            return Json(new
                            {
                                Success = false,
                                Message = "User not found in database"
                            });
                        }
                        else
                        {
                            oldData.Username = usersVM.UserName;
                            oldData.UserGroupId = usersVM.UserGroupId;
                            oldData.Password = usersVM.Password;
                            oldData.ValidFrom = usersVM.ValidFrom.ToEnglishDate();
                            oldData.ValidTo = usersVM.ValidTo.ToEnglishDate();
                            oldData.Fullname = usersVM.Fullname;
                            oldData.Email = usersVM.Email;
                            oldData.ContactNo = usersVM.ContactNo;
                            oldData.Address = usersVM.Address;
                            oldData.DOB = usersVM.DOB.ToEnglishDate();

                            _applicationDBContext.SaveChanges();

                            return Json(new
                            {
                                Success = true,
                                Message = "User updated successfully."
                            });
                            

                        }

                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "User already exists"
                    });
                }
                
            }
        }


        [HttpPost]
        public JsonResult GetAllData([FromBody] UsersVM usersVM)
        {
            List<UsersVM> dbData = _applicationDBContext
                                .Users
                                .Where(x => x.isActive == true
                                     &&(string.IsNullOrEmpty(usersVM.UserName) || x.Username.Contains(usersVM.UserName))
                                     &&(string.IsNullOrEmpty(usersVM.ContactNo) || x.Username.Contains(usersVM.ContactNo))
                                )
                                .Select(x => new UsersVM
                                {
                                    UserID = x.UserID.ToInt32(),
                                    UserName = x.Username.ToText(),
                                    Fullname = x.Fullname.ToText(),
                                    Address = x.Address.ToText(),
                                    Email = x.Email.ToText(),
                                    ContactNo = x.ContactNo.ToText(),
                                    ValidFrom = x.ValidFrom.ToNepaliDate(),
                                    ValidTo = x.ValidTo.ToNepaliDate()
                                })
                                .ToList();

            return Json(new
            {
                success = true,
                data = dbData
            });
        }

        public JsonResult GetUserById(int id)
        {
            UsersVM? dbData = _applicationDBContext
                           .Users
                           .Where(x => x.UserID == id)
                           .Select(x => new UsersVM
                           {
                               UserName = x.Username.ToText(),
                               Fullname = x.Fullname.ToText(),
                               Address = x.Address.ToText(),
                               Email = x.Email.ToText(),
                               ContactNo = x.ContactNo.ToText(),
                               ValidFrom = x.ValidFrom.ToNepaliDate().ToText(),
                               ValidTo = x.ValidTo.ToNepaliDate().ToText(),
                               DOB = x.DOB.ToNepaliDate().ToText()
                           })
                           .FirstOrDefault();

            if(dbData == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Data not found in database"
                });
            }
            else
            {
                return Json(new
                {
                    Success = true,
                    data = dbData
                });
            }


        }

        public JsonResult deleteData(int id)
        {
            var dbData = _applicationDBContext
                            .Users
                            .Where(x => x.UserID == id)
                            .FirstOrDefault();

            if(dbData == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Data does not exist in database"
                });
            }
            else
            {
                dbData.isActive = false;
                _applicationDBContext.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Data deleted successfully"
                });
            }
        }
    }
}
