using Introductory.DAO;
using Introductory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Introductory.Controllers
{
    public class ComplainTypeController : BaseController
    {
        private readonly ApplicationDBContext _context;

        public ComplainTypeController(ApplicationDBContext applicationDBContext)
        {
            _context = applicationDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public JsonResult GetAllData(string name, string code)
        {


            var dbData = _context
                         .ComplainType
                         .Where(x =>
                                x.IsActive == true
                             && (string.IsNullOrEmpty(name) || x.ComplainTypeName.Contains(name))
                             && (string.IsNullOrEmpty(code) || x.ComplainTypeCode.Contains(code))
                         )
                         .OrderByDescending(o => o.CreatedDate)
                         .ToList();


            return Json(new
            {
                Success = true,
                Data = dbData
            });


        }
        public JsonResult GetComplainTypeByID(int key)
        {
            var dbData = _context
                            .ComplainType
                            .Where(x => x.ComplainTypeID == key)
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
        public JsonResult SaveData(int id, string name, string code)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter Compalin type Name"
                });
            }
            else if (string.IsNullOrEmpty(code))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter Compalin type Code"
                });
            }
            else
            {
                if (id == 0)
                {
                    ComplainType CT;
                    CT = new ComplainType();

                    CT.ComplainTypeName = name;
                    CT.ComplainTypeCode = code;
                    CT.CreatedDate = DateTime.Now;
                    CT.CreatedBy = SignedInUserID;
                    CT.IsActive = true;


                    _context.ComplainType.Add(CT);
                    _context.SaveChanges();

                    var obj = new
                    {
                        Success = true,
                        Message = "Data Inserted Succesfully"
                    };
                    return Json(obj);
                }
                else
                {
                    // update garne
                    var dbData = _context
                                    .ComplainType
                                    .Where(x => x.ComplainTypeID == id)
                                    .FirstOrDefault();
                    if (dbData == null)
                    {
                        var obj = new
                        {
                            Success = false,
                            Message = "Data Not Found in Database"
                        };
                        return Json(obj);
                    }
                    else
                    {
                        dbData.ComplainTypeName = name;
                        dbData.ComplainTypeCode = code;

                        _context.SaveChanges();
                        var obj = new
                        {
                            Success = true,
                            Message = "Data Modified Successfully"
                        };
                        return Json(obj);
                    }
                }
            }

        }

        public JsonResult DeleteData(int key)
        {
            var dbData = _context
                            .ComplainType
                            .Where(x => x.ComplainTypeID == key)
                            .FirstOrDefault();
            if (dbData == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Data not found in Database"
                });
            }
            else
            {
                dbData.IsActive = false;
                _context.SaveChanges();

                return Json(new
                {
                    Success = true,
                    Message = "Complain Type Info Deleted Successfully"
                });
            }
        }
    }
}
