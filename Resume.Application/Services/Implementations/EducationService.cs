using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Education;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class EducationService : IEducationService
    {
        #region Constractor

        private readonly AppDbContext _context;

        public EducationService(AppDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<Education> GetEducationById(long id)
        {
            return await _context.Educations.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<EducationViewModel>> GetAllEducation()
        {
            List<EducationViewModel> educations = await _context.Educations
                .OrderBy(e=> e.Order)
                .Select(e=> new EducationViewModel()
                {
                    Id = e.Id,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Title = e.Title,
                    Description = e.Description,
                    Order = e.Order

                }).ToListAsync();

            return educations;
        }

        public async Task<CreateOrEditEducationViewModel> FillCreateOrEditEducationViewModel(long id)
        {
            if(id == 0)
                return new CreateOrEditEducationViewModel() { Id = 0 };

            Education education = await GetEducationById(id);
            if (education == null)
                return new CreateOrEditEducationViewModel() { Id = 0 };

            return new CreateOrEditEducationViewModel()
            {
                Id = education.Id,
                Description = education.Description,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Title = education.Title,
                Order = education.Order
            };

        }

        public async Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education)
        {
            if (education.Id == 0)
            {
                var newEducatin = new Education()
                {
                    Description = education.Description,
                    StartDate = education.StartDate,
                    EndDate = education.EndDate,
                    Title = education.Title,
                    Order = education.Order
                };
                await _context.Educations.AddAsync(newEducatin);
                await _context.SaveChangesAsync();

                return true;
            }

            Education currentEducation = await GetEducationById(education.Id);
            if(currentEducation == null) return false;

            currentEducation.Description = education.Description;
            currentEducation.StartDate = education.StartDate;
            currentEducation.EndDate = education.EndDate;
            currentEducation.Title = education.Title;
            currentEducation.Order = education.Order;

            _context.Educations.Update(currentEducation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEducation(long id)
        {
            Education education = await GetEducationById(id);
            if(education == null) return false;

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}