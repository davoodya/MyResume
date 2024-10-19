using System.Collections.Generic;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<Experience> GetExperienceById(long id);
        Task<List<ExperienceViewModel>> GetAllExperience();

        Task<CreateOrEditExperienceViewModel> FillCreateOrEditExperienceViewModel(long id);

        Task<bool> CreateOrEditExperience(CreateOrEditExperienceViewModel experience);

        Task<bool> DeleteExperience(long id);
    }
}