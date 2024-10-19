using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Resume.Domain.ViewModels.Portfolio
{
    public class PortfolioViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "لینک")]
        public string Link { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "توضیح تصویر")]
        public string ImageAlt { get; set; }


        [Display(Name = "اولویت")]
        public int Order { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        public string PortfolioCategoryName { get; set; }
    }
}
