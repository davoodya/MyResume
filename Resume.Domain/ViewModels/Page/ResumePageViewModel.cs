using Resume.Domain.ViewModels.Education;
using System.Collections.Generic;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Domain.ViewModels.Page
{
    public class ResumePageViewModel
    {
        public List<EducationViewModel> Educations { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }
        public List<SkillViewModel> Skills { get; set; }
    }
}
