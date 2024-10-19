﻿using System.ComponentModel.DataAnnotations;


namespace Resume.Domain.Models
{
    public class ThingIDo
    {
        #region Properties
        [Key]
        public long Id { get; set; }

        [Display(Name = "آیکون")]
        [MaxLength(50,ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Icon { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Title { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1000, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Description { get; set; }

        [Display(Name = "عرض ستون آیتم")]
        [Range(4,12,ErrorMessage = "عدد وارد شده باید بین 4 تا 12 باشد")]
        public int ColumnLg { get; set; } =6;

        
        [Display(Name = "اولویت")]
        public int Order { get; set; }=0;

        #endregion

    }
}
