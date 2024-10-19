﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerFeedbackService
    {
        Task<CustomerFeedback> GetCustomerFeedbackById(long id);
        Task<List<CustomerFeedbackViewModel>> GetCustomerFeedbackForIndex();

        Task<bool> CreateOrEditCustomerFeedback(CreateOrEditCustomerFeedbackViewModel customerFeedback);
        Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id);
        Task<bool> DeleteCustomerFeedback(long id);
    }
}
