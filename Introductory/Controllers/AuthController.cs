using Introductory.DAO;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Introductory.Controllers
{
    public class AuthController : Controller
    {
        ApplicationDBContext _applicationDBcontext;

        public AuthController(ApplicationDBContext applicationDBcontext)
        {
            _applicationDBcontext = applicationDBcontext;
        }

        public IActionResult SignIn()
        {
            HttpContext.Session.Remove("USER_ID");
            return View();
        }

        [HttpPost("SignIn")]
        public ActionResult SignIn(SignInVM vm)
        {
            var user = _applicationDBcontext
                            .Users
                            .Where(x => x.Username == vm.Username)
                            .FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found";
            }
            else
            {
                if (user.Password != vm.Password)
                {
                    ViewBag.ErrorMessage = "Password did not match";
                }
                else
                {
                    HttpContext.Session.SetString("USER_ID", user.UserID.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }
    }
}
