using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Resume.Domain.ViewModels.ThingIDo
{
    public class ThingIDoListViewModel
    {
        public long Id { get; set; }


        [Display(Name = "آیکون")]
        public string Icon { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "عرض ستون آیتم")]
        public int ColumnLg { get; set; } = 6;


        [Display(Name = "اولویت")]
        public int Order { get; set; } = 0;
    }
}
