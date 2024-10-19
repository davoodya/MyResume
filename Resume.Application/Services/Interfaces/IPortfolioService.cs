
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Services.Interfaces
{
    public interface IPortfolioService
    {
        
        #region Portfolio Category

        Task<PortfolioCategory>  GetPortfolioCategoryById(long id);
        Task<List<PortfolioCategoryViewModel>> GetAllPortfolioCategories();
        Task<CreateOrEditPortfolioCategoryViewModel> FillCreateOrEditPortfolioCategoryViewModel(long  id);
        Task<bool> CreateOrEditPortfolioCategory(CreateOrEditPortfolioCategoryViewModel portfolioCategory);
        Task<bool> DeletePortfolioCategory(long id);
        #endregion

        #region Portfolios
        Task<Portfolio> GetPortfolioById(long id);
        Task<List<PortfolioViewModel>> GetAllPortfolios();

        Task<CreateOrEditPortfolioViewModel> FillCreateOrEditPortfolioViewModel(long id);

        Task<bool> CreateOrEditPortfolio(CreateOrEditPortfolioViewModel portfolio);
        Task<bool> DeletePortfolio(long id);
        #endregion

    }
}
