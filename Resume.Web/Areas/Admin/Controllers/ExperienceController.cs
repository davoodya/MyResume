using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ExperienceController : AdminBaseController
    {
        #region Coonstractor
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            return View(await _experienceService.GetAllExperience());
        }

        public async Task<IActionResult> LoadExperienceFormModal(long id)
        {
            CreateOrEditExperienceViewModel result =
                await _experienceService.FillCreateOrEditExperienceViewModel(id);

            return PartialView("_ExperienceFormModalPartial",result);
        }

        public async Task<IActionResult> SubmitExperienceFormModal(CreateOrEditExperienceViewModel experience)
        {
            var result = await _experienceService.CreateOrEditExperience(experience);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteExperience(long id)
        {
            var result = await _experienceService.DeleteExperience(id);

            if(result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
