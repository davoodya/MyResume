using System.Collections.Generic;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Domain.ViewModels.Page
{
    public class PortfolioPageViewModel
    {
        public List<PortfolioViewModel> Portfolios { get; set; }
        public List<PortfolioCategoryViewModel> PortfolioCategories { get; set; }
    }
}
