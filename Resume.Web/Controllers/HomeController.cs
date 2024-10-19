using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;

namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Constractor

        private readonly IThingIDoServices _thingIDoServices;
        private readonly ICustomerFeedbackService _customerFeedbackService;
        private readonly ICustomerLogoService _customerLogoService;

        public HomeController(IThingIDoServices thingIDoServices, ICustomerFeedbackService customerFeedbackService, ICustomerLogoService customerLogoService)
        {
            _thingIDoServices = thingIDoServices;
            _customerFeedbackService = customerFeedbackService;
            _customerLogoService = customerLogoService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            IndexPageViewModel model = new IndexPageViewModel
            {
                ThingIDoList = await _thingIDoServices.GetAllThingIDoForIndex(),
                CustomerFeedbackList = await _customerFeedbackService.GetCustomerFeedbackForIndex(),
                CustomerLogoList = await _customerLogoService.GetCustomerLogoForIndexPage()
            };

            return View(model);
        }
    }
}
