using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class ExperienceService:IExperienceService
    {
        #region Constractor

        private readonly AppDbContext _context;

        public ExperienceService(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<Experience> GetExperienceById(long id)
        {
            return await _context.Experiences.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<ExperienceViewModel>> GetAllExperience()
        {
            List<ExperienceViewModel> experiences = await _context.Experiences
                .OrderBy(e=>e.Order)
                .Select(e=> new ExperienceViewModel()
                {
                    Id = e.Id,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Title = e.Title,
                    Description = e.Description,
                    Order = e.Order

                }).ToListAsync();

            return experiences;

        }

        public async Task<CreateOrEditExperienceViewModel> FillCreateOrEditExperienceViewModel(long id)
        {
            if(id == 0)
                return new CreateOrEditExperienceViewModel(){Id = 0};

            Experience experience = await GetExperienceById(id);
            if (experience == null)
                return new CreateOrEditExperienceViewModel() { Id = 0 };

            return new CreateOrEditExperienceViewModel()
            {
                Id = experience.Id,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                Title = experience.Title,
                Description = experience.Description,
                Order = experience.Order
            };
        }

        public async Task<bool> CreateOrEditExperience(CreateOrEditExperienceViewModel experience)
        {
            if (experience.Id == 0)
            {
                var newExperience = new Experience()
                {
                    Description = experience.Description,
                    Order = experience.Order,
                    StartDate = experience.StartDate,
                    EndDate = experience.EndDate,
                    Title = experience.Title
                };

                await _context.Experiences.AddAsync(newExperience);
                await _context.SaveChangesAsync();
                return true;
            }

            Experience currentExperience= await GetExperienceById(experience.Id);
            if(currentExperience == null) return false;

            currentExperience.Description = experience.Description;
            currentExperience.Order = experience.Order;
            currentExperience.StartDate = experience.StartDate;
            currentExperience.EndDate = experience.EndDate;
            currentExperience.Title = experience.Title;

            _context.Experiences.Update(currentExperience);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExperience(long id)
        {
            Experience experience = await GetExperienceById(id);
            if (experience == null) return false;
            
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
