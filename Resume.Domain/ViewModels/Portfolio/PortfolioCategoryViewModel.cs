using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Resume.Domain.ViewModels.Portfolio
{
    public class PortfolioCategoryViewModel
    {
        public long Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "اولویت")]
        public int Order { get; set; }

    }
}
