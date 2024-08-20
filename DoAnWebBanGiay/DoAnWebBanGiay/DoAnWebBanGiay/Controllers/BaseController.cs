using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoAnWebBanGiay.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // kiem tra dang nhap cua admin
            if (context.HttpContext.Session.GetString("CustomerLogin") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "DangNhap",
                    Action = "Login",
                    Areas = ""
                }));
            }
            base.OnActionExecuted(context);
        }
    }
}
