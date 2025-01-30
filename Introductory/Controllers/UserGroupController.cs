 using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class UserGroupController : BaseController
    {
        ApplicationDBContext _applicationDBContext;

        public UserGroupController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            //    List<UserGroup> ug = new List<UserGroup>
            //    {
            //        new UserGroup { Name = "Super Admin", Code = "SA", CreatedDate = DateTime.Now, isActive = 1 },
            //        new UserGroup { Name = "Admin", Code = "AD", CreatedDate = DateTime.Now, isActive = 1 },
            //        new UserGroup { Name = "Manager", Code = "MG", CreatedDate = DateTime.Now, isActive = 1 },
            //        new UserGroup { Name = "Driver", Code = "DV", CreatedDate = DateTime.Now, isActive = 1 },
            //    };


            //    try   
            //    { 
            //    _applicationDBContext.UserGroup.AddRange(ug);
            //    _applicationDBContext.SaveChanges();
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine($"Error: { ex.Message }");
            //    }

            var data = _applicationDBContext.UserGroup.Where(x => x.isActive == 1).ToList();

            return View(data);
        }

        public JsonResult saveData(int id, string name, string code)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Json(new
                {
                    success = false,
                    message = "Enter User group name"
                });
            }
            else if(string.IsNullOrEmpty(code))
            {
                return Json(new
                {
                    success = false,
                    message = "Enter user group code"
                });
            }
            else
            {
                var duplicate = _applicationDBContext
                                .UserGroup
                                .Where(x => x.Code == code)
                                .FirstOrDefault();

                if(duplicate == null)
                {
                    if(id == 0)
                    { 
                        UserGroup ug;
                        ug = new UserGroup()
                        {
                            Name = name,
                            Code = code,
                            CreatedDate = DateTime.Now,
                            CreatedBy = SignedInUserID,
                            isActive = 1
                        };

                        _applicationDBContext.Add(ug);
                        _applicationDBContext.SaveChanges();

                        var obj = new
                        {
                            success = true,
                            message = "Data added successfully"
                        };

                        return Json(obj);
                    }
                    else
                    {
                        //Update data
                        var dbData = _applicationDBContext
                                     .UserGroup
                                     .Where(x => x.UserGroupID == id)
                                     .FirstOrDefault();
                        if(dbData == null)
                        {
                            var obj = new
                            {
                                success = false,
                                message = "Data not found in Databse"
                            };

                            return Json(obj);
                        }
                        else
                        {
                            dbData.Name = name;
                            dbData.Code = code;

                            _applicationDBContext.SaveChanges();


                            var obj = new
                            {
                                success = true,
                                message = "Data updated successfully"
                            };

                            return Json(obj);
                        }
                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "User group code already exists"
                    });
                }
            }
        }

        public JsonResult deleteData(int key)
        {
            var dbData = _applicationDBContext
                        .UserGroup
                        .Where(x => x.UserGroupID == key)
                        .FirstOrDefault();

            if(dbData == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Data not found"
                });
            }
            else
            {
                dbData.isActive = 0;
                _applicationDBContext.SaveChanges();
                return Json(new
                {
                    Success = true,
                    Message = "Data deleted successfully"
                });
            }
        }

        public JsonResult GetUserGroupByID(int key)
        {
            var dbData = _applicationDBContext
                        .UserGroup
                        .Where(x => x.UserGroupID == key)
                        .FirstOrDefault();

            if(dbData == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Data not found in Database"
                });
            }
            else
            {
                return Json(new
                {
                    success = true,
                    Data = dbData
                });
            }
        }

        public JsonResult GetAllData(string name, string code)
        {
            var dbData = _applicationDBContext
                        .UserGroup
                        .Where(x => 
                                x.isActive == 1
                                && (string.IsNullOrEmpty(name) || x.Name.Contains(name))
                                && (string.IsNullOrEmpty(code) || x.Code.Contains(code))
                                )
                        .OrderByDescending(o => o.CreatedDate)
                        .ToList();

            return Json(new
            {
                success = true,
                data = dbData
            });
        }
    }
}
