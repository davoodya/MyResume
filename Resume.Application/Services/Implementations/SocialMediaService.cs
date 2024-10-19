using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.SocialMedia;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class SocialMediaService:ISocialMediaService
    {
        #region Constractor

        private readonly AppDbContext _context;

        public SocialMediaService(AppDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<List<SocialMediaViewModel>> GetAllSocialMedias()
        {
            List<SocialMediaViewModel> socialMedias = await _context.SocialMedias
                .OrderBy(s=> s.Order)
                .Select(s=> new SocialMediaViewModel()
                {
                    Id = s.Id,
                    Link = s.Link,
                    Order = s.Order,
                    Icon = s.Icon,
                }).ToListAsync();

            return socialMedias;
        }
    }
}
