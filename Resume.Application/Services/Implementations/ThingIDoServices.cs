using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class ThingIDoServices:IThingIDoServices
    {
        #region Constractor

        private readonly AppDbContext _context;

        public ThingIDoServices(AppDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<ThingIDo> GetThingIDoById(long id)
        {
            return await _context.ThingIDos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<ThingIDoListViewModel>> GetAllThingIDoForIndex()
        {
            List<ThingIDoListViewModel> thingIDos = await _context.ThingIDos
                .OrderBy(t=> t.Order)
                .Select(t=>new ThingIDoListViewModel()
                {
                    Id = t.Id,
                    Order = t.Order,
                    ColumnLg = t.ColumnLg,
                    Description = t.Description,
                    Icon = t.Icon,
                    Title = t.Title,
                })
                .ToListAsync();

            return thingIDos;
        }

        public async Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo)
        {
            if (thingIDo.Id == 0)
            {
                //Create
                var newThingIDo = new ThingIDo()
                {
                    Id = thingIDo.Id,
                    Title = thingIDo.Title,
                    Description = thingIDo.Description,
                    Icon = thingIDo.Icon,
                    ColumnLg = thingIDo.ColumnLg,
                    Order = thingIDo.Order,
                };

                await _context.ThingIDos.AddAsync(newThingIDo);
                await _context.SaveChangesAsync();
                return true;
            }

            //Edit
            ThingIDo currentThingIDo = await GetThingIDoById(thingIDo.Id);

            if (currentThingIDo == null) return false;
            
            currentThingIDo.Title = thingIDo.Title;
            currentThingIDo.Description = thingIDo.Description;
            currentThingIDo.Icon = thingIDo.Icon;
            currentThingIDo.ColumnLg = thingIDo.ColumnLg;
            currentThingIDo.Order = thingIDo.Order;

            _context.ThingIDos.Update(currentThingIDo);
            await _context.SaveChangesAsync();
            
            return false;
        }

        public async Task<CreateOrEditThingIDoViewModel> FillCreateOrEditThingIDoViewModel(long id)
        {
            if(id == 0) return new CreateOrEditThingIDoViewModel(){Id = 0};

            ThingIDo thingIDo = await GetThingIDoById(id);
            if(thingIDo == null) return new CreateOrEditThingIDoViewModel() { Id = 0};

            return new CreateOrEditThingIDoViewModel()
            {
                Id = thingIDo.Id,
                Title = thingIDo.Title,
                Description = thingIDo.Description,
                Icon = thingIDo.Icon,
                ColumnLg = thingIDo.ColumnLg,
                Order = thingIDo.Order
            };
        }

        public async Task<bool> DeleteThingIDo(long id)
        {
            ThingIDo thigIDo = await GetThingIDoById(id);
            if(thigIDo == null) return false;

            _context.ThingIDos.Remove(thigIDo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
