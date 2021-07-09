using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pars.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [Authorize]
    //[BreadCrumb(Title = "خانه", UseDefaultRouteUrl = true, Order = 0)]
    public class HomeController : Controller
    {
        //[BreadCrumb(Title = "داشبورد", Order = 1)]
        public IActionResult Index() => View();
    }
}