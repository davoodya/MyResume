﻿using System.Collections.Generic;
using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Domain.ViewModels.ViewComponent
{
    public class SideBarViewModel
    {
        public List<SocialMediaViewModel> SocialMedias { get; set; }
        public InformationViewModel information { get; set; }
    }
}
