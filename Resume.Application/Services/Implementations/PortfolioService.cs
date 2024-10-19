using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Portfolio;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class PortfolioService:IPortfolioService
    {
        #region Constractor

        private readonly AppDbContext _context;

        public PortfolioService(AppDbContext context)
        {
            _context = context;
        }

        #endregion


        #region Portfolio Category


        public async Task<PortfolioCategory> GetPortfolioCategoryById(long id)
        {
            return await _context.PortfolioCategories.FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task<List<PortfolioCategoryViewModel>> GetAllPortfolioCategories()
        {
            List<PortfolioCategoryViewModel> portfolioCategories = await _context.PortfolioCategories
                .OrderBy(pc => pc.Order)
                .Select(pc => new PortfolioCategoryViewModel()
                {
                    Id = pc.Id,
                    Order = pc.Order,
                    Name = pc.Name,
                    Title = pc.Title
                })
                .ToListAsync();

            return portfolioCategories;
        }

        public async Task<CreateOrEditPortfolioCategoryViewModel> FillCreateOrEditPortfolioCategoryViewModel(long id)
        {
            if(id == 0) 
                return new CreateOrEditPortfolioCategoryViewModel(){Id = 0};

            PortfolioCategory portfolioCategory = await GetPortfolioCategoryById(id);
            if (portfolioCategory == null)
                return new CreateOrEditPortfolioCategoryViewModel() { Id = 0 };

            return new CreateOrEditPortfolioCategoryViewModel()
            {
                Id = portfolioCategory.Id,
                Name = portfolioCategory.Name,
                Title = portfolioCategory.Title,
                Order = portfolioCategory.Order
            };
        }

        public async Task<bool> CreateOrEditPortfolioCategory(CreateOrEditPortfolioCategoryViewModel portfolioCategory)
        {
            if (portfolioCategory.Id == 0)
            {
                var newPortfolioCategory = new PortfolioCategory()
                {
                    Name = portfolioCategory.Name,
                    Title = portfolioCategory.Title,
                    Order = portfolioCategory.Order
                };
                await _context.PortfolioCategories.AddAsync(newPortfolioCategory);
                await _context.SaveChangesAsync();
                return true;
            }

            PortfolioCategory currentPortfolioCategory = await GetPortfolioCategoryById(portfolioCategory.Id);
            if (currentPortfolioCategory == null) return false;

            currentPortfolioCategory.Name = portfolioCategory.Name;
            currentPortfolioCategory.Title = portfolioCategory.Title;
            currentPortfolioCategory.Order = portfolioCategory.Order;

            _context.PortfolioCategories.Update(currentPortfolioCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePortfolioCategory(long id)
        {
            PortfolioCategory portfolioCategory = await GetPortfolioCategoryById(id);
            if(portfolioCategory == null) return false;

            _context.PortfolioCategories.Remove(portfolioCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        #endregion

        #region Portfolio

        public async Task<Portfolio> GetPortfolioById(long id)
        {
            return await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PortfolioViewModel>> GetAllPortfolios()
        {
            List<PortfolioViewModel> portfolios = await _context.Portfolios
                .OrderBy(p => p.Order)
                .Select(p => new PortfolioViewModel()
                {
                    Id = p.Id,
                    Order = p.Order,
                    Image = p.Image,
                    ImageAlt = p.ImageAlt,
                    Link = p.Link,
                    Title = p.Title,
                    PortfolioCategoryName = p.PortfolioCategory.Name
                })
                .ToListAsync();

            return portfolios;
        }

        public async Task<CreateOrEditPortfolioViewModel> FillCreateOrEditPortfolioViewModel(long id)
        {
            if (id == 0)
            {
                return new CreateOrEditPortfolioViewModel()
                {
                    Id = 0,
                    PortfolioCategories = await GetAllPortfolioCategories()
                };
            }

            Portfolio portfolio = await GetPortfolioById(id);

            if (portfolio==null)
            {
                return new CreateOrEditPortfolioViewModel()
                {
                    Id = 0,
                    PortfolioCategories = await GetAllPortfolioCategories()
                };
            }

            return new CreateOrEditPortfolioViewModel()
            {
                Id = portfolio.Id,
                Order = portfolio.Order,
                Image = portfolio.Image,
                Link = portfolio.Link,
                ImageAlt = portfolio.ImageAlt,
                Title = portfolio.Title,
                PortfolioCategories = await GetAllPortfolioCategories()
            };

        }

        public async Task<bool> CreateOrEditPortfolio(CreateOrEditPortfolioViewModel portfolio)
        {
            if (portfolio.Id == 0)
            {
                Portfolio newPortfolio = new Portfolio()
                {
                    Image = portfolio.Image,
                    Link = portfolio.Link,
                    ImageAlt = portfolio.ImageAlt,
                    Title = portfolio.Title,
                    Order = portfolio.Order,
                    PortfolioCategoryId = portfolio.PortfolioCategoryId,
                };
                await _context.Portfolios.AddAsync(newPortfolio);
                await _context.SaveChangesAsync();
                return true;
            }

            Portfolio currentPortfolio = await GetPortfolioById(portfolio.Id);
            if (currentPortfolio == null) return false;

            currentPortfolio.Image = portfolio.Image;
            currentPortfolio.Link = portfolio.Link;
            currentPortfolio.Title = portfolio.Title;
            currentPortfolio.Order = portfolio.Order;
            currentPortfolio.ImageAlt = portfolio.ImageAlt;
            currentPortfolio.PortfolioCategoryId = portfolio.PortfolioCategoryId;

            _context.Portfolios.Update(currentPortfolio);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePortfolio(long id)
        {
            
            Portfolio portfolio = await GetPortfolioById(id);
            if (portfolio == null) return false;

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return true;

        }

        #endregion
    }
}
