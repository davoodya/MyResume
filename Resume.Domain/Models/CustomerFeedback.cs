﻿using System.ComponentModel.DataAnnotations;


namespace Resume.Domain.Models
{
    public class CustomerFeedback
    {
        [Key] 
        public long Id { get; set; }


        [Display(Name = "آواتار")] 
        public string Avatar { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100,ErrorMessage ="{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }


        [Display(Name = "اولویت")] 
        public int Order { get; set; } = 0;
    }
}
