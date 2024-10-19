using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.SocialMedia
{
    public class SocialMediaViewModel
    {
        public long Id { get; set; }


        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Link { get; set; }


        [Display(Name = "آیکون")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد {0}")]
        public string Icon { get; set; }

        [Display(Name = "اولویت")]
        public int Order { get; set; }
    }
}
