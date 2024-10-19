using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class InformationService:IInformationService
    {
        #region Constractor

        private readonly AppDbContext _context;

        public InformationService(AppDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<InformationViewModel> GetInformation()
        {
            InformationViewModel information = await _context.Informations
                .Select(i => new InformationViewModel()
                {
                    Id = i.Id,
                    Address = i.Address,
                    Avatar = i.Avatar,
                    DateOfBirth = i.DateOfBirth,
                    Email = i.Email,
                    Job = i.Job,
                    Name = i.Name,
                    Phone = i.Phone,
                    ResumeFile = i.ResumeFile,
                    MapSrc = i.MapSrc
                }).FirstOrDefaultAsync();

            if (information == null)
            {
                return new InformationViewModel();
            }


            return information;
        }

        public async Task<Information> GetInformationModel()
        {
            return await _context.Informations.FirstOrDefaultAsync();
        }

        public async Task<CreateOrEditInformationViewModel> FillCreateOrEditInformationViewModel()
        {
            Information information = await GetInformationModel();
            if(information == null)
                return new CreateOrEditInformationViewModel(){Id = 0};

            return new CreateOrEditInformationViewModel()
            {
                Id = information.Id,
                Address = information.Address,
                Avatar = information.Avatar,
                DateOfBirth = information.DateOfBirth,
                Email = information.Email,
                Job = information.Job,
                Name = information.Name,
                Phone = information.Phone,
                ResumeFile = information.ResumeFile,
                MapSrc = information.MapSrc
            };
        }

        public async Task<bool> CreateOrEditInformation(CreateOrEditInformationViewModel information)
        {
            if (information.Id == 0)
            {
                var newInformation = new Information()
                {
                    Name = information.Name,
                    Phone = information.Phone,
                    DateOfBirth = information.DateOfBirth,
                    Email = information.Email,
                    Job = information.Job,
                    Address = information.Address,
                    Avatar = information.Avatar,
                    MapSrc = information.MapSrc,
                    ResumeFile = information.ResumeFile
                };
                await _context.Informations.AddAsync(newInformation);
                await _context.SaveChangesAsync();
                return true;
            }

            Information currentInformation = await GetInformationModel();

            currentInformation.Name = information.Name;
            currentInformation.Phone = information.Phone;
            currentInformation.DateOfBirth = information.DateOfBirth;
            currentInformation.Email = information.Email;
            currentInformation.Job = information.Job;
            currentInformation.Address = information.Address;
            currentInformation.Avatar = information.Avatar;
            currentInformation.MapSrc = information.MapSrc;
            currentInformation.ResumeFile = information.ResumeFile;

            _context.Informations.Update(currentInformation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
