using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class CustomerFeedbackService:ICustomerFeedbackService
    {
        #region Constractor

        private readonly AppDbContext _context;

        public CustomerFeedbackService(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<CustomerFeedback> GetCustomerFeedbackById(long id)
        {
            return await _context.CustomerFeedbacks.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CustomerFeedbackViewModel>> GetCustomerFeedbackForIndex()
        {
            List<CustomerFeedbackViewModel> customerFeedbacks = await _context.CustomerFeedbacks
                .OrderBy(c=> c.Order)
                .Select(c=> new CustomerFeedbackViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Order = c.Order,
                    Description = c.Description,
                    Avatar = c.Avatar,
                })
                .ToListAsync();

            return customerFeedbacks;
        }

        public async Task<bool> CreateOrEditCustomerFeedback(CreateOrEditCustomerFeedbackViewModel customerFeedback)
        {
            if (customerFeedback.Id == 0)
            {
                var newCustomerFeedback  = new  CustomerFeedback()
                {
                    Name = customerFeedback.Name,
                    Avatar = customerFeedback.Avatar,
                    Description = customerFeedback.Description,
                    Order = customerFeedback.Order,
                };
                await _context.CustomerFeedbacks.AddAsync(newCustomerFeedback);
                await _context.SaveChangesAsync();
                return true;
            }

            CustomerFeedback currentCustomerFeedback = await GetCustomerFeedbackById(customerFeedback.Id);
            if (currentCustomerFeedback == null) return false;

            currentCustomerFeedback.Name = customerFeedback.Name;
            currentCustomerFeedback.Avatar = customerFeedback.Avatar;
            currentCustomerFeedback.Description= customerFeedback.Description;
            currentCustomerFeedback.Order = customerFeedback.Order;

            _context.CustomerFeedbacks.Update(currentCustomerFeedback);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id)
        {
            if(id == 0) 
                return new CreateOrEditCustomerFeedbackViewModel(){Id = 0};

            CustomerFeedback customerFeedback = await GetCustomerFeedbackById(id);
            if (customerFeedback == null) 
                return new CreateOrEditCustomerFeedbackViewModel(){Id = 0};

            return new CreateOrEditCustomerFeedbackViewModel()
            {
                Id = customerFeedback.Id,
                Name = customerFeedback.Name,
                Avatar = customerFeedback.Avatar,
                Description = customerFeedback.Description,
                Order = customerFeedback.Order
            };
        }

        public async Task<bool> DeleteCustomerFeedback(long id)
        {
            CustomerFeedback customerFeedback = await GetCustomerFeedbackById(id);
            if (customerFeedback == null) return false;

            _context.CustomerFeedbacks.Remove(customerFeedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
