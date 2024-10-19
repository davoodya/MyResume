
using System.Collections.Generic;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Services.Interfaces
{
    public interface IEducationService
    {
        Task<Education> GetEducationById(long id);
        Task<List<EducationViewModel>> GetAllEducation();

        Task<CreateOrEditEducationViewModel> FillCreateOrEditEducationViewModel(long id);

        Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education);
        Task<bool> DeleteEducation(long id);
    }
}