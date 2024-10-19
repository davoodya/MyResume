﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;

namespace Resume.Web.Controllers
{
    public class ResumeController : Controller
    {
        #region Constractor

        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        private readonly ISkillService _skillService;

        public ResumeController(IEducationService educationService, IExperienceService experienceService, ISkillService skillService)
        {
            _educationService = educationService;
            _experienceService = experienceService;
            _skillService = skillService;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            ResumePageViewModel model = new ResumePageViewModel()
            {
                Educations = await _educationService.GetAllEducation(),
                Experiences = await _experienceService.GetAllExperience(),
                Skills = await _skillService.GetAllSkills()
            };
            return View(model);
        }
    }
}
