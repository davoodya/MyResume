using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            TempData[WarningMessage] = "اخطار";
            TempData[InfoMessage] = "پیغام راهنما";
            TempData[ErrorMessage] = "عملیات با خطا مواجه شد";

            return View();
        }
    }
}
