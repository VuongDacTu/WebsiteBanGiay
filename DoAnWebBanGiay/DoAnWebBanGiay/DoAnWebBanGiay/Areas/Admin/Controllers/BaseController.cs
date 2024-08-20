using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // kiem tra dang nhap cua admin
            if (context.HttpContext.Session.GetString("AdminLogin") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "DangNhap",
                    Action = "Login",
                    Areas = "Admin"
                }));
            }
            base.OnActionExecuted(context);
        }
    }
}
