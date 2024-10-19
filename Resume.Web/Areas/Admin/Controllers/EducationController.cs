using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        #region Costractor
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _educationService.GetAllEducation());
        }

        public async Task<IActionResult> LoadEducationFormModal(long id)
        {
            CreateOrEditEducationViewModel result =
                await _educationService.FillCreateOrEditEducationViewModel(id);

            return PartialView("_EducationFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitEducationFormModal(CreateOrEditEducationViewModel education)
        {
            var result = await _educationService.CreateOrEditEducation(education);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteEducation(long id)
        {
            var result = await _educationService.DeleteEducation(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

    }
}
