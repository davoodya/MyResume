﻿
using System.ComponentModel.DataAnnotations;


namespace Resume.Domain.ViewModels.Education
{
    public class EducationViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عنوان")] 
        public string Title { get; set; }

        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "اولویت")]
        public int Order { get; set; }
    }
}
