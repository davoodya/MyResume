using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;

namespace Resume.Web.Controllers
{
    public class PortfolioController : Controller
    {
        #region Constractor
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            PortfolioPageViewModel model = new PortfolioPageViewModel()
            {
                 Portfolios = await _portfolioService.GetAllPortfolios(),
                 PortfolioCategories = await _portfolioService.GetAllPortfolioCategories()
            };

            return View(model);
        }
    }
}
