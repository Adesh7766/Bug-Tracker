using Introductory.DAO;
using Introductory.Helper;
using Introductory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Introductory.Controllers
{
    public class BaseController : Controller
    {

        protected int SignedInUserID { get { 
                                                return HttpContext.Session.GetString("USER_ID").ToInt32(); 
                                           } 
        }

        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string session = HttpContext.Session.GetString("USER_ID");
            if (string.IsNullOrEmpty(session))
            {
                context.Result = new RedirectResult("/Auth/SignIn");
            }

            base.OnActionExecuting(context);
        }
    }
}
