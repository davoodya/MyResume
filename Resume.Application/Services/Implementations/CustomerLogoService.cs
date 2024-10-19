using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class CustomerLogoService:ICustomerLogoService
    {
        #region Constractor
        private readonly AppDbContext _context;

        public CustomerLogoService(AppDbContext context)
        {
                _context = context;
        }
        #endregion
        public async Task<List<CustomerLogoListViewModel>> GetCustomerLogoForIndexPage()
        {
            List<CustomerLogoListViewModel> customerLogos = await _context.CustomerLogos
                .OrderBy(c=>c.Order)
                .Select(c=> new CustomerLogoListViewModel()
                {
                    Id = c.Id,
                    Logo = c.Logo,
                    LogoAlt = c.LogoAlt,
                    Link = c.Link,
                    Order = c.Order
                })
                .ToListAsync();

            return customerLogos;
        }
    }
}
