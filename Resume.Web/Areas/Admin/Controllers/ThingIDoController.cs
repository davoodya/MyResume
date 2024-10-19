using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ThingIDoController : AdminBaseController
    {
        #region Constractor
        private readonly IThingIDoServices _thingIDoService;

        public ThingIDoController(IThingIDoServices thingIDoService)
        {
            _thingIDoService = thingIDoService;
        }

        #endregion


        public async Task<IActionResult> Index()
        {
            return View(await _thingIDoService.GetAllThingIDoForIndex());
        }

        public async Task<IActionResult> LoadThingIDoFormModal(long id)
        {
            CreateOrEditThingIDoViewModel result = await _thingIDoService.FillCreateOrEditThingIDoViewModel(id);

            return PartialView("_ThingIDoFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitThingIDoFormModal(CreateOrEditThingIDoViewModel thingIDo)
        {
            var result = await _thingIDoService.CreateOrEditThingIDo(thingIDo);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteThingIDo(long id)
        {
            var result = await _thingIDoService.DeleteThingIDo(id);
            if (result)
                return new JsonResult(new { status = "Success" });
            
            return new JsonResult(new { Status = "Error" });
        }

    }
}
