using System.Collections.Generic;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Domain.ViewModels.Page
{
    public class IndexPageViewModel
    {
        public List<ThingIDoListViewModel> ThingIDoList { get; set; }
        public List<CustomerFeedbackViewModel> CustomerFeedbackList { get; set; }
        public List<CustomerLogoListViewModel> CustomerLogoList { get; set; }
    }
}
